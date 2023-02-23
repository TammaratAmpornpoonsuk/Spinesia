using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Glow : MonoBehaviour
{
    [SerializeField] Renderer glowFlowerRenderer;
    [SerializeField] Renderer glowFlower_LightRenderer;
    [SerializeField] GameObject light2D;
    [SerializeField] float timeCD;

    [SerializeField] private GameObject spriteLight;

    bool isOn;

    [Header("Hero")]
    [SerializeField] private GameObject starter;
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject jellyFish;
    [SerializeField] private GameObject moss;

    [Header("Animator")]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        glowFlower_LightRenderer.enabled = false;
        light2D.SetActive(false);
        spriteLight.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        GetAnimator();

        if (GameObject.FindGameObjectWithTag("Moss") != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isOn)
                {
                    animator.SetBool("Attack", true);
                    spriteLight.SetActive(false);
                    glowFlowerRenderer.enabled = false;
                    glowFlower_LightRenderer.enabled = true;
                    light2D.SetActive(true);
                    SoundManager.instance.Play(SoundManager.SoundName.TreeGrow);
                    StartCoroutine(CloseLight());
                }
                StartCoroutine(CancelAnimation());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteLight.SetActive(true);
            isOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteLight.SetActive(false);
            isOn = false;
        }
    }

    void GetAnimator()
    {
        if (starter.activeInHierarchy)
        {
            animator = starter.GetComponent<Animator>();
        }
        else if (flower.activeInHierarchy)
        {
            animator = flower.GetComponent<Animator>();
        }
        else if (jellyFish.activeInHierarchy)
        {
            animator = jellyFish.GetComponent<Animator>();
        }
        else if (moss.activeInHierarchy)
        {
            animator = moss.GetComponent<Animator>();
        }
    }

    IEnumerator CloseLight()
    {
        yield return new WaitForSeconds(timeCD);
        glowFlowerRenderer.enabled = true;
        glowFlower_LightRenderer.enabled = false;
        light2D.SetActive(false);
        StopAllCoroutines();
    }

    IEnumerator CancelAnimation()
    {
        yield return new WaitForSeconds(.5f);
        animator.SetBool("Attack", false);
    }
}
