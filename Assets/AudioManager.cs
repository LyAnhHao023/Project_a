using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----AudioClip-----")]

    [SerializeField] AudioSource backGroundMusicSource;
    [SerializeField] AudioSource SFX;

    [Header("-----AudioClip-----")]
    public AudioClip Background;
    public AudioClip LevelUp;
    public AudioClip Lose;
    public AudioClip Win;
    public AudioClip PickUpExp;
    public AudioClip PickUpHeath;
    public AudioClip PickUpCoin;
    public AudioClip TakeDmg;

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
