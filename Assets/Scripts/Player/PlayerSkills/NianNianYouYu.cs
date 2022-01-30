using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NianNianYouYu : Skill
{
    public GameObject health;
    // public string name = "NianNianYouYu";
    // public string text = "Increase Satiety Value";

    public override void Select()
    {
        health.GetComponent<Health>().decreasing_ratio = 4;
    }

    void Start()
    {
        // name = "NianNianYouYu.png";
        text = "Increase Satiety Value";
    }
}
