using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject settingCanvas;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        menuCanvas.SetActive(true);
        settingCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_nextSceneName);
    }

    public void Setting()
    {
        menuCanvas.SetActive(false);
        settingCanvas.SetActive(true);
    }

    public void BackToMenu()
    {
        menuCanvas.SetActive(true);
        settingCanvas.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
