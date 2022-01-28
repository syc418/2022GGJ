using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratio_Spawner : MonoBehaviour
{
    public List<GameObject> obj_prefabs;
    public List<int> percentage;

    public float spawn_speed;
    private float spawn_speed_timer;

    private BoxCollider2D collider;

    public GameObject parent;

    

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        spawn_speed_timer = spawn_speed;

    }

    private void Update()
    {
        if (spawn_speed_timer <= 0)
        {
            float num = Random.Range(0f, 1f);
            num *= 100;
            if (0 <= num && num <= percentage[0]) { SpawnObj(obj_prefabs[0]); }
            else if (num > percentage[0] && num <= percentage[0] + percentage[1]) {SpawnObj(obj_prefabs[1]); }
            else if (num > percentage[1] + percentage[2] && num <= percentage[0] + percentage[1] + percentage[2]) {  SpawnObj(obj_prefabs[2]); }
        }
        else
        {
            spawn_speed_timer -= Time.deltaTime;
        }

    }

    private void SpawnObj(GameObject obj_prefab)
    {
        //spawn obj in random position within area
        Vector3 position = collider.bounds.center;
        position.x += Random.Range(-1f * collider.bounds.extents.x, collider.bounds.extents.x);
        position.y += Random.Range(-1f * collider.bounds.extents.y, collider.bounds.extents.y);
        GameObject obj = GameObject.Instantiate(obj_prefab, position, Quaternion.identity, this.transform);
        obj.transform.SetParent(parent.transform);
        //reset timer
        spawn_speed_timer = spawn_speed;
    }
}
