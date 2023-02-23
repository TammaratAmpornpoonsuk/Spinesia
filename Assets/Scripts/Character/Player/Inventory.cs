using Caton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("General Fields")]
    public List<GameObject> items = new List<GameObject>();
    public bool isOpen;
    [Header("UI Item Section")]
    public GameObject inventoryWindow;
    public Image[] itemsImages;

    UnlockDoor unlockDoor;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryWindow.SetActive(isOpen);

        if (isOpen)
        {
            SoundManager.instance.Play(SoundManager.SoundName.OpenInventory);
        }
        else if (!isOpen)
        {
            SoundManager.instance.Play(SoundManager.SoundName.CloseInventory);
        }
        UpdateUi();
    }
    
    public void PickUp(GameObject item)
    {
        items.Add(item);
        UpdateUi();
    }

    void UpdateUi()
    {
        HideAllUI();

        for (int i = 0; i < items.Count; i++)
        {
            itemsImages[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            itemsImages[i].gameObject.SetActive(true);
        }
    }

    void HideAllUI()
    {
        foreach (var i in itemsImages)
        {
            i.gameObject.SetActive(false);
        }
    }
}
