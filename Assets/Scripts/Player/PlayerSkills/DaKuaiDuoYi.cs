using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaKuaiDuoYi : Skill
{
    public GameObject player;

    public override void Select()
    {
        player.GetComponent<PlayerInteract>().health_ratio = 1.3f;
    }
}
