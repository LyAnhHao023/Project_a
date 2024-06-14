using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] Image CharacterImage;
    [SerializeField] GameObject CharacterOverlay;
    [SerializeField] GameObject CharButton;
    [SerializeField] Text Name;
    [SerializeField] SpriteToUIImage spriteToUIImage;

    private CharacterData CharData;

    public void Set(CharacterData characterData)
    {
        CharacterImage.sprite = characterData.image;
        CharacterOverlay.SetActive(!characterData.acquired);
        CharButton.GetComponent<Button>().enabled = characterData.acquired;
        CharData = characterData;
    }

    public void SetCharacter()
    {
        Name.text = CharData.name;
        spriteToUIImage.SetCharacterAnimation(CharData.animatorPrefab.GetComponent<SpriteRenderer>());
    }
}
