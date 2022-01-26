using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObstacle : MonoBehaviour
{
    public float health_max;
    private float health;

    public void Damage(float dmg) 
    {
        health -= dmg;
        if (health <= 0) 
        {
            //this.GetComponent<FoodShowUp>().ShowUpFood(this.transform.position);
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in transform)
            {
                Debug.Log(child.gameObject.tag);
                if (child.gameObject.tag == "foodgenerator")
                {
                    child.gameObject.GetComponent<foodgenerator>().enabled = true;
                }
                child.gameObject.SetActive(false);
            }
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Awake()
    {
        health = health_max;
    }

    void Update()
    {
        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }

    }
}
