using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBar : MonoBehaviour
{
    [SerializeField] private GameObject jumpBarPos;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = jumpBarPos.transform.position;
    }
}
