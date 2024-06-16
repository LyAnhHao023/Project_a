﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteToUIImage : MonoBehaviour
{
    public Image uiImage;

    private Animator spriteAnimator;
    private Animator uiAnimator;

    public void SetCharacterAnimation(SpriteRenderer spriteRenderer)
    {
        spriteAnimator = spriteRenderer.GetComponent<Animator>();
        uiAnimator = uiImage.GetComponent<Animator>();

        uiAnimator.runtimeAnimatorController = spriteAnimator.runtimeAnimatorController;
    }
}

