using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject gameOver;
    public TextMeshProUGUI pointsTXT;
    public TextMeshProUGUI livesTXT;
    public PlayerController playerController;

    public string pointsFill = "Points ";
    public int pointsNum = 0;
    public string livesFill = "Lives";
    
    void Awake()
    {
        mainMenu = GameObject.Find("MainMenu");
        gameOver = GameObject.Find("GameOver");
        pauseMenu = GameObject.Find("PauseMenu");
        pointsTXT.text = pointsFill + pointsNum;
        GameOff();
        Time.timeScale = 0f;
        
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        pointsTXT.text = pointsFill + pointsNum;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Pause();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Peli sammutettu");
    }
    public void Pause()
    {
        GameOff();
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        GameOn();
        pauseMenu.SetActive(false);
    }
    
    public void StartGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
    }

    public void GameOn()
    {
        Time.timeScale = 1f;
    }

    public void GameOff()
    {
        Time.timeScale = 0f;
    }
}
