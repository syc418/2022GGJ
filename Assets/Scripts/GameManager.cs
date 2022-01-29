using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float Game_Time;
    public Slider timer;
    public List<GameObject> disable_objs;


    // Start is called before the first frame update
    void Start()
    {
        timer.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer.value += Time.deltaTime;
        if(timer.value == Game_Time)
        {
            Boss();
        }
    }

    public void GameOver()
    {
        Application.Quit();
        //or loading the end scene
    }

    public void Boss()
    {
        //call boss function
    }

    public void DisableObjs()
    {
        foreach(GameObject i in disable_objs) { i.SetActive(true); }
    }

    public void EnableObjs()
    {
        foreach (GameObject i in disable_objs) { i.SetActive(false); }
    }
}
