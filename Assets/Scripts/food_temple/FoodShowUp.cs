using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShowUp : MonoBehaviour
{
    public GameObject foodgenerator;
    // Update is called once per frame
    
    public void ShowUpFood(Vector2 position)
    {
        Debug.Log("Generate food");
        GameObject obj = GameObject.Instantiate(foodgenerator, position, Quaternion.identity);
    }
   
}
