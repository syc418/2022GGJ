using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Pool : ObjectPool
{
    public static EnemyBullet_Pool _this;

    private void Start()
    {
        _this = this;
    }

    public override void ExtraWork(GameObject obj)
    {
        //obj.GetComponent<EnemyBullet>()
    }
}
