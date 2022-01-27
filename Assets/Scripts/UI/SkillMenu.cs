using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : MonoBehaviour
{
    // SkillObject firstSkill
    // SkillObject secondSkill
    public void OpenSkillMenu()
    {
        // Pause Game
        gameObject.SetActive(true);
    }

    public void SelectFirstSkill()
    {
        // firstSkill.EnableSkill();
        Debug.Log("SelectFirstSkill");
        Animator animator = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        animator.SetBool("Opened", false);
    }

    public void SelectSecondSkill()
    {
        // secondSkill.EnableSkill();
        Debug.Log("SelectSecondSkill");
        Animator animator = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));
        animator.SetBool("Opened", false);
    }

    void Update()
    {
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));
        if (animator1.GetCurrentAnimatorStateInfo(0).IsName("idle_SkillCard") ||
            animator2.GetCurrentAnimatorStateInfo(0).IsName("idle_SkillCard"))
        {
            gameObject.SetActive(false);
        }
        // Resume Game
    }
}
