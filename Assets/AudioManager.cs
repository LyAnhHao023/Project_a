using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----AudioGameObject-----")]

    [SerializeField] AudioSource backGroundMusicSource;
    [SerializeField] AudioSource SFX;

    [Header("-----AudioClipGamePlay-----")]
    public AudioClip Background;
    public AudioClip LevelUp;
    public AudioClip Lose;
    public AudioClip Win;
    public AudioClip PickUpExp;
    public AudioClip PickUpHeath;
    public AudioClip PickUpCoin;
    public AudioClip TakeDmg;
    public AudioClip Warning;

    [Header("-----AudioClipWeapon-----")]
    public AudioClip Axe;
    public AudioClip Gun;
    public AudioClip Bomb;
    public AudioClip HolyBeam;
    public AudioClip Shuriken;
    public AudioClip WallSpike;
    public AudioClip ToxinZone;

    [Header("-----AudioClipWeapon-----")]
    public AudioClip BoombBat;
    public AudioClip WildBoar;

    // Start is called before the first frame update
    void Start()
    {
        backGroundMusicSource.clip = Background;
        backGroundMusicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        SFX.PlayOneShot(audioClip);
    }
}
