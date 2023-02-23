using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    private GameObject plantGO;
    
    [SerializeField] private Transform rayPos;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float timeCD;

    [Header("Hero")]
    [SerializeField] private GameObject starter;
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject jellyFish;
    [SerializeField] private GameObject moss;

    [Header("Animator")]
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        GetAnimator();

        Collider2D plant = Physics2D.OverlapCircle(rayPos.position, rayDistance, layer);
        if (plant != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(plantGO == null)
                {
                    SoundManager.instance.Play(SoundManager.SoundName.JellyFish);
                    animator.SetBool("Attack", true);
                    plantGO = plant.gameObject;
                    plantGO.SetActive(false);
                }
                StartCoroutine(CancelAnimation());
            }

        }
        StartCoroutine(Return());
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

    IEnumerator Return()
    {
        yield return new WaitForSeconds(timeCD);
        if(plantGO != null)
        {
            plantGO.SetActive(true);
            plantGO = null;
        }
        StopAllCoroutines();
    }

    IEnumerator CancelAnimation()
    {
        yield return new WaitForSeconds(.5f);
        animator.SetBool("Attack", false);
    }
}
