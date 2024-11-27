using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] List<GameObject> toClose;
    void Start()
    {
        isPaused = false;        
    }
    void Update()
    {
        pauseMenu.SetActive(isPaused);
        pauseButton.SetActive(!isPaused);
        foreach(GameObject obj in toClose)
        {
            obj.SetActive(!isPaused);
        }
    }
    public void pause()
    {
        isPaused = true;
        Time.timeScale=0;
    }
    public void resume()
    {
        isPaused = false;
        Time.timeScale=1;
    }
    public void restart()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    public void menu()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }
}
