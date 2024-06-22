using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownUI : MonoBehaviour
{
    [SerializeField] Image cooldown;
    [SerializeField] Image skillIcon;

    float cooldownTimer;
    float cooldownTime;

    private void Update()
    {
        ApplyCooldown();
    }

    public void SetCooldown(float time)
    {
        cooldownTime = time;
        cooldownTimer = time;
        cooldown.fillAmount = cooldownTimer;
    }

    public void SetSkillInfo(SkillInfo skillInfo)
    {
        skillIcon.sprite = skillInfo.Icon;
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0 )
        {
            cooldown.fillAmount = 0;
        }
        else
        {
            cooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }
}
