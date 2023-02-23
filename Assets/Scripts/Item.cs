using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum InteractionType
    {
        None,
        Pickup,
        Examine
    }

    public InteractionType type;
    [Header("EXAMINE")]
    public string descriptionText;

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.Pickup:
                FindObjectOfType<Inventory>().PickUp(gameObject);
                SoundManager.instance.Play(SoundManager.SoundName.Key);
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                FindObjectOfType<Interaction>().ExamineItem(this);
                break;
            default:
                Debug.Log("Null Item");
                break;
        }
    }
}
