using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [Header("LIGHT")]
    [SerializeField] GameObject dayLight;
    [SerializeField] GameObject nightLight;
    [SerializeField] Collider2D jellyFishDoor;
    // Start is called before the first frame update
    void Start()
    {
        dayLight.SetActive(true);
        nightLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!jellyFishDoor.enabled)
        {
            dayLight.SetActive(false);
            nightLight.SetActive(true);
        }
    }
}
