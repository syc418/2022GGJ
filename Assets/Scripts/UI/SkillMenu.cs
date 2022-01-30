using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    // SkillObject firstSkill
    // SkillObject secondSkill
    public GameObject pauseMenuController;
    public GameObject playerSkillController;

    private List<int> skillList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
    private GameObject firstSkill;
    private GameObject secondSkill;

    public void OpenSkillMenu()
    {
        if(skillList.Count < 2)
        {
            // Only one skill left
            return;
        }

        pauseMenuController.GetComponent<PauseMenu>().PauseGame();
        for(int i = 0; i < 2; ++i) 
        {
            int temp = skillList[i];
            int random_num = Random.Range(i, skillList.Count);
            skillList[i] = skillList[random_num];
            skillList[random_num] = temp;
        }
        firstSkill = playerSkillController.transform.GetChild(skillList[0]).gameObject;
        secondSkill = playerSkillController.transform.GetChild(skillList[1]).gameObject;

        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = firstSkill.GetComponent<Skill>().text;
        gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = secondSkill.GetComponent<Skill>().text;

        gameObject.SetActive(true);
    }

    public void SelectFirstSkill()
    {
        firstSkill.GetComponent<Skill>().Select();
        // gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = firstSkill.GetComponent<Skill>().text;
        skillList.RemoveAt(0);
        
        // Debug.Log("SelectFirstSkill");
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));


        animator1.SetBool("Selected", true);
        animator2.SetBool("Selected", false);

        animator1.SetBool("Opened", false);
        animator2.SetBool("Opened", false);
        
    }

    public void SelectSecondSkill()
    {
        secondSkill.GetComponent<Skill>().Select();
        // gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = firstSkill.GetComponent<Skill>().text;
        skillList.RemoveAt(1);
        // Debug.Log("SelectSecondSkill");
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
