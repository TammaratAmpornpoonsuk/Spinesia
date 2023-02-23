using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class NextScene : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;

        //private PlayerController _player;
        private bool canGo;

        private void Start()
        {
            canGo = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (canGo)
                {
                    SceneManager.LoadScene(_nextSceneName);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            /*
            if (col.TryGetComponent(out _player))
            {
                SceneManager.LoadScene(_nextSceneName);
            }
            */
            if (collision.CompareTag("Player"))
            {
                canGo = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canGo = false;
            }
        }
    }
}
