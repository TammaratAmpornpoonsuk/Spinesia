using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone"))
        {
            SoundManager.instance.Play(SoundManager.SoundName.Stone);
            rb.isKinematic = false;
            StartCoroutine(DestroyItSelf());
        }
    }

    IEnumerator DestroyItSelf()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
