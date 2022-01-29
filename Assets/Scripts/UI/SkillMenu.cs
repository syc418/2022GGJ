using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : MonoBehaviour
{
    // SkillObject firstSkill
    // SkillObject secondSkill
    public GameObject pauseMenuController;

    public void OpenSkillMenu()
    {
        // Pause Game
        pauseMenuController.GetComponent<PauseMenu>().PauseGame();
        gameObject.SetActive(true);
    }

    public void SelectFirstSkill()
    {
        // firstSkill.EnableSkill();
        Debug.Log("SelectFirstSkill");
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));


        animator1.SetBool("Selected", true);
        animator2.SetBool("Selected", false);

        animator1.SetBool("Opened", false);
        animator2.SetBool("Opened", false);
        
    }

    public void SelectSecondSkill()
    {
        // secondSkill.EnableSkill();
        Debug.Log("SelectSecondSkill");
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));

        animator1.SetBool("Selected", false);
        animator2.SetBool("Selected", true);

        animator1.SetBool("Opened", false);
        animator2.SetBool("Opened", false);
        
    }

    void Update()
    {
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));
        if (animator1.GetCurrentAnimatorStateInfo(0).IsName("idle_SkillCard") &&
            animator2.GetCurrentAnimatorStateInfo(0).IsName("idle_SkillCard"))
        {
            gameObject.SetActive(false);
            pauseMenuController.GetComponent<PauseMenu>().ResumeGame();
        }
    }
}
