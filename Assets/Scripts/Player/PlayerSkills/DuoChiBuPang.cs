using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoChiBuPang : Skill
{
    public GameObject player;

    public override void Select()
    {
        player.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
    }
}
