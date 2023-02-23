using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    [SerializeField] GameObject sapling;
    [SerializeField] float timeCD;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        GetAnimator();

        StartCoroutine(ReturnToSapling());
        StartCoroutine(CancelAnimation());
    }

    IEnumerator ReturnToSapling()
    {
        yield return new WaitForSeconds(timeCD);
        sapling.SetActive(true);
        gameObject.SetActive(false);
    }

    IEnumerator CancelAnimation()
    {
        yield return new WaitForSeconds(.5f);
        animator.SetBool("Attack", false);

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