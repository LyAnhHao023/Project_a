using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SetMapHolder : MonoBehaviour
{
    [SerializeField] Button MapHolder;
    [SerializeField] Text Name;

    MainMenu menu;

    private MapManager mapManager;
    private GameObject LevelSelect;
    private GameObject SelectCharacter;

    SceneAsset asset;

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
        asset = data.Map;
    }

    void Onclick()
    {
        LevelSelect.SetActive(false);
        SelectCharacter.SetActive(true);
        menu.sceneAsset(asset);
    }
}
