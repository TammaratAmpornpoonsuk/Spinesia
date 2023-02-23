using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointController checkPointController;
    private bool isSet;
    Vector2 checkPoint;
    [SerializeField] SpriteRenderer checkpointRenderer;
    [SerializeField] SpriteRenderer checkpoint_lightRenderer;
    [SerializeField] GameObject light2D;

    void Start()
    {
        checkPoint = gameObject.transform.position;
        isSet = false;
        checkpoint_lightRenderer.enabled = false;
        light2D.SetActive(false);

        GameObject go = GameObject.FindGameObjectWithTag("CPController");
        if(go != null)
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
                SoundManager.instance.Play(SoundManager.SoundName.Checkpoint);
                checkPointController.SetCheckPoint(checkPoint);
                checkpoint_lightRenderer.enabled = true;
                checkpointRenderer.enabled = false;
                light2D.SetActive(true);
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
