using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lantern : MonoBehaviour
{
    public float time_to_explode = 3f;
    public float distance_to_warning = 3f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
        float distance = Vector2.Distance(player.position, this.transform.position);
        if(distance <= distance_to_warning)
        {
            this.GetComponent<Animator>().enabled = true;
        }

        if (this.GetComponent<Animator>().enabled)
        {
            time_to_explode -= Time.deltaTime;
        }

        if (time_to_explode <= 0)
        {
            //show explosion particle
            GameObject explosion_effect = ExplosionParticle_Pool._this.Get(transform.position, transform.rotation, transform);
            explosion_effect.transform.SetParent(null);
            //setup delay destruction for particle
            ExplosionParticle_Pool._this.StartCoroutine(ExplosionParticle_Pool._this.Delay_Return(ExplosionParticle_Pool._this.particle_lifeTime, explosion_effect));
            Destroy(gameObject.transform.parent.transform.gameObject);
        }

    }
}
