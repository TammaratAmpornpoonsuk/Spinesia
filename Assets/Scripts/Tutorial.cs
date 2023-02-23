using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Transform pos;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = pos.position;
    }
}
