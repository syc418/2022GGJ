using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField]
    private float _scroll_speed;

    [SerializeField]
    private bool _auto_start = true;

    [SerializeField]
    private bool is_scrolling = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_auto_start)
        {
            Start_Scrolling();
        }
    }

    private void Start()
    {
        if (is_scrolling)
        {
            _rb.velocity = new Vector2(0, _scroll_speed);
        }
        else 
        {
            _rb.velocity = Vector2.zero;
        }
    }

    public void Stop_Scrolling() 
    {
        is_scrolling = false;
    }

    public void Start_Scrolling()
    {
        is_scrolling = true;
    }
}
