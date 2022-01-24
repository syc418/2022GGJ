using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle_Pool : ObjectPool
{
    public static ExplosionParticle_Pool _this;

    public float particle_lifeTime;

    private void Start()
    {
        _this = this;
    }

    public override void ExtraWork(GameObject obj)
    {
        //obj.GetComponent<ExplosionParticle_Pool>()
    }
}
