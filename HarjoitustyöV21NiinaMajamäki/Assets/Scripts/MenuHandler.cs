using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    //Tämä koodi hoitaaa pelin menuja ja niiden toimintaa
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject gameOver;
    public TextMeshProUGUI pointsTXT;
    public TextMeshProUGUI livesTXT;
    public PlauerControllerTheOther playerController;

    public string pointsFill = "Points ";
    public int pointsNum = 0;
    public string livesFill = "Lives";
    
    void Awake()
    {
        mainMenu = GameObject.Find("MainMenu");
        gameOver = GameObject.Find("GameOver");
        pauseMenu = GameObject.Find("PauseMenu");
        playerController = GameObject.Find("Player").GetComponent<PlauerControllerTheOther>();
        //pointsTXT.text = pointsFill + pointsNum;
        gameOver.SetActive(false);
        GameOff();
        Time.timeScale = 0f;
        
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        //gameOver.SetActive(false);
        pointsTXT.text = pointsFill + pointsNum;
    }

    // Update is called once per frame
    public void Update()
    {
       if (playerController.gameOver == true)
       {
            GameOver();
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
        GameOn();
        mainMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void GameOn()
    {
        Time.timeScale = 1f;
    }

    public void GameOff()
    {
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
