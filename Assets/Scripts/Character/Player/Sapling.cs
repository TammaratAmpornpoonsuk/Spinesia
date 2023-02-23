using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{
    [SerializeField] private GameObject vine;
    [SerializeField] private GameObject spriteLight;
    private bool canPlant;

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
        canPlant = false;
        spriteLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetAnimator();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canPlant)
            {
                if(GameObject.FindGameObjectWithTag("Flower") != null)
                {
                    SoundManager.instance.Play(SoundManager.SoundName.TreeGrow);
                    spriteLight.SetActive(false);
                    vine.SetActive(true);
                    gameObject.SetActive(false);
                    animator.SetBool("Attack", true);
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPlant = true;
            spriteLight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPlant = false;
            spriteLight.SetActive(false);
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
}
