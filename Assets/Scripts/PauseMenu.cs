using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    private bool isPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pressing the Escape key will bring up the pause menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == true)
            {
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                isPaused = false;
            }
            else
            {
                Cursor.visible = false;
                pauseMenu.SetActive(false);
                isPaused = true;
            }
            
        }
    }
    
}
