using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharManager : MonoBehaviour
{
    [SerializeField] List<CharacterData> characterDatas;

    [SerializeField] List<CharacterButton> characterButtons;

    private void Start()
    {
        for (int i = 0; i < characterDatas.Count; i++)
        {
            characterButtons[i].Set(characterDatas[i]);
        }
    }

    public void Select(int id)
    {
        StaticData.SelectedCharacter = characterDatas[id];
    }
}
