using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject ImpactEffect;
    public float exploisionRadius = 0f;

    public float speed = 70f;
    public int damage = 50;
    public void Seek(Transform _target)
    {
        target= _target;
    }

    private void Update()
    {
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir=target.position-transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <=  distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void Damage (Transform enemy)
    {
       Enemy e= enemy.GetComponent<Enemy>();

        if(e!=null)
        {
            e.TakeDamage(damage);
        }

       

        
    }
     void HitTarget()
    {
        GameObject effectInstance=(GameObject)Instantiate(ImpactEffect,transform.position,transform.rotation);
        Destroy(effectInstance, 5f);
        if(exploisionRadius>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

       
        Destroy(gameObject);
    }

    private void Explode( )
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exploisionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag=="Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
}
