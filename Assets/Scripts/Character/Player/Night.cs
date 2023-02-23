using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    private CheckPointController checkPointController;
    private bool isSet;
    Vector2 checkPoint;
    // Start is called before the first frame update
    void Start()
    {
        checkPoint = gameObject.transform.position;
        isSet = false;

        GameObject go = GameObject.FindGameObjectWithTag("CPController");
        if (go != null)
        {
            checkPointController = go.GetComponent<CheckPointController>();
        }
    }
    void Update()
    {
        if (isSet)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                checkPointController.SetCheckPoint(checkPoint);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isSet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isSet = false;
        }
    }
}
