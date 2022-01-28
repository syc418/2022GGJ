using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class input_system : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D player;
    private Playerinputs playerInputActions;
    private Vector2 movement;

    //dashing
    private bool is_dashing;
    [SerializeField]
    private float dash_amount;
    [SerializeField]
    private float dash_cooldown;
    private float dash_cooldown_timer = 0;
    [SerializeField]
    private Slider dash_bar_obj;

    //InVulnerable
    private PlayerInteract interact;
    [SerializeField]
    private float dash_InVulnerableTime;


    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();

        playerInputActions = new Playerinputs();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Dash.performed += Dash;

        interact = GetComponent<PlayerInteract>();
    }

    private void Update()
    {
        movement = playerInputActions.Player.Movement.ReadValue<Vector2>();

        dash_cooldown_timer -= Time.deltaTime;

        //update dash timer display
        if (dash_bar_obj)
        {
            dash_bar_obj.value += Time.deltaTime;
            if (dash_bar_obj.value >= dash_bar_obj.maxValue) 
            {
                //disable when full
                dash_bar_obj.gameObject.SetActive(false);
            }
        }

    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);

        if (is_dashing) 
        {
            player.MovePosition(player.position + movement * dash_amount);
            is_dashing = false;
        }
    }


    public void Dash(InputAction.CallbackContext context) 
    {
        if (dash_cooldown_timer <= 0)
        {
            is_dashing = true;
            dash_cooldown_timer = dash_cooldown;
            interact.SetInVulnerable(dash_InVulnerableTime);

            //show dash timer display
            if (dash_bar_obj) 
            {
                dash_bar_obj.gameObject.SetActive(true);
                dash_bar_obj.maxValue = dash_cooldown;
                dash_bar_obj.value = 0;
            }
        }
    }




}
