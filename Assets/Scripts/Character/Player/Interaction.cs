using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [Header("DETECTION ITEM")]
    
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask detectionLayer;
    private GameObject detectionItem;
    [SerializeField] private GameObject player;
    
    [Header("EXAMINATION")]
    
    public GameObject examineWindow;
    [SerializeField] private Image examineImage;
    [SerializeField] private TMP_Text examineText;
    public bool isExamining;

    void Update()
    {
        if (DetectItem())
        {
            if (InteractInput())
            {
                detectionItem.GetComponent<Item>().Interact();
                /*if (isExamining)
                {
                    player.GetComponent<PlayerMove>().DontMove();
                }*/
            }
        }
        else
        {
            if (isExamining)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    examineWindow.SetActive(false);
                    isExamining = false;
                }
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectItem()
    {
        Collider2D item = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if (item == null)
        {
            detectionItem = null;
            return false;
        }
        else
        {
            detectionItem = item.gameObject;
            return true;
        }
    }
    
    public void ExamineItem(Item item)
    {
        if (isExamining)
        {
            examineWindow.SetActive(false);
            isExamining = false;
        }
        else
        {
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            examineText.text = item.descriptionText;
            examineWindow.SetActive(true);
            isExamining = true;
        }
    }

}
