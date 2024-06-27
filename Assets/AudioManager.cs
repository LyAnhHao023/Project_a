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

    // Start is called before the first frame update
    void Start()
    {
        backGroundMusicSource.clip = Background;
        backGroundMusicSource.Play();
    }
}
