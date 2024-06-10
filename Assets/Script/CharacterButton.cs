using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] Image CharacterImage;
    [SerializeField] Text Name;

    public void Set(CharacterData characterData)
    {
        CharacterImage.sprite = characterData.image;
        Name.text = characterData.name;
    }
}
