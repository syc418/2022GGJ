using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public ObjectPool bullet_pools;

    public float bullet_damage;

    public float fire_rate;
    private float fire_rate_countdown;

    public float number_bullet;

    public void Shoot(Vector3 bullet_direction, float bullet_speed, float bullet_angularSpeed) 
    {
        //get bullet from pool
        GameObject bullet = EnemyBullet_Pool._this.Get(this.transform.position, this.transform.rotation, this.transform);
        //random rotation
        bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)) ;
        //set bullet damage
        bullet.GetComponent<EnemyBullet>().bullet_damage = bullet_damage;
        //add force & angular speed
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet_direction * bullet_speed, ForceMode2D.Impulse);
        rb.angularVelocity = bullet_angularSpeed;
    }

    public void ShootTest() 
    {
        Shoot(new Vector3(0,-1,0), 5f, 30f);
    }

    //bullets not even
    public void ShootInCircle() 
    {
        float random_startAngle = Random.Range(0,360);
        float angle = (360 / number_bullet) + random_startAngle;

        for (int i = 0; i < number_bullet; i++) 
        {
            Shoot(new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle * i), Mathf.Sin(Mathf.Deg2Rad * angle * i), 0), 5f, 30f);
        }
    }

    //bullets even
    public void ShootInCircleUniform()
    {
        float random_startAngle = Random.Range(0, 360);
        float angle = (360 / number_bullet);

        for (int i = 0; i < number_bullet; i++)
        {
            Shoot(new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle * i+ random_startAngle)), Mathf.Sin(Mathf.Deg2Rad * (angle * i + random_startAngle)), 0), 5f, 30f);
        }
    }

    private void Update()
    {
        if (fire_rate_countdown <= 0)
        {
            ShootInCircleUniform();
            fire_rate_countdown = fire_rate;
        }
        else 
        {
            fire_rate_countdown -= Time.deltaTime;
        }
    }


}
