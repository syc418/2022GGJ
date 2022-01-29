using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject health;
    public GameObject player;

    public void NianNianYouYu()
    {
        health.GetComponent<Health>().decreasing_ratio = 4;
    }

    public void HuHuShengFeng()
    {
        player.GetComponent<input_system>().speed = 13;
    }

    public void DaKuaiDuoYi()
    {
        player.GetComponent<PlayerInteract>().health_ratio = 1.3f;
    }

    public void TongPiTieGu()
    {
        player.GetComponent<PlayerInteract>().damage_ratio = 0.7f;
    }

    public void ZheTianBiRi()
    {
        player.transform.GetChild(0).gameObject.GetComponent<PlayerAttack>().bullet_damage = 1.5f;
        player.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);

    }

    public void ShenQingRuYan()
    {
        player.GetComponent<input_system>().dash_cooldown = 1.5f;
    }

    public void DuoChiBuPang()
    {
        player.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
    }

    void Start()
    {
        // NianNianYouYu();
        // HuHuShengFeng();
    }
}
