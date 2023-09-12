using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{   
    [SerializeField]
    public Text countdownText;
    [SerializeField]
    private float startingTime;

    [SerializeField]
    private Text loseText;
    [SerializeField]
    private Text tryAgainText;

    public float currentTime = 0f; //Needs to be public so that I can use it in PlayerController
    

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        loseText.text = "";
        tryAgainText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        CountingDown();
    }

    //When you lose the game, it will stay in the game for 5 seconds and then take you to the title screen
    IEnumerator WaitAndGoToTitle()
    {
        yield return new WaitForSeconds(5);
        GameStateManager.QuitToTitle();
    }

    //Sets the lose text when the timer reaches 0
    void SetLoseText()
    {
        loseText.text = "You Lost!";
    }
    //Also sets the try again text below the lose text
    void setTryAgainText()
    {
        tryAgainText.text = "Try again next time";
    }


    public bool isCountingDown = true; //Needs to be public so that I can use it in PlayerControl
    private void CountingDown()
    {
        if(isCountingDown)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = "Time: " + currentTime.ToString("0");

        if(currentTime <= 0)
        {
            //When the timer reaches 0, the lose screen text will appear
            SetLoseText();
            setTryAgainText();
            WaitAndGoToTitle();
            StartCoroutine(WaitAndGoToTitle());
            currentTime = 0;
        }
        else if(currentTime <=10)
        {
            //When the timer reaches 10, it will change the color of the text to red
            countdownText.color = new Color32(137,25,33,255);
        }
        else if(currentTime > 10)
        {
            countdownText.color = new Color32(255,230,80,255);
        }
        }
        else
        {
            isCountingDown = false;
        }
    }

}
