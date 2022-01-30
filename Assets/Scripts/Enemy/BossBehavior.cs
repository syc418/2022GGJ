using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    [SerializeField]
    private float attack_rate;
    private float attack_timer;

    [SerializeField]
    private float move_speed;
    private bool is_moving = false;

    [SerializeField]
    private UnityEvent attack;

    private Animator animator;

    [SerializeField]
    private DestroyableObstacle obstacle_script;
    [SerializeField]
    private Slider health_slider;

    [SerializeField]
    private float action_rate;
    private float action_timer;

    private Vector3 destination;
    private Rigidbody2D rb;

    private bool is_enraged;
    public List<GameObject> enrage_objs;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //update health
        health_slider.value = obstacle_script.health_max;
        health_slider.maxValue = obstacle_script.health_max;

        rb = GetComponent<Rigidbody2D>();

        is_enraged = false;
    }

    // Update is called once per frame
    void Update()
    {
        //attack periodically
        attack_timer -= Time.deltaTime;
        if (attack_timer <= 0) 
        {
            animator.SetTrigger("Attack");
            attack_timer = attack_rate;
        }
        //move
        action_timer -= Time.deltaTime;
        if (action_timer <= 0)
        {
            //random action
            int randomAction = Random.Range(0, 5);
            if (randomAction == 0)
            {
                //stay, do nothing
                animator.SetBool("IsMoving", false);
                is_moving = false;
                animator.SetTrigger("Pose");
            }
            else if (randomAction == 1)
            {
                //move
                animator.SetBool("IsMoving", true);
                is_moving = true;
                destination = new Vector3(Random.Range(-9f, 9f), Random.Range(1.5f, 3.5f), 0);
                while ((destination - transform.position).magnitude <= 5f) 
                {
                    destination = new Vector3(Random.Range(-9f, 9f), Random.Range(1.5f, 3.5f), 0);
                }
            }
            else if (randomAction == 2)
            {
                //teleport
                animator.SetBool("IsMoving", false);
                is_moving = false;
                destination = new Vector3(Random.Range(-9f, 9f), Random.Range(1.5f, 3.5f), 0);
                while ((destination - transform.position).magnitude <= 5f)
                {
                    destination = new Vector3(Random.Range(-9f, 9f), Random.Range(1.5f, 3.5f), 0);
                }
                animator.SetTrigger("Teleport");
            }
            action_timer = action_rate;
        }
        //move position
        if (is_moving) 
        {
            transform.position = Vector3.Lerp(transform.position, destination, move_speed * Time.deltaTime);
        }

        //update health
        health_slider.value = obstacle_script.health;

        //check enrage
        if (!is_enraged) 
        {
            if (obstacle_script.health <= (obstacle_script.health_max/2f)) 
            {
                animator.SetTrigger("Enrage");
                is_enraged = true;
            }
        }
    }

    public void Raise_Attack() 
    {
        attack.Invoke();
    }

    public void Make_Teleport() 
    {
        transform.position = destination;
        destination = transform.position;
    }

    private void OnDestroy()
    {
        //when boss is killed, go to end scene
        Debug.Log("Win.");
    }

    public void Enrage() 
    {
        attack_rate = 12f;
        action_rate = 3f;
        foreach (GameObject obj in enrage_objs) 
        {
            obj.SetActive(true);
        }
    }

}
