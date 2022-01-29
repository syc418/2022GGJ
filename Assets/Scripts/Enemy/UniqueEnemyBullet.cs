using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueEnemyBullet : MonoBehaviour
{
    public float bullet_damage;

    public float bullet_lifeTime;

    public float bullet_speed;

    public float bullet_angularSpeed;

    public Vector3 move_direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //deal damage to player
            //Debug.Log("Hit player "+ bullet_damage+ " dmg.");
            collision.gameObject.GetComponent<PlayerInteract>().Damage(bullet_damage);

            //show explosion particle small
            GameObject particle = ExplosionParticleSmall_Pool._this.Get(transform.position, transform.rotation, transform);
            particle.transform.SetParent(null);
            //setup delay destruction for particle
            ExplosionParticleSmall_Pool._this.StartCoroutine(ExplosionParticleSmall_Pool._this.Delay_Return(ExplosionParticleSmall_Pool._this.particle_lifeTime, particle));

            //kill bullet
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        //start self destruction
        StartCoroutine(SelfDestruction());
    }

    private void FixedUpdate()
    {
        //travel downward
        //add force & angular speed
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(move_direction * bullet_speed, ForceMode2D.Force);
        rb.angularVelocity = Mathf.Lerp(30f, bullet_angularSpeed, 1f);
    }

    private IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(bullet_lifeTime);
        Destroy(this.gameObject);

    }

}
