using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    private float current_health;
    private float last_health;
    private bool isDecreasing = false;
    private bool level1 = false;
    private bool level2 = false;
    private bool level3 = false;
    private GameObject GM;
    private List<int> thresholds;

    public Slider health;
    public bool iseat = false;
    public float startcheck = 3f;
    public float checkrate = 2f;
    public float decreasing_ratio = 1.5f;

    public GameObject playerskill;

    

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager");
        current_health = health.value;
        last_health = health.value;
        InvokeRepeating("decrease_health", startcheck, checkrate);
        thresholds = new List<int> { 70, 120, 200 };
        
    }

    // Update is called once per frame
    void Update()
    {
        current_health = health.value;
        
        if (current_health <= 0) { GM.GetComponent<GameManager>().GameOver(); }

        if (isDecreasing) { health.value -= decreasing_ratio * Time.deltaTime; }

        if (iseat) { isDecreasing = false; }
        
        if (current_health >= thresholds[0] && !level1)
        {
            //reach 70, make a choice
            skill();
            health.maxValue = thresholds[1];
            health.GetComponent<RectTransform>().sizeDelta = new Vector2(240f, 20f);
            level1 = true;
        }

        if(current_health >= thresholds[1] && !level2)
        {
            //reach 120, make a choice
            skill();
            health.maxValue = thresholds[2];
            health.GetComponent<RectTransform>().sizeDelta = new Vector2(400f, 20f);
            level2 = true;
        }

        if (current_health >= thresholds[2] && !level3)
        {
            //reach 200, make a choice
            skill();
            // health.maxValue = 200;
            health.GetComponent<RectTransform>().sizeDelta = new Vector2(640f, 20f);
            level3 = true;
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

    private void skill()
    {
        playerskill.GetComponent<SkillMenu>().OpenSkillMenu();
    }
}