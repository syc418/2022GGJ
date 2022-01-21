using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingScrolling : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D _boxCollider;

    private float _background_size;

    // Start is called before the first frame update
    void Start()
    {
        _background_size = _boxCollider.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1f * _background_size) 
        {
            RepeatBackground();
        }
    }

    void RepeatBackground() 
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f * _background_size, transform.position.z);
    }
}
