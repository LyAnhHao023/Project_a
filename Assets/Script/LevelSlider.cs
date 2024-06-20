using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPageRect;

    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;

    public GameObject MapButton;
    public FindAllChildren findAllChildren;

    List<GameObject> MapButtonList;

    private void Awake()
    {
        findAllChildren = MapButton.GetComponent<FindAllChildren>();

        MapButtonList = findAllChildren.characterHolder();

        currentPage = 1;
        targetPos = levelPageRect.localPosition;
    }

    private void Start()
    {
        maxPage = MapButtonList.Count;
        SetButton();
    }

    public void SetButton()
    {
        for (int i = 0; i < MapButtonList.Count; i++)
        {
            if (currentPage - 1 == i)
                MapButtonList[i].GetComponentInParent<Button>().enabled = true;
            else
                MapButtonList[i].GetComponentInParent<Button>().enabled = false;
        }
    }

    public void Next()
    {
        if(currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }
    public void Previous()
    {
        if(currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        SetButton();
        levelPageRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }
}
