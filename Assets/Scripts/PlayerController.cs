using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Text countText;
    public int count;

    [SerializeField]
    private int numOfPoints;

    [SerializeField]
    private Text winText;
    [SerializeField]
    private Text playAgainText;
    [SerializeField]
    private Text goodLuckText;

    [SerializeField]
    public CountDown countDownScript;
    [SerializeField]
    private SimpleCarController SimpleCarControllerScript;

    [SerializeField]
    private GameObject boostFlames;
    [SerializeField]
    private GameObject freezeIcon;
    [SerializeField]
    private GameObject plusIcon;
    [SerializeField]
    private GameObject minusIcon;
    [SerializeField]
    private GameObject plusOneIcon;
    [SerializeField]
    private GameObject minusOneIcon;

    [SerializeField]
    private GameObject winMenu;

    [SerializeField]
    private GameObject spawnPoint;
    private Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        setCountText();
        setGoodLuckText();
        winText.text = "";
        playAgainText.text = "";
        Cursor.visible = false;
        goodLuckText.text = "Good Luck";
    }

    // Update is called once per frame
    void Update()
    {
        //If the car flips over, press F to flip it back
        if(Input.GetKey(KeyCode.F))
        {
            gameObject.transform.localRotation = Quaternion.Euler(0,gameObject.transform.rotation.y,0);
        }
        //If the car gets stuck press R to go to the spawn point
        if(Input.GetKey(KeyCode.R))
        {
            spawnLocation =  spawnPoint.gameObject.transform.position;
            transform.position =  new Vector3(spawnLocation.x,spawnLocation.y,spawnLocation.z);
        }
        //The car will honk its horn if the left control is pressed
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            SoundManagerScript.PlaySound("Horn");
        }
    }

    //Whenever there is a collision with a $, a point gets added to the score
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Score"))
        {
            SoundManagerScript.PlaySound("Score");
            plusOneIcon.gameObject.SetActive(true);
            StartCoroutine(PlusOneDuration());
            Destroy(other.gameObject);
            count += 1;
            setCountText();
            if(count == numOfPoints)
            {
                setWinText();
                winMenu.SetActive(true);
                GameStateManager.PauseGame();
            }
        }
        //Whenever there is a collision with a -$, a point gets decreased from the score
        if(other.gameObject.CompareTag("MinusScore"))
        {
            SoundManagerScript.PlaySound("-Score");
            minusOneIcon.gameObject.SetActive(true);
            StartCoroutine(MinusOneDuration());
            Destroy(other.gameObject);
            count -= 1;
            if(count <= 0)
            {
                count = 0;
            }
            setCountText();
        }
        //When the player picks up the Time Powerup, then more time gets added to the timer on the top right
        if(other.gameObject.CompareTag("Time"))
        {
            SoundManagerScript.PlaySound("+Timer");
            plusIcon.gameObject.SetActive(true);
            StartCoroutine(PlusDuration());
            countDownScript.currentTime += 5;
            Destroy(other.gameObject);
        }
        //When the player picks up the -Time Powerup, then less time gets added to the timer on the top right
        if(other.gameObject.CompareTag("-Time"))
        {
            SoundManagerScript.PlaySound("-Timer");
            minusIcon.gameObject.SetActive(true);
            StartCoroutine(MinusDuration());
            countDownScript.currentTime -= 5;
            Destroy(other.gameObject);
        }
        //When the player picks up the Boost Powerup, the maxTorque of the car increase, which increases speed for a short time
        if(other.gameObject.CompareTag("Boost"))
        {
            SoundManagerScript.PlaySound("Boost");
            SimpleCarControllerScript.maxMotorTorque = 4000;
            StartCoroutine(BoostDuration());
            Destroy(other.gameObject);
            boostFlames.gameObject.SetActive(true);
            StartCoroutine(FlameDuration());
        }
        //When the player picks up the FreezeTime Powerup, then time gets frozen for 3 seconds
        if(other.gameObject.CompareTag("FreezeTime"))
        {
            SoundManagerScript.PlaySound("FreezeTimer");
            freezeIcon.gameObject.SetActive(true);
            countDownScript.isCountingDown = false;
            StartCoroutine(FreezeDuration());
            Destroy(other.gameObject);
        }
    }
    
    //Sets the score at the top left of the screen
    public void setCountText()
    {
        countText.text = "Score: " + count.ToString() + "/" + numOfPoints.ToString();
    }

    //Sets the win screen
    void setWinText()
    {
        winText.text = "You Win!";
        Cursor.visible = true;
    }

    //The speed boost lasts for 5 seconds then goes back to the original speed
    IEnumerator BoostDuration()
    {
        yield return new WaitForSeconds(5);
        SimpleCarControllerScript.maxMotorTorque = 400;
    }
    //Disables the flames behind the car after 5 seconds
    IEnumerator FlameDuration()
    {
        yield return new WaitForSeconds(5);
        boostFlames.gameObject.SetActive(false);
    }
    //Freezes time for 3 seconds, then turns time back to normal
    IEnumerator FreezeDuration()
    {
        yield return new WaitForSeconds(3);
        countDownScript.isCountingDown = true;
        freezeIcon.gameObject.SetActive(false);
    }
    //Shows a +5 icon above the car when you get a timer powerup
    IEnumerator PlusDuration()
    {
        yield return new WaitForSeconds(0.5f);
        plusIcon.gameObject.SetActive(false);
    }
    //Shows a -5 icon above the car when you get a -timer powerup
    IEnumerator MinusDuration()
    {
        yield return new WaitForSeconds(0.5f);
        minusIcon.gameObject.SetActive(false);
    }
    //Shows a +1 icon above the car when you pickup a $ item
    IEnumerator PlusOneDuration()
    {
        yield return new WaitForSeconds(0.5f);
        plusOneIcon.gameObject.SetActive(false);
    }
    //Shows a -1 icon above the car when you pickup a $ item
    IEnumerator MinusOneDuration()
    {
        yield return new WaitForSeconds(0.5f);
        minusOneIcon.gameObject.SetActive(false);
    }
    //Shows the goodluck text in level 3 for 3 seconds
    IEnumerator GoodLuckDuration()
    {
        yield return new WaitForSeconds(3f);
        goodLuckText.text = "";
    }
    //Sets the goodluck text
    void setGoodLuckText()
    {
        StartCoroutine(GoodLuckDuration());
    }
    

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        count = data.score;
        countText.text = data.scoreText;
        countDownScript.currentTime = data.time;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        SceneManager.LoadScene(data.scene);
        GameStateManager.TestLoad();
    }

    private void Awake() 
    {
        DontDestroyOnLoad(countText);
    }
}
