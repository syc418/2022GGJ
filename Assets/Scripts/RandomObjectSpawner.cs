using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public List<GameObject> obj_prefabs;

    public float spawn_speed;
    private float spawn_speed_timer;

    public GameObject parent;
    public GameObject obj;

    private void Update()
    {
        if (spawn_speed_timer <= 0)
        {
            //spawn random obj at position (0,0,0)
            int index = Random.Range(0, obj_prefabs.Count);

            //kill existing one if left out
            if (obj) Destroy(obj.gameObject);
            obj = GameObject.Instantiate(obj_prefabs[index], transform.position, Quaternion.identity, this.transform);
            if(parent) obj.transform.SetParent(parent.transform);

            //reset timer
            spawn_speed_timer = spawn_speed;

        }
        else
        {
            spawn_speed_timer -= Time.deltaTime;
        }

        //TO DO : destory object when it is out of sight
    }
}
