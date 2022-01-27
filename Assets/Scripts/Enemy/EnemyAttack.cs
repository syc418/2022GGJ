using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    public float bullet_damage = 10f;
    public float bullet_speed = 5f;

    public float fire_rate;
    private float fire_rate_timer;

    public float fire_gap;      //time between bullet for the same shoot
    public float fire_burst;    //number of bullet each shoot

    public bool one_shot = false;

    public UnityEvent shoot_way;

    private GameObject player_obj;

    private void Start()
    {
        player_obj = GameObject.Find("player");
    }

    //shoot with random rotation
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


    private IEnumerator DelayShoot(float delay, Vector3 bullet_direction, float bullet_speed, float bullet_angularSpeed)
    {
        yield return new WaitForSeconds(delay);
        Shoot(bullet_direction, bullet_speed, bullet_angularSpeed);
    }

    public void ShootTest() 
    {
        Shoot(new Vector3(0,-1,0), bullet_speed, 30f);
    }

    //bullets not Uniform
    public void ShootInCircle() 
    {
        float random_startAngle = Random.Range(0,360);
        float angle = (360 / fire_burst) + random_startAngle;

        for (int i = 0; i < fire_burst; i++) 
        {
            Shoot(new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle * i), Mathf.Sin(Mathf.Deg2Rad * angle * i), 0), bullet_speed, 30f);
        }
    }

    //bullets Uniform
    public void ShootInCircleUniform()
    {
        float random_startAngle = Random.Range(0, 360);
        float angle = (360 / fire_burst);

        for (int i = 0; i < fire_burst; i++)
        {
            Shoot(new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle * i + random_startAngle)), Mathf.Sin(Mathf.Deg2Rad * (angle * i + random_startAngle)), 0), bullet_speed, 30f);
        }
    }

    //bullets Uniform with delay (spiral)
    public void ShootInCircleUniformDelay()
    {
        float random_startAngle = Random.Range(0, 360);
        float angle = (360 / fire_burst);

        for (int i = 0; i < fire_burst; i++)
        {
            StartCoroutine(DelayShoot(i * fire_gap, new Vector3(Mathf.Cos(Mathf.Deg2Rad * (angle * i + random_startAngle)), Mathf.Sin(Mathf.Deg2Rad * (angle * i + random_startAngle)), 0), bullet_speed, Random.Range(180f, 720f)));
        }
    }

    //shoot [fire_burst] bullet at once, with [fire_gap] time between each bullet
    public void ShootBurst() 
    {
        for (int i = 0; i < fire_burst; i++) 
        {
            StartCoroutine(DelayShoot(i * fire_gap, new Vector3(0, -1, 0), bullet_speed, 30f));
        }
    }

    public void ShootBurstAtPlayer() 
    {
        for (int i = 0; i < fire_burst; i++)
        {
            Vector3 direction = (player_obj.transform.position - transform.position).normalized;
            StartCoroutine(DelayShoot(i * fire_gap, direction, bullet_speed, 30f));
        }
    }

    private void Update()
    {
        if (fire_rate_timer <= 0)
        {
            shoot_way.Invoke();
            fire_rate_timer = fire_rate;

            //disable the script if one_shot
            if (one_shot) this.enabled = false;
        }
        else 
        {
            fire_rate_timer -= Time.deltaTime;
        }

        //TO DO : destory object when it is out of sight
    }

}
