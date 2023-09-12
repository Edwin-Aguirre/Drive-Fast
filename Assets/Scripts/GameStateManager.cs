using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private List<string> levels = new List<string>();
    [SerializeField]
    private string titleSceneName;


    private static GameStateManager instance;
    
    enum GAMESTATE
    {
        MENU,
        PLAYING,
        PAUSED,
        WIN,
        GAMEOVER,
        RESTART
    }

    private static GAMESTATE state;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.PauseGame();
        }
    }

    public static void NewGame()
    {
        state = GAMESTATE.PLAYING;
        if(instance.levels.Count > 0)
        {
            SceneManager.LoadScene(instance.levels[0]);
            Time.timeScale = 1;
        }
    }

    public static void QuitToTitle()
    {
        state = GAMESTATE.MENU;
        SceneManager.LoadScene(instance.titleSceneName);
        Cursor.visible = true;
    }

    public static void PauseGame()
    {
        if(state == GAMESTATE.PLAYING)
        {
            state = GAMESTATE.PAUSED;
            Time.timeScale = 0;
        }
        else if(state == GAMESTATE.PAUSED)
        {
            state = GAMESTATE.PLAYING;
            Time.timeScale = 1;
        }
    }

    public static void RestartGame()
    {
        if(state == GAMESTATE.PAUSED)
        {
            GameStateManager.NewGame();
            state = GAMESTATE.PLAYING;
            Time.timeScale = 1;
        }
    }

    public static void Level2()
    {
        state = GAMESTATE.PLAYING;
        if(instance.levels.Count > 0)
        {
            SceneManager.LoadScene(instance.levels[1]);
            Time.timeScale = 1;
        }
    }

    public static void Level3()
    {
        state = GAMESTATE.PLAYING;
        if(instance.levels.Count > 0)
        {
            SceneManager.LoadScene(instance.levels[2]);
            Time.timeScale = 1;
        }
    }

    public static void TestLoad()
    {
        state = GAMESTATE.PLAYING;
        Time.timeScale = 1;
    }

}
