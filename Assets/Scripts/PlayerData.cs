using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int score;
    public string scoreText;
    public float time;
    public float[] position;
    public string scene;

    public PlayerData(PlayerController player)
    {
        score = player.count;
        scoreText = player.countText.text;
        time = player.countDownScript.currentTime;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        scene = SceneManager.GetActiveScene().name;
    }
}
