using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail_Pool : ObjectPool
{
    public static BulletTrail_Pool _this;

    private void Start()
    {
        _this = this;
    }

    public override void ExtraWork(GameObject obj)
    {
        //obj.GetComponent<BulletTrail>()
    }
}
