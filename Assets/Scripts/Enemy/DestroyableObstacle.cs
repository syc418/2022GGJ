using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObstacle : MonoBehaviour
{
    public float health_max;
    public float health;

    public void Damage(float dmg) 
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Awake()
    {
        health = health_max;
    }

    void Update()
    {
        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }

    }

}
