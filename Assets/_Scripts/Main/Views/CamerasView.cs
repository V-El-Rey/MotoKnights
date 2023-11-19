using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerasView : BaseView
{
    public CinemachineVirtualCamera mainMenuCamera;
    public CinemachineVirtualCamera gameCamera;

    public void Disable()
    {
        mainMenuCamera.Priority = 1;
        gameCamera.Priority = 1;
    }
}
