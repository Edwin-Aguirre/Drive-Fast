using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public void onClickNewGame()
    {
        GameStateManager.NewGame();
    }

    public void onClickQuitGame()
    {
        Application.Quit();
    }

    public void onClickTitleScreen()
    {
        GameStateManager.QuitToTitle();
    }

    public void onClickHowToPlay()
    {
        SceneManager.LoadScene("How to Play");
    }
}
