using Caton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private string message;
    [SerializeField] private string ability;

    [Header("Player Movement")]
    private PlayerController player;
    private Rigidbody2D playerRb;

    [Header("Change Hero to")]
    [SerializeField] private GameObject nextHero;

    [Header("Current Hero")]
    [SerializeField] private GameObject currentHero1;
    [SerializeField] private GameObject currentHero2;
    [SerializeField] private GameObject currentHero3;

    [Header("Door")]
    [SerializeField] private Renderer openDoorRenderer;
    [SerializeField] private Renderer closeDoorRenderer;
    [SerializeField] private Collider2D collider2d;
    [SerializeField] private GameObject key;

    [Header("LIGHT")]
    [SerializeField] private GameObject spriteLight;

    [Header("UI")]
    [SerializeField] private GameObject uiHero1;
    [SerializeField] private GameObject uiHero2;
    [SerializeField] private GameObject uiHero3;

    [Header("Effect")]
    [SerializeField] private GameObject effect;

    private bool canOpen;
    // Start is called before the first frame update

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go != null)
        {
            player = go.GetComponent<PlayerController>();
            playerRb = go.GetComponent<Rigidbody2D>();
        }
        spriteLight.SetActive(false);
        canOpen = false;
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
            text.text = ability;
            closeDoorRenderer.enabled = false;
            openDoorRenderer.enabled = true;
            playerRb.velocity = Vector2.zero;
            player.enabled = false;
            StartCoroutine(disableText());
            StartCoroutine(ChangeHero());
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

    IEnumerator ChangeHero()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.Play(SoundManager.SoundName.SwitchAbility);
        closeDoorRenderer.enabled = true;
        openDoorRenderer.enabled = false;
        if (currentHero1.activeInHierarchy || currentHero2.activeInHierarchy || currentHero3.activeInHierarchy)
        {
            currentHero1.SetActive(false);
            currentHero2.SetActive(false);
            currentHero3.SetActive(false);
            nextHero.SetActive(true);
            player.enabled = true;
            uiHero1.SetActive(true);
            uiHero2.SetActive(false);
            uiHero3.SetActive(false);
            effect.SetActive(true);
            StartCoroutine(StopEffect());
        }
        collider2d.enabled = false;
        StopCoroutine(ChangeHero());
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(.8f);
        effect.SetActive(false);
        StopCoroutine(StopEffect());
    }

    public IEnumerator disableText()
    {
        yield return new WaitForSeconds(4f);
        if (text.text != null)
        {
            text.text = null;
        }
    }
}
