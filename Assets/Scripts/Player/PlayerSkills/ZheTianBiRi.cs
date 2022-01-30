using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZheTianBiRi : Skill
{
    public GameObject player;
    // public string name = "NianNianYouYu";
    // public string text = "Damage Up";

    public override void Select()
    {
        player.transform.GetChild(0).gameObject.GetComponent<PlayerAttack>().bullet_damage = 1.5f;
        player.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
    }

    void Start()
    {
        // name = "ZheTianBiRi.png";
        text = "Damage Up";
    }
}
