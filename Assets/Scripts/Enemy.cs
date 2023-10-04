using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health= 50f;
    public int points = 20;
    public void GetDamage(float Damage)
    {
        health-=Damage;
        if(health<=0)
        {
            GameManager.instance.UpdateScore(points);
            Destroy(this.gameObject);
        }
        
    }
}
