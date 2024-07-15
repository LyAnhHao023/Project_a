using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCollabAcceptButton : MonoBehaviour
{
    [SerializeField] GameObject Overlay;
    [SerializeField] Button AcceptButton;
    [SerializeField] GameObject ColabResultUI;
    [SerializeField] AnvilCollabResult setColabResult;

    [SerializeField] List<UpgradeData> colabList;

    private UpgradeData data1;
    private UpgradeData data2;
    private UpgradeData colabResult;

    private void Start()
    {
        AcceptButton.onClick.AddListener(Onclick);
    }

    private void Update()
    {
        CheckColab();
    }

    public void SetData(UpgradeData data)
    {
        if(data1 == null)
        {
            this.data1 = data;
        }
        else if(data2 == null)
        {
            this.data2 = data;
        }

        CheckColab();
    }

    public void RemoveData(UpgradeData data)
    {
        if(data1 != null)
        {
            if (data.weaponData == data1.weaponData/* || data.itemsData.name == data1.itemsData.name*/)
            {
                data1 = null;
            }
        }
        
        if(data2 != null)
        {
            if (data.weaponData == data2.weaponData/* || data.itemsData.name == data2.itemsData.name*/)
            {
                data2 = null;
            }
        }

        colabResult = null;
        Overlay.SetActive(false);
    }

    public void CheckColab()
    {
        if(data1 != null && data2 != null)
        {
            UpgradeData data = null;

            data = colabList.Find(item => item.colabInfo.weapon1 == data1.weaponData || item.colabInfo.weapon2 == data1.weaponData);

            if(data != null)
            {
                if(data.colabInfo.weapon1 == data2.weaponData || data.colabInfo.weapon2 == data2.weaponData)
                {
                    colabResult = data;

                    Overlay.SetActive(false);
                }
            }
        }
    }

    void Onclick()
    {
        ColabResultUI.SetActive(true);
        setColabResult.Set(colabResult);
    }
}
