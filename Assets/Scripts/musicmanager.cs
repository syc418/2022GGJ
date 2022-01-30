using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour
{
    private GameObject[] respawns;
    private void Awake()
    {
        respawns = GameObject.FindGameObjectsWithTag("music");
        if (respawns.Length > 0)
        {
            Destroy(respawns[0]);
        }
    }
}
