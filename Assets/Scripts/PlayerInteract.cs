using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public Slider health;
    public float health_ratio = 1f;
    public float damage_ratio = 1f;

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
            health.value += collision.gameObject.GetComponent<food>().recovery * health_ratio;
            Destroy(collision.gameObject);
            health.GetComponent<Health>().iseat = true;
        }
    }

    public void Damage(float damage)
    {
        if (is_Vulnreable) 
        {
            health.value -= damage * damage_ratio;
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
