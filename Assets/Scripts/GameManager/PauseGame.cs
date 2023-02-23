using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class PauseGame : MonoBehaviour
    {
        //[SerializeField] private GameObject returnToMainMenu;
        //[SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject controlMenu;
        [SerializeField] private GameObject optionBackground;
        [SerializeField] private GameObject resume;
        [SerializeField] private GameObject control;
        [SerializeField] private GameObject back;
        [SerializeField] private GameObject quit;
        
        [SerializeField] private string _nextSceneName;
        
        private bool pause;
        
        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            controlMenu.SetActive(false);
            optionBackground.SetActive(false);
            resume.SetActive(false);
            control.SetActive(false);
            back.SetActive(false);
            quit.SetActive(false);
            //returnToMainMenu.SetActive(false);
            //gameOver.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                //returnToMainMenu.SetActive(true);
                //gameOver.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pause = !pause;
                    Pause();
                }
                
                //returnToMainMenu.SetActive(false);
                //gameOver.SetActive(false);
            }
        }
        
        void Pause()
        {
            if (pause)
            {
                optionBackground.SetActive(true);
                resume.SetActive(true);
                control.SetActive(true);
                back.SetActive(true);
                quit.SetActive(true);
                Time.timeScale = 0;
                SoundManager.instance.Pause(SoundManager.SoundName.BGM1);
                SoundManager.instance.Pause(SoundManager.SoundName.BGM2);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                optionBackground.SetActive(false);
                resume.SetActive(false);
                control.SetActive(false);
                back.SetActive(false);
                quit.SetActive(false);
                Time.timeScale = 1;
                SoundManager.instance.UnPause(SoundManager.SoundName.BGM1);
                SoundManager.instance.UnPause(SoundManager.SoundName.BGM2);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void ResumeButton()
        {
            if (pause)
            {
                pause = false;
                Pause();
            }
        }

        public void Control()
        {
            if (pause)
            {
                controlMenu.SetActive(true);
            }
        }

        public void Control_Back()
        {
            if(pause && controlMenu.activeInHierarchy)
            {
                controlMenu.SetActive(false);
            }
        }
        
        public void BackButton()
        {
            if (pause)
            {
                pause = false;
                Pause();
                //LoadingScreenController.instance.LoadNextScene(_nextSceneName);
                SoundManager.instance.Stop(SoundManager.SoundName.BGM1);
                SoundManager.instance.Stop(SoundManager.SoundName.BGM2);
                SceneManager.LoadScene(_nextSceneName);
                Cursor.lockState = CursorLockMode.None;
            }
        }

        public void Quit()
        {
            if (pause)
            {
                Application.Quit();
            }
        }

        public void ReturnToMainMenuButton()
        {
            //LoadingScreenController.instance.LoadNextScene(_nextSceneName);
            SceneManager.LoadScene(_nextSceneName);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
