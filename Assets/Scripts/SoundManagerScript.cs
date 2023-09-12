using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private static AudioClip hornSound;
    private static AudioClip engineSound;
    private static AudioClip scoreSound;
    private static AudioClip plusTimerSound;
    private static AudioClip minusTimerSound;
    private static AudioClip freezeTimerSound;
    private static AudioClip boostSound;
    private static AudioClip minusScoreSound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        hornSound = Resources.Load<AudioClip>("Horn");
        engineSound = Resources.Load<AudioClip>("Engine");
        scoreSound = Resources.Load<AudioClip>("Score");
        plusTimerSound = Resources.Load<AudioClip>("+Timer");
        minusTimerSound = Resources.Load<AudioClip>("-Timer");
        freezeTimerSound = Resources.Load<AudioClip>("FreezeTimer");
        boostSound = Resources.Load<AudioClip>("Boost");
        minusScoreSound = Resources.Load<AudioClip>("-Score");
        

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Horn":
                audioSrc.PlayOneShot(hornSound);
                break;
            case "Engine":
                audioSrc.PlayOneShot(engineSound);
                break;
            case "Score":
                audioSrc.PlayOneShot(scoreSound);
                break; 
            case "+Timer":
                audioSrc.PlayOneShot(plusTimerSound);
                break; 
            case "-Timer":
                audioSrc.PlayOneShot(minusTimerSound);
                break;
            case "FreezeTimer":
                audioSrc.PlayOneShot(freezeTimerSound);
                break;
            case "Boost":
                audioSrc.PlayOneShot(boostSound);
                break;
            case "-Score":
                audioSrc.PlayOneShot(minusScoreSound);
                break;
                
        }
    }
}
