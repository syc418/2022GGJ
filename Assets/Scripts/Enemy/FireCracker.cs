using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCracker : MonoBehaviour
{
    public float damage_radius;

    public float fireCracker_lifeTime;

    public void Play_Explosion() 
    {
        //show explosion particle
        GameObject explosion_effect = ExplosionParticle_Pool._this.Get(transform.position, transform.rotation, transform);
        explosion_effect.transform.SetParent(null);
        //setup delay destruction for particle
        ExplosionParticle_Pool._this.StartCoroutine(ExplosionParticle_Pool._this.Delay_Return(ExplosionParticle_Pool._this.particle_lifeTime, explosion_effect));
    }


    public void Check_Hit() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damage_radius); //if player is in stand-alone layer, it's better to only check that layer
        foreach (Collider2D collider in colliders) 
        {
            if (collider.CompareTag("Player")) 
            {
                //TO DO: apply damage to player in range
                Debug.Log("Player is hit by FireCracker.");
                return;
            }
        }
    }

    private void OnEnable()
    {
        //Self Destruct everytime it's enabled (ie. SetActive(true))
        StartCoroutine(SelfDestruction());

    }

    private IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(fireCracker_lifeTime);
        Destroy(this.gameObject);

    }

}
