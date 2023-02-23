using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolicPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject correctSym;
    [SerializeField] private GameObject correct;
    public List<GameObject> symbols = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        symbols[0].SetActive(true);
        correct.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (correctSym.activeInHierarchy)
        {
            correct.SetActive(true);
        }
        else if (!correctSym.activeInHierarchy)
        {
            correct.SetActive(false);
        }
    }

    public void ChangeSymbolic()
    {
        SoundManager.instance.Play(SoundManager.SoundName.ClickPuzzle);
        if (symbols[0].activeInHierarchy)
        {
            symbols[0].SetActive(false);
            symbols[1].SetActive(true);
        }
        else if (symbols[1].activeInHierarchy)
        {
            symbols[1].SetActive(false);
            symbols[2].SetActive(true);
        }
        else if (symbols[2].activeInHierarchy)
        {
            symbols[2].SetActive(false);
            symbols[3].SetActive(true);
        }
        else if (symbols[3].activeInHierarchy)
        {
            symbols[3].SetActive(false);
            symbols[0].SetActive(true);
        }
    }
}
