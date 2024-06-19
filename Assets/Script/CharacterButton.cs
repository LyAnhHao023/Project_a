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

    float timer = 5;

    private CharacterData CharData;

    bool stand;

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
        stand = true;
    }

    private void Update()
    {
        if (CharData != null)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timer = Random.Range(3, 6);
                stand = !stand;
                spriteToUIImage.SetAnimation(stand);
            }
        }
    }
}
