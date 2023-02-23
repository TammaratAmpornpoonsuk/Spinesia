using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Collider2D jellyFishCol;
    [SerializeField] private GameObject day;
    [SerializeField] private GameObject night;
    private bool playBGM2;

    void Start()
    {
        SoundManager.instance.Play(SoundManager.SoundName.BGM1);
        playBGM2 = true;
        day.SetActive(true);
    }

    void Update()
    {
        if(jellyFishCol.enabled == false && playBGM2)
        {
            BGM2();
            day.SetActive(false);
            night.SetActive(true);
        }
    }

    void BGM2()
    {
        SoundManager.instance.Stop(SoundManager.SoundName.BGM1);
        SoundManager.instance.Play(SoundManager.SoundName.BGM2);
        playBGM2 = false;
    }
}
