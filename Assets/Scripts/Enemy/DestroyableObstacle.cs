using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObstacle : MonoBehaviour
{
    public float health_max;
    private float health;

    public void Damage(float dmg) 
    {
        health -= dmg;
        if (health <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

    public void Awake()
    {
        health = health_max;
    }
}
