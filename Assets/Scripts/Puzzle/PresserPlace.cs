using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresserPlace : MonoBehaviour
{
    [SerializeField] private GameObject log;
    [SerializeField] private SpriteRenderer beforeSprite;
    [SerializeField] private SpriteRenderer afterSprite;

    private void Start()
    {
        log.SetActive(true);
        beforeSprite.enabled = true;
        afterSprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone"))
        {
            SoundManager.instance.Play(SoundManager.SoundName.openWay);
            log.SetActive(false);
            beforeSprite.enabled = false;
            afterSprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone"))
        {
            log.SetActive(true);
            beforeSprite.enabled = true;
            afterSprite.enabled = false;
        }
    }
}
