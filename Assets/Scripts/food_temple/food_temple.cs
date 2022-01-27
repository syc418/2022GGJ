using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_temple : MonoBehaviour
{
    public float disapear_time = 5f;
    private SpriteRenderer foodtemple;
    //public GameObject foodgenerator;
    // Start is called before the first frame update
    void Start()
    {
        foodtemple = GetComponent<SpriteRenderer>();
         
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -8)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnEnable()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(disapear_time);
        this.GetComponent<Animator>().enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //GameObject obj = GameObject.Instantiate(foodgenerator, this.transform.position, Quaternion.identity, this.transform);
        //this.GetComponent<FoodShowUp>().ShowUpFood(this.transform.position);
    }

    public void StopDisappearAnimator()
    {
        this.GetComponent<Animator>().enabled = false;
        foodtemple.enabled = false;
    }
}
