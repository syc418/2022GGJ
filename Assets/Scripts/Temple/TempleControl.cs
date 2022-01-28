using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleControl : MonoBehaviour
{
    public GameObject temple;
    public GameObject destroyableObjects;
    private bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        if(destroyableObjects == null && gameObject.tag == "Lantern")
        {
            //obstacles exploded, so players don't get food.
            Destroy(gameObject);
        }else if(destroyableObjects.active == false && !isActivated)
        {
            temple.GetComponent<food_temple>().enabled = true;
            isActivated = true;
        }
        
    }
}
