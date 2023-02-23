using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHero : MonoBehaviour
{
    [SerializeField] private Collider2D flowerDoor;
    [SerializeField] private Collider2D jellyFishDoor;
    [SerializeField] private Collider2D mossDoor;
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject jellyFish;
    [SerializeField] private GameObject moss;

    [SerializeField] private GameObject uiHero1;
    [SerializeField] private GameObject uiHero2;
    [SerializeField] private GameObject uiHero3;

    [SerializeField] private GameObject effect1;
    [SerializeField] private GameObject effect2;
    [SerializeField] private GameObject effect3;

    public List<GameObject> HeroList = new List<GameObject>();

    bool canAddFlower;
    bool canAddJellyFish;
    bool canAddMoss;
    // Start is called before the first frame update
    void Start()
    {
        canAddFlower = false;
        canAddJellyFish = false;
        canAddMoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        AddHero();
        Swap();
    }

    void AddHero()
    {
        if (flowerDoor.enabled == false)
        {
            canAddFlower = true;
        }
        if (jellyFishDoor.enabled == false)
        {
            canAddJellyFish = true;
        }
        if (mossDoor.enabled == false)
        {
            canAddMoss = true;
        }

        for (int i = 0; i < HeroList.Count; i++)
        {
            if (HeroList[i] == flower)
            {
                canAddFlower = false;
            }
            else if (HeroList[i] == jellyFish)
            {
                canAddJellyFish = false;
            }
            else if (HeroList[i] == moss)
            {
                canAddMoss = false;
            }
        }

        if (canAddFlower)
        {
            HeroList.Add(flower);
        }
        else if (canAddJellyFish)
        {
            HeroList.Add(jellyFish);
        }
        else if (canAddMoss)
        {
            HeroList.Add(moss);
        }
    }

    void Swap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.instance.Play(SoundManager.SoundName.SwitchAbility);
            foreach (var item in HeroList)
            {
                if (item.name == "Flower")
                {
                    flower.SetActive(true);

                    jellyFish.SetActive(false);
                    moss.SetActive(false);
                    uiHero1.SetActive(true);
                    uiHero2.SetActive(false);
                    uiHero3.SetActive(false);
                    effect1.SetActive(true);
                    StartCoroutine(StopEffect());
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.instance.Play(SoundManager.SoundName.SwitchAbility);
            foreach (var item in HeroList)
            {
                if (item.name == "Moss")
                {
                    moss.SetActive(true);

                    flower.SetActive(false);
                    jellyFish.SetActive(false);
                    uiHero2.SetActive(true);
                    uiHero1.SetActive(false);
                    uiHero3.SetActive(false);
                    effect2.SetActive(true);
                    StartCoroutine(StopEffect());
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SoundManager.instance.Play(SoundManager.SoundName.SwitchAbility);
            foreach (var item in HeroList)
            {
                if (item.name == "JellyFish")
                {
                    jellyFish.SetActive(true);

                    flower.SetActive(false);
                    moss.SetActive(false);
                    uiHero3.SetActive(true);
                    uiHero1.SetActive(false);
                    uiHero2.SetActive(false);
                    effect3.SetActive(true);
                    StartCoroutine(StopEffect());
                }
            }
        }
    }
    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(.8f);
        effect1.SetActive(false);
        effect2.SetActive(false);
        effect3.SetActive(false);
        StopCoroutine(StopEffect());
    }
}
