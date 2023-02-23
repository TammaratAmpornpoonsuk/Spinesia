using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private string message;
    private Collider2D textCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        textCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.text = message;
        textCollider2D.enabled = false;
        StartCoroutine(disableText());
    }

    public IEnumerator disableText()
    {
        yield return new WaitForSeconds(4f);
        if(text.text == message)
        {
            text.text = null;
        }
        Destroy(gameObject);
    }
}
