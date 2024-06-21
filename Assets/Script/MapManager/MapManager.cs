using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject levelSelectPanel;
    [SerializeField] GameObject characterSelect;

    public List<MapData> mapDatas;

    public GameObject mapHolderPerfab;
    public GameObject MapHolderTranform;

    public FindAllChildren findAllChildren;

    GameObject mapHolder;

    private void Start()
    {
        for (int i = 0; i < mapDatas.Count; i++)
        {
            mapHolder = Instantiate(mapHolderPerfab, MapHolderTranform.transform);
            mapHolder.GetComponent<SetMapHolder>().Set(mapDatas[i]);
        }

        findAllChildren.GetData();
    }

    public GameObject LevelSelectPanel()
    {
        return levelSelectPanel;
    }

    public GameObject CharacterSelect()
    {
        return characterSelect;
    }
}
