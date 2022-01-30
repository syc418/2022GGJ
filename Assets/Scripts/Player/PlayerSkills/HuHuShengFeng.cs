using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuHuShengFeng : Skill
{
    public GameObject player;
    // public string name = "HuHuShengFeng";
    // public string text = "Speed Up";

    public override void Select()
    {
        player.GetComponent<input_system>().speed = 13;
    }

    void Start()
    {
        name = "HuHuShengFeng";
        text = "Speed Up";
    }
}
