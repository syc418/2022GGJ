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
            Debug.Log("Hit player "+ bullet_damage+ " dmg.");

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
    }

    private IEnumerator SelfDestruction() 
    {
        yield return new WaitForSeconds(bullet_lifeTime);
        EnemyBullet_Pool._this.Return(this.gameObject);
    }


}
