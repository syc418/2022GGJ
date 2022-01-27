using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyControl : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] obstacles;
    // Update is called once per frame
    void Update()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            Debug.Log(child.gameObject.name);
            Debug.Log(allChildren.Length);
            //child.gameObject.SetActive(false);
        }
        if (allChildren.Length == 1)
        {
            Debug.Log("all destroyed");
            //obstacles are destroyed instead of exploding itself.
            gameObject.SetActive(false);
        }
        
    }
}
