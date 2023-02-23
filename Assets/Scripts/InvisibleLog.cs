using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleLog : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private Collider2D doorCollider;

    bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDone)
        {
            if (wall.activeInHierarchy)
            {
                InvisibleGameObject();
            }
            else if (!wall.activeInHierarchy)
            {
                VisibleGameObject();
            }
        }
        
    }

    void InvisibleGameObject()
    {
        if (doorCollider.enabled == false)
        {
            SoundManager.instance.Play(SoundManager.SoundName.openWay);
            wall.SetActive(false);
            isDone = true;
        }
    }

    void VisibleGameObject()
    {
        if(doorCollider.enabled == false)
        {
            wall.SetActive(true);
            isDone = true;
        }
    }
}
