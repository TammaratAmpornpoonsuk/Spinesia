using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFalling : MonoBehaviour
{
    [SerializeField] Rigidbody2D stoneRB;
    // Start is called before the first frame update
    void Start()
    {
        stoneRB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stoneRB.isKinematic = false;
            Destroy(gameObject);
        }
    }
}
