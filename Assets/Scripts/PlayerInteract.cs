using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public Slider health;

    //InVulnerable Time
    [SerializeField]
    private bool is_Vulnreable;
    [SerializeField]
    private float InVulnerableTime;

    //Animator
    [SerializeField]
    private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered" + collision.gameObject.tag);
        if (collision.gameObject.tag == "food")
        {
            health.value += collision.gameObject.GetComponent<food>().recovery;
            Destroy(collision.gameObject);
            health.GetComponent<Health>().iseat = true;
        }
    }

    public void Damage(float damage)
    {
        if (is_Vulnreable) 
        {
            health.value -= damage;
            animator.SetTrigger("IsDamaged");
            SetInVulnerable(InVulnerableTime);
        }
        
    }

    public void SetInVulnerable(float time) 
    {
        is_Vulnreable = false;
        StartCoroutine(VulunerableRecover(time));
    }


    private IEnumerator VulunerableRecover(float time)
    {
        yield return new WaitForSeconds(time);
        is_Vulnreable = true;
    }
}
