using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float current_health;
    private float last_health;
    private bool isDecreasing = false;

    public Slider health;
    public bool iseat = false;
    public float startcheck = 3f;
    public float checkrate = 2f;
    public float decreasing_ratio = 1.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        current_health = health.value;
        last_health = health.value;
        InvokeRepeating("decrease_health", startcheck, checkrate);

        
    }

    // Update is called once per frame
    void Update()
    {
        current_health = health.value;
        if (isDecreasing)
        {
            //Debug.Log("Decrease now");
            health.value -= decreasing_ratio * Time.deltaTime;
        }

        if(iseat)
        {
            //Debug.Log("eat now, stop decrease");
            isDecreasing = false;
        }
        
    }

    private void decrease_health()
    {
        //Debug.Log("Check if player eat");
        if (current_health == last_health)
        {
            //Debug.Log("didn't eat, start to decrease.");
            isDecreasing = true;
            iseat = false;
        }
        last_health = current_health;
    }
}
