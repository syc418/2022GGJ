using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject obj_prefab;

    public float spawn_speed;
    private float spawn_speed_timer;

    private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (spawn_speed_timer <= 0)
        {
            //spawn obj in random position within area
            Vector3 position = collider.bounds.center;
            position.x += Random.Range(-1f * collider.bounds.extents.x, collider.bounds.extents.x);
            position.y += Random.Range(-1f * collider.bounds.extents.y, collider.bounds.extents.y);
            GameObject obj = GameObject.Instantiate(obj_prefab, position, Quaternion.identity, this.transform);
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
