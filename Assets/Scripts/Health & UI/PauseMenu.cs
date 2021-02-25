using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject deadMenuUI;
    public GameObject skillsMenuUI;
    public GameObject enchantmentMenuUI;

    public GameObject joystick1;

    public VariableJoystick joystick;

    void Start()
    {
        joystick.SetMode(JoystickType.Floating);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume1()
    {
        skillsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Skills()
    {
        skillsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume2()
    {
        enchantmentMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }   

    public void Enchantment()
    {
        enchantmentMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Died()
    {
        joystick1.SetActive(false);
        deadMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Byeeeeee");
    }
}
