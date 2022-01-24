using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleSmall_Pool : ObjectPool
{
    public static ExplosionParticleSmall_Pool _this;

    public float particle_lifeTime;

    private void Start()
    {
        _this = this;
    }

    public override void ExtraWork(GameObject obj)
    {
        //obj.GetComponent<ExplosionParticleSmall_Pool>()
    }
}
