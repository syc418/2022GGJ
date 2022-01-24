using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public Slider health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered" + collision.gameObject.tag);
        if (collision.gameObject.tag == "food")
        {
            health.value += 1;
            Destroy(collision.gameObject);
            health.GetComponent<Health>().iseat = true;
        }
    }
}