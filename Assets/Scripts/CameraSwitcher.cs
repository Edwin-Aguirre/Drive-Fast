using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    private bool mainCamera = true;
    private bool hasChangedCamera = true;

    [SerializeField]
    private CinemachineVirtualCamera thirdPersonCam;
    [SerializeField]
    private CinemachineVirtualCamera thirdPersonFreeCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Pressing tab will switch between cameras
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(hasChangedCamera == true)
            {
                SwitchPriority();
                hasChangedCamera = false;
            }
            else
            {
                hasChangedCamera = true;
            }
        }
    }

    private void SwitchPriority() 
    //Sets the Priority of the cameras
    //The higher priority camera is the one that is being shown to the player
    {
        if(mainCamera)
        {
            thirdPersonCam.Priority = 0;
            thirdPersonFreeCam.Priority = 1;
        }
        else
        {
            thirdPersonCam.Priority = 1;
            thirdPersonFreeCam.Priority = 0;
        }
        mainCamera = !mainCamera;
    }
}
