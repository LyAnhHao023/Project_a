using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SetMapHolder : MonoBehaviour
{
    [SerializeField] Button MapHolder;
    [SerializeField] Text Name;
    [SerializeField] GameObject lockHolder;

    MainMenu menu;

    private MapManager mapManager;
    private GameObject LevelSelect;
    private GameObject SelectCharacter;

    MapData mapData;

    private void Awake()
    {
        mapManager = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
        menu = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();

        LevelSelect = mapManager.LevelSelectPanel();
        SelectCharacter = mapManager.CharacterSelect();

        MapHolder.onClick.AddListener(Onclick);
    }

    public void Set(MapData data)
    {
        MapHolder.image.sprite = data.Icon;
        Name.text = data.Name.ToUpper();
        mapData = data;
        lockHolder.SetActive(!data.unlocked);
        MapHolder.enabled = data.unlocked;
    }

    void Onclick()
    {
        LevelSelect.SetActive(false);
        SelectCharacter.SetActive(true);
        menu.SetMapData(mapData);
    }
}
