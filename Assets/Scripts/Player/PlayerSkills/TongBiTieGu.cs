using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongBiTieGu : Skill
{
    public GameObject player;

    public override void Select()
    {
        player.GetComponent<PlayerInteract>().damage_ratio = 0.7f;
    }
}
