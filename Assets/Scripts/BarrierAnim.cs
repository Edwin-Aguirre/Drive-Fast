using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierAnim : MonoBehaviour
{
    private Animator Anim;

    private void Start() 
    {
        Anim = GetComponent<Animator>();

    }

    //When the player goes near the parking barrier, it will open the arms and close when the player drives away
    //For Level 1
    private void OnTriggerEnter(Collider other) 
    {
         if(other.gameObject.tag == "Player")
        {
            Anim.SetBool("Moving", true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Anim.SetBool("Moving", false);
        }
    }
}
