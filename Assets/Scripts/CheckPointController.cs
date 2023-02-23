using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    GameObject player;
    public Vector2 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checkpoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 SetCheckPoint(Vector2 position)
    {
        checkpoint = position;
        return checkpoint;
    }
}
