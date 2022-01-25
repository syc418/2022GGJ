using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_temple : MonoBehaviour
{
    public float disapear_time = 5f;
    private SpriteRenderer foodtemple;
    private float current_time = 0f;
    private float alpha = 255f;
    // Start is called before the first frame update
    void Start()
    {
        foodtemple = GetComponent<SpriteRenderer>();
         
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(current_time);
        if (current_time < disapear_time)
        {
            alpha = 255 * ((disapear_time - current_time) / disapear_time);
            //Debug.Log("Alpha value is " + alpha);
            foodtemple.color = new Color (255f, 255f, 255f, alpha);
            current_time += Time.deltaTime;
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            foodtemple.enabled = false;
        }
        
    }
}
