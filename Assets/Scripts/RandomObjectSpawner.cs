using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public List<GameObject> obj_prefabs;

    public float spawn_speed;
    private float spawn_speed_timer;

    public GameObject parent;
    private GameObject obj;

    public bool is_active = true;

    private int last_index = -1;


    private void Update()
    {
        if (is_active) 
        {
            if (spawn_speed_timer <= 0)
            {
                Spawn();
                //reset timer
                spawn_speed_timer = spawn_speed;
            }
            else
            {
                spawn_speed_timer -= Time.deltaTime;
            }
        }
    }

    public void Spawn() 
    {
        //spawn random obj at position (0,0,0)
        int index = Random.Range(0, obj_prefabs.Count);

        //never repeat
        while (index == last_index) 
        {
            index = Random.Range(0, obj_prefabs.Count);
        }
        last_index = index;

        //kill existing one if left out
        if (obj) Destroy(obj.gameObject);
        obj = GameObject.Instantiate(obj_prefabs[index], transform.position, Quaternion.identity, this.transform);
        if (parent) obj.transform.SetParent(parent.transform);

    }
}
