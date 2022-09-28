using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;


    [Header("General")]


    public float range = 15f;

    [Header("Use Bullets(default) ")]
    public GameObject bulletPrefab; 
    public float fireRate = 1f;
   private float fireCounter = 0f;


    [Header("Use Laser ")]
    public bool useLaser=false;
    public LineRenderer lineRender;
    public ParticleSystem impactEffect;
    public Light Impactlight;
    public int damageOverTime = 30;
    public float slowPct = 0.5f;


    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turretspeed = 10f;
    public Transform firePoinht;

 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy. transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance=distanceToEnemy;
                nearestEnemy = enemy;   
            }
        }
        if(nearestEnemy != null&&shortestDistance<=range)
        {
            target = nearestEnemy.transform;
            targetEnemy=nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target==null)
        {
            if (useLaser)
            {
                if (lineRender.enabled)
                {
                    lineRender.enabled = false;
                    impactEffect.Stop();
                    Impactlight.enabled = false;
                }
            }
            return;
        }
        LockOnTarget();
        if(useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCounter <= 0f)
            {
                Shoot();
                fireCounter = 1f / fireRate;
            }
            fireCounter -= Time.deltaTime;
        }
        
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turretspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
       targetEnemy.TakeDamage(damageOverTime*Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!lineRender.enabled )
        {
            lineRender.enabled = true;
            impactEffect.Play();    
            Impactlight.enabled = true;
        }
        lineRender.SetPosition(0, firePoinht.position);
        lineRender.SetPosition(1, target.position);
        Vector3 dir = firePoinht.position - target.position;

        impactEffect.transform.position = target.position+dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    
    }
    void Shoot()
    {
      GameObject BulletGO=(GameObject)  Instantiate(bulletPrefab, firePoinht.position, firePoinht.rotation);
        Bullet bullet= BulletGO.GetComponent<Bullet>();

        if(bullet!=null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
