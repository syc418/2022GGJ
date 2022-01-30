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

    private List<int> skillList;
    private GameObject firstSkill;
    private GameObject secondSkill;

    public void OpenSkillMenu()
    {
        gameObject.SetActive(true);

        if (skillList.Count < 2)
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
        gameObject.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = firstSkill.GetComponent<Skill>().name;

        gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = secondSkill.GetComponent<Skill>().text;
        gameObject.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = secondSkill.GetComponent<Skill>().name;

        EnableText();

        // gameObject.SetActive(true);
    }

    public void SelectFirstSkill()
    {
        firstSkill.GetComponent<Skill>().Select();
        // gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = firstSkill.GetComponent<Skill>().text;
        skillList.RemoveAt(0);
        DisableText();

        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = firstSkill.GetComponent<Skill>().text;
        gameObject.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = firstSkill.GetComponent<Skill>().name;

        gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = secondSkill.GetComponent<Skill>().text;
        gameObject.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = secondSkill.GetComponent<Skill>().name;

        // Debug.Log("SelectFirstSkill");
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));
        Animator nameAnimator1 = (Animator)gameObject.transform.GetChild(1).GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator nameAnimator2 = (Animator)gameObject.transform.GetChild(2).GetChild(1).gameObject.GetComponent(typeof(Animator));

        animator1.SetBool("Selected", true);
        animator2.SetBool("Selected", false);
        nameAnimator1.SetBool("Selected", true);
        nameAnimator2.SetBool("Selected", false);

        animator1.SetBool("Opened", false);
        animator2.SetBool("Opened", false);
        nameAnimator1.SetBool("Opened", false);
        nameAnimator2.SetBool("Opened", false);

    }

    public void SelectSecondSkill()
    {
        secondSkill.GetComponent<Skill>().Select();
        // gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = firstSkill.GetComponent<Skill>().text;
        skillList.RemoveAt(1);
        DisableText();
        // Debug.Log("SelectSecondSkill");
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));
        Animator nameAnimator1 = (Animator)gameObject.transform.GetChild(1).GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator nameAnimator2 = (Animator)gameObject.transform.GetChild(2).GetChild(1).gameObject.GetComponent(typeof(Animator));

        animator1.SetBool("Selected", false);
        animator2.SetBool("Selected", true);
        nameAnimator1.SetBool("Selected", false);
        nameAnimator2.SetBool("Selected", true);

        animator1.SetBool("Opened", false);
        animator2.SetBool("Opened", false);
        nameAnimator1.SetBool("Opened", false);
        nameAnimator2.SetBool("Opened", false);

    }

    private void DisableText()
    {
        gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

        gameObject.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
    }

    private void EnableText()
    {
        gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);

        gameObject.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
    }

    void Update()
    {
        if (gameObject.name == "PauseMenu")
            return;
        Animator animator1 = (Animator)gameObject.transform.GetChild(1).gameObject.GetComponent(typeof(Animator));
        Animator animator2 = (Animator)gameObject.transform.GetChild(2).gameObject.GetComponent(typeof(Animator));
        if (animator1.GetCurrentAnimatorStateInfo(0).IsName("idle_SkillCard") &&
            animator2.GetCurrentAnimatorStateInfo(0).IsName("idle_SkillCard"))
        {
            gameObject.SetActive(false);
            pauseMenuController.GetComponent<PauseMenu>().ResumeGame();
        }
    }

    void Awake()
    {
        if(skillList == null)
        {
            skillList = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
        }
    }
}
