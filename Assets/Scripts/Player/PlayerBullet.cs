using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bullet_damage;

    public float bullet_lifeTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //deal damage to Obstacle
            collision.gameObject.GetComponent<DestroyableObstacle>().Damage(bullet_damage);

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
        //Self Destruct everytime it's enabled (ie. SetActive(true))
        StartCoroutine(SelfDestruction());

    }

    private IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(bullet_lifeTime);
        Destroy(this.gameObject);

    }
}
