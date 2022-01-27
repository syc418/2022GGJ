using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject prologue1;
    public GameObject prologue2;
    public GameObject prologue3;

    public void NewGame()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void NextScene(GameObject currentScene)
    {
        currentScene.SetActive(false);
    }
}
