using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShenQingRuYan : Skill
{
    public GameObject player;
    // public string name = "ShenQingRuYan";
    // public string text = "Decrease Dash Cooldown";

    public override void Select()
    {
        player.GetComponent<input_system>().dash_cooldown = 1.5f;
    }

    void Start()
    {
        // name = "ShenQingRuYan.png";
        text = "Decrease Dash Cooldown";
    }
}
