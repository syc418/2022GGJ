using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bullet_damage;

    public float bullet_lifeTime;

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
            Debug.Log("Explosion Small.");
            //setup delay destruction for particle
            ExplosionParticleSmall_Pool._this.StartCoroutine(ExplosionParticleSmall_Pool._this.Delay_Return(ExplosionParticleSmall_Pool._this.particle_lifeTime, particle));

            //kill bullet
            EnemyBullet_Pool._this.Return(this.gameObject);
        }
        else if (collision.CompareTag("BlockBullet")) 
        {
            EnemyBullet_Pool._this.Return(this.gameObject);
        }
    }

    private void OnEnable()
    {

        //Self Destruct everytime it's enabled (ie. SetActive(true))
        StartCoroutine(SelfDestruction());

        //make trail
        GameObject trail = BulletTrail_Pool._this.Get(transform.position, Quaternion.identity, BulletTrail_Pool._this.transform);
        trail.GetComponent<BulletTrail>().bullet = this.gameObject;

    }

    private IEnumerator SelfDestruction() 
    {
        yield return new WaitForSeconds(bullet_lifeTime);
        EnemyBullet_Pool._this.Return(this.gameObject);

    }

}
