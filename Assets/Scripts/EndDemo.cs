using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndDemo : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;

    [SerializeField] private Image dim;
    private float black;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        black = 0;
        dim.color = new Color(0, 0, 0, black);
    }

    // Update is called once per frame
    void Update()
    {
        black += 0.25f * Time.deltaTime;
        dim.color = new Color(0, 0, 0, black);

        if(black >= 1)
        {
            StartCoroutine(GotoMenu());
        }
    }

    IEnumerator GotoMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(_nextSceneName);
    }
}
