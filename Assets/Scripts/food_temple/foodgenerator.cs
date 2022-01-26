using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodgenerator : MonoBehaviour
{
    private Collider2D collider;
    public GameObject apple;
    public GameObject chicken;
    public GameObject pig;

    private new GameObject[] food;
    // Start is called before the first frame update

    private void Start()
    {
        Food_Generate();
    }
    private void Food_Generate()
    {
        food = new GameObject[] { apple, chicken, pig};
        collider = GetComponent<Collider2D>();
        //spawn obj in random position within area
        Vector3 position = collider.bounds.center;
        
        int num = Random.Range(0, food.Length);
        for (int i = 0; i <= num; i++)
        {
            int index = Random.Range(0, food.Length);
            position.x += Random.Range(-1f * collider.bounds.extents.x, collider.bounds.extents.x);
            position.y += Random.Range(-1f * collider.bounds.extents.y, collider.bounds.extents.y);
            GameObject obj = GameObject.Instantiate(food[index], position, Quaternion.identity, this.transform);
            if(index == 2)
            {
                Debug.Log("break");
                break;
            }
        }
    }
}
