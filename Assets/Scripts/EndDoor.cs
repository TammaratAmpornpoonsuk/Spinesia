using System.Collections;
using System.Collections.Generic;
using Caton;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private string message;

    [Header("Door")]
    [SerializeField] private Renderer openDoorRenderer;
    [SerializeField] private Renderer closeDoorRenderer;
    [SerializeField] private Collider2D collider2d;
    [SerializeField] private GameObject key;

    [Header("Next Scene")]
    [SerializeField] private string nextSceneName;

    [Header("Light")]
    [SerializeField] private GameObject spriteLight;

    private bool canOpen;
    // Start is called before the first frame update
    void Start()
    {
        canOpen = false;
        spriteLight.SetActive(false);
        openDoorRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canOpen)
            {
                spriteLight.SetActive(false);
                FindKey();
            }
        }
    }

    void FindKey()
    {
        if (key.activeInHierarchy)
        {
            text.text = message;
            StartCoroutine(disableText());
        }
        else
        {
            closeDoorRenderer.enabled = false;
            openDoorRenderer.enabled = true;
            StartCoroutine(NextScene());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
            spriteLight.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = false;
            spriteLight.SetActive(false);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.Stop(SoundManager.SoundName.BGM1);
        SoundManager.instance.Stop(SoundManager.SoundName.BGM2);
        SceneManager.LoadScene(nextSceneName);
        StopAllCoroutines();
    }
    public IEnumerator disableText()
    {
        yield return new WaitForSeconds(4f);
        if (text.text == message)
        {
            text.text = null;
        }
    }
}
