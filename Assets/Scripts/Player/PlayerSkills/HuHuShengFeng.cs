using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuHuShengFeng : Skill
{
    public GameObject player;

    public override void Select()
    {
        player.GetComponent<input_system>().speed = 13;
    }
}
