using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    public GameObject bullet;
    public float trail_lifeTime;
    public bool isKilled = false;

    // Update is called once per frame
    void Update()
    {
        if (isKilled) return;

        if (bullet.activeSelf)
        {
            GetComponent<Rigidbody2D>().MovePosition(bullet.transform.position);
        }
        else 
        {
            GetComponent<ParticleSystem>().Stop();
            StartCoroutine(SelfDestruction());
            isKilled = true;
        }
    }

    private void OnEnable()
    {
        isKilled = false;
        GetComponent<ParticleSystem>().Play();
    }

    private IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(trail_lifeTime);
        BulletTrail_Pool._this.Return(this.gameObject);
    }

}
