using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _size_reference;

    // Start is called before the first frame update
    void Start()
    {
        float screen_ratio = (float) Screen.width / (float) Screen.height;
        float reference_ratio = _size_reference.bounds.size.x / _size_reference.bounds.size.y;

        if (screen_ratio >= reference_ratio)
        {
            Camera.main.orthographicSize = _size_reference.bounds.size.y / 2;
        }
        else 
        {
            float differentInSize = reference_ratio / screen_ratio;
            Camera.main.orthographicSize = _size_reference.bounds.size.y / 2 * differentInSize;
        }
    }
}
