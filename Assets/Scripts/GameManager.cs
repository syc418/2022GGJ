using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Game_Time;
    public GameObject Timer;
    private Slider timer;
    public List<GameObject> disable_objs;
    public GameObject boss;
    public GameObject food_temple_spawner;

    private bool isBossUp = false;


    // Start is called before the first frame update
    void Start()
    {
        timer = Timer.GetComponent<Slider>();
        timer.maxValue = Game_Time;
        timer.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer.value += Time.deltaTime;
        if(timer.value >= Game_Time && !isBossUp)
        {
            isBossUp = true;
            Boss();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Epilogue");
        //or loading the end scene
    }

    public void Boss()
    {
        GameObject obj = GameObject.Instantiate(boss, this.gameObject.transform.position, Quaternion.identity, this.transform);
        Destroy(Timer);
        DisableObjs();
        EnableFood();

    }

    public void DisableObjs()
    {
        foreach(GameObject i in disable_objs) { i.SetActive(false); }
    }

    public void EnableFood()
    {
        food_temple_spawner.SetActive(true);
    }
}
