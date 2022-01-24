using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float bullet_damage;

    public float fire_rate;
    private float fire_rate_timer;

    public float fire_gap;      //time between bullet for the same shoot
    public float fire_burst;    //number of bullet each shoot

    public GameObject bullet_prefab;

    public float bullet_speed;

    //shoot with random rotation
    private void Shoot(Vector3 bullet_direction, float bullet_speed, float bullet_angularSpeed)
    {
        //get bullet from pool
        GameObject bullet = GameObject.Instantiate(bullet_prefab, this.transform.position, this.transform.rotation, this.transform);
        //random rotation
        bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360));
        //set bullet damage
        bullet.GetComponent<PlayerBullet>().bullet_damage = bullet_damage;
        //add force & angular speed
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet_direction * bullet_speed, ForceMode2D.Impulse);
        rb.angularVelocity = bullet_angularSpeed;
    }

    private void ShootUpward()
    {
        Shoot(new Vector3(0, 1, 0), bullet_speed, 30f);
    }

    private void Update()
    {
        if (fire_rate_timer <= 0)
        {
            ShootUpward();
            fire_rate_timer = fire_rate;
        }
        else
        {
            fire_rate_timer -= Time.deltaTime;
        }
    }
}
