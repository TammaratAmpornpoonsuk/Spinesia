using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundDoor : MonoBehaviour
{
    [SerializeField] private GameObject symbolicCanvas;
    [SerializeField] private GameObject correct_1;
    [SerializeField] private GameObject correct_2;
    [SerializeField] private GameObject correct_3;
    [SerializeField] private GameObject correct_4;
    [SerializeField] private GameObject correctimage;
    [SerializeField] private Collider2D doorCol;
    [SerializeField] private SpriteRenderer closeDoor;
    [SerializeField] private SpriteRenderer openDoor;
    private bool canOpen;
    private bool opening;
    public bool playingSymbolic;

    // Start is called before the first frame update
    void Start()
    {
        symbolicCanvas.SetActive(false);
        canOpen = false;
        opening = false;
        playingSymbolic = false;
        doorCol.enabled = true;
        closeDoor.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && !opening)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                symbolicCanvas.SetActive(true);
                opening = true;
                playingSymbolic = true;
            }
        }
        else if (canOpen && opening)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.Locked;
                symbolicCanvas.SetActive(false);
                opening = false;
                playingSymbolic = false;
            }
        }

        if(correct_1.activeInHierarchy && correct_2.activeInHierarchy && correct_3.activeInHierarchy && correct_4.activeInHierarchy)
        {
            correctimage.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(DelayFinishPuzzle());
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

    IEnumerator DelayFinishPuzzle()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.Play(SoundManager.SoundName.openWay);
        doorCol.enabled = false;
        closeDoor.enabled = false;
        openDoor.enabled = true;
        symbolicCanvas.SetActive(false);
        opening = false;
        playingSymbolic = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        StopCoroutine(DelayFinishPuzzle());
    }
}
