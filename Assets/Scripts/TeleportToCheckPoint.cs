using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToCheckPoint : MonoBehaviour
{
    private CheckPointController checkPointController;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("CPController");
        if(go != null)
        {
            checkPointController = go.GetComponent<CheckPointController>();
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = checkPointController.checkpoint;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
