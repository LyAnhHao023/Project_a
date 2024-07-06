using NUnit.Compatibility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnvilUpgradeResult : MonoBehaviour
{
    [SerializeField] Text BuffResult;
    [SerializeField] Text ResultsText;
    [SerializeField] GameObject ResultText;
    [SerializeField] GameObject ResultButton;
    [SerializeField] GameObject ImageAnimation;
    [SerializeField] Animator animator;
    [SerializeField] Image BuffIcon;
    [SerializeField] CharacterInfo_1 Character;

    UpgradeData data;
    bool result;
    int upgradePrice;
    bool type;

    private void Start()
    {
        ResultText.SetActive(false);
        ResultButton.SetActive(false);
        ImageAnimation.SetActive(true);
    }

    public void Set(UpgradeData upgradeData, int succesed, bool type, int prices)
    {
        data = upgradeData;
        result = succesed == 0 ? true : false;
        upgradePrice = prices;
        this.type = type;

        BuffIcon.sprite = upgradeData.icon;

        if(result)
        {
            Character.AddUpgrade(data, type);
        }

        StartCoroutine(WaitForAnimationEnd());
    }

    private IEnumerator WaitForAnimationEnd()
    {
        animator.SetBool("Upgrade", true);

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("UpgradeAnimation"))
        {
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        animator.SetBool("Upgrade", false);
        ImageAnimation.SetActive(false);

        SetResult();
    }

    private void SetResult()
    {
        if (result)
        {
            Character.coins -= upgradePrice;
        }

        ResultsText.text = result ? "THÀNH CÔNG" : "THẤT BẠI";
        BuffResult.text = string.Format("{0} Lv.{1}", data.name, data.level);
        ResultText.SetActive(true);
        ResultButton.SetActive(true);
    }
}
