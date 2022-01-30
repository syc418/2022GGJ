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

    public GameObject win;
    public GameObject lose;
    public GameObject exit;
    public GameObject restart;

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
        lose.SetActive(true);
        exit.SetActive(true);
        restart.SetActive(true);
    }

    public void WinGame()
    {
        win.SetActive(true);
        exit.SetActive(true);
        restart.SetActive(true);
    }
    public void Boss()
    {
        GameObject obj = GameObject.Instantiate(boss, this.gameObject.transform.position, Quaternion.identity, this.transform);
        Destroy(Timer);
        DisableObjs();
        food_temple_spawner.SetActive(true);

    }

    public void DisableObjs()
    {
        foreach(GameObject i in disable_objs) { i.SetActive(false); }
    }


    public void EndGame()
    {
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
