using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNoteImage : MonoBehaviour
{
    [SerializeField] private GameObject noteImage;
    // Start is called before the first frame update
    void Start()
    {
        noteImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
