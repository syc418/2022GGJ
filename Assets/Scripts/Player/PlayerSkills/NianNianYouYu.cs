using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NianNianYouYu : Skill
{
    public GameObject health;

    public override void Select()
    {
        health.GetComponent<Health>().decreasing_ratio = 4;
    }
}
