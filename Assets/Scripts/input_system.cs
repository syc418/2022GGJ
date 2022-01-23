using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input_system : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D player;
    private PlayerInput playerinput;
    private Playerinputs playerInputActions;
    private Vector2 movement;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        playerinput = GetComponent<PlayerInput>();

        playerInputActions = new Playerinputs();
        playerInputActions.Player.Enable();

    }

    private void Update()
    {
        movement = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
    }

}
