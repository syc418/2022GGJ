using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public float recovery;

    private void Update()
    {
        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }
}
