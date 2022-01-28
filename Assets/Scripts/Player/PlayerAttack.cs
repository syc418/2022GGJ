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
        bullet.transform.rotation = transform.rotation;
        //set bullet damage
        bullet.GetComponent<PlayerBullet>().bullet_damage = bullet_damage;
        //add force & angular speed
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet_direction * bullet_speed, ForceMode2D.Impulse);
        rb.angularVelocity = bullet_angularSpeed;
    }

    //shoot [fire_burst] bullet at once, with [fire_gap] time between each bullet
    public void ShootBurst()
    {
        float random_angularspeed = Random.Range(180, 720);
        for (int i = 0; i < fire_burst; i++)
        {
            StartCoroutine(DelayShoot(i * fire_gap, new Vector3(0, 1, 0), bullet_speed, 0f));
        }
    }

    private IEnumerator DelayShoot(float delay, Vector3 bullet_direction, float bullet_speed, float bullet_angularSpeed)
    {
        yield return new WaitForSeconds(delay);
        Shoot(bullet_direction, bullet_speed, bullet_angularSpeed);
    }

    private void ShootUpward()
    {
        Shoot(new Vector3(0, 1, 0), bullet_speed, 0f);
    }

    private void Update()
    {
        if (fire_rate_timer <= 0)
        {
            ShootBurst();
            fire_rate_timer = fire_rate;
        }
        else
        {
            fire_rate_timer -= Time.deltaTime;
        }
    }
}
