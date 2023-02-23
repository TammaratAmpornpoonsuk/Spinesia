using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject noteCanvas;
    private bool canOpen;
    private bool opening;
    public bool playingPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        noteCanvas.SetActive(false);
        canOpen = false;
        opening = false;
        playingPuzzle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && !opening)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                noteCanvas.SetActive(true);
                opening = true;
                playingPuzzle = true;
            }
        }
        else if(canOpen && opening)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.Locked;
                noteCanvas.SetActive(false);
                opening = false;
                playingPuzzle = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = false;
        }
    }
}
