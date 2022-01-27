using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodgenerator : MonoBehaviour
{
    private Collider2D collider;

    [SerializeField]
    private GameObject[] food;
    // Start is called before the first frame update

    private void Start()
    {
        Food_Generate();
    }
    private void Food_Generate()
    {

        Vector2 last_position = new Vector2(0f,0f);
        int num = Random.Range(0, food.Length);
        for (int i = 0; i <= num; i++)
        {
            int index = Random.Range(0, food.Length);
            while (index == 2 && i > 0 || index == 1 && i > 0) { index = Random.Range(0, food.Length); }
            Vector2 position = GeneratePosition(last_position);
            GameObject obj = GameObject.Instantiate(food[index], position, Quaternion.identity, this.transform);
            //GameObject obj = GameObject.Instantiate(food[index], position, Quaternion.identity);
            if (index == 2) { break; }
        }
    }

    private Vector2 GeneratePosition(Vector2 last_postion)
    {

        collider = GetComponent<Collider2D>();
        Vector3 position = collider.bounds.center;
        Debug.Log("The bounds is " + position);
        Debug.Log("The range of x is " + collider.bounds.extents.x);
        Debug.Log("The range of x is " + collider.bounds.extents.y);
        position.x += Random.Range(-1f * collider.bounds.extents.x, collider.bounds.extents.x);
        position.y += Random.Range(-1f * collider.bounds.extents.y, collider.bounds.extents.y);

        //Try not to overlap the food
        while (Vector2.Distance(last_postion, position) < 0.3)
        {
            //position = this.transform.position;
            Debug.Log("Generate new position");
            position.x += Random.Range(-1f * collider.bounds.extents.x, collider.bounds.extents.x);
            position.y += Random.Range(-1f * collider.bounds.extents.y, collider.bounds.extents.y);
            //food_position.x = position.x + Random.Range(-1f * collider.bounds.extents.x, collider.bounds.extents.x);
            //food_position.y = position.y + Random.Range(-1f * collider.bounds.extents.y, collider.bounds.extents.y);
        }
        Debug.Log("The food position is " + position);
        return position;
    }
}
