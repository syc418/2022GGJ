using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaKuaiDuoYi : Skill
{
    public GameObject player;
    // public string name = "DaKuaiDuoYi";
    // public string text = "Food Becomes More Delicious";

    public override void Select()
    {
        player.GetComponent<PlayerInteract>().health_ratio = 1.3f;
    }

    void Start()
    {
        // name = "DaKuaiDuoYi.png";
        text = "Food Becomes More Delicious";
    }
}
