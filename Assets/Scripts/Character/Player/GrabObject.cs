using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] private Transform grabPos;
    [SerializeField] private Transform rayPos;
    [SerializeField] private float rayDistance;
    [SerializeField] LayerMask layer;

    private GameObject grabbedObject;

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

        Collider2D box = Physics2D.OverlapCircle(rayPos.position, rayDistance,layer);
        if(box != null)
        {
            if(Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
            {
                grabbedObject = box.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPos.position;
                grabbedObject.transform.SetParent(transform);
                animator.SetBool("Carry", true);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                animator.SetBool("Carry", false);
            }
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(rayPos.position, rayDistance);
    }
}
