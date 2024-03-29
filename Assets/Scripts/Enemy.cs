using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;


    public float startHealth=100;
    private float health;

   

    public int moneyByDie=50;

    [Header("Unity Stuff")]
    public Image healthBar;


    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float Amount)
    {
        health-=Amount;
        healthBar.fillAmount=health/startHealth ;
        if (health <= 0)
            Die();
    }

    public void Slow(float pct)
    {
        speed = startSpeed*(1f - pct);
    }
    void Die()
    {
        PlayerStats.Money += moneyByDie;
        Destroy(gameObject);
    }

}
