using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject object_prefab;
    [SerializeField]
    private int prewarm_amount;

    private Queue<GameObject> object_pool;

    private void Awake()
    {
        object_pool = new Queue<GameObject>();
        for (int i = 0; i < prewarm_amount; i++) 
        {
            GameObject obj = GameObject.Instantiate(object_prefab, this.transform);
            object_pool.Enqueue(obj);
            obj.SetActive(false);

        }
    }

    public GameObject Get(Vector3 position, Quaternion rotation, Transform parent) 
    {
        GameObject return_object;
        if (object_pool.Count > 0)
        {
            return_object = object_pool.Dequeue();

            //update pos, rotation, parent
            return_object.SetActive(true);
            return_object.transform.position = position;
            return_object.transform.rotation = rotation;
            return_object.transform.SetParent(parent);

        }
        else 
        {
            //create one of none avaliable
            return_object = GameObject.Instantiate(object_prefab);
            return_object.SetActive(true);
            return_object.transform.position = position;
            return_object.transform.rotation = rotation;
            return_object.transform.SetParent(parent);
        }

        //do the extra work if needed
        ExtraWork(return_object);

        return return_object;
    }

    public void Return(GameObject gameObject) 
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(this.transform);

        object_pool.Enqueue(gameObject);
    }

    public virtual void ExtraWork(GameObject obj) 
    {
        //do nothing by default
    }
}
