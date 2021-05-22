using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject PauseMenu;
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
