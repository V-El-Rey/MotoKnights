using Cinemachine;

public class CamerasView : BaseView
{
    public CinemachineVirtualCamera mainMenuCamera;
    public CinemachineVirtualCamera gameCamera;
    public CinemachineVirtualCamera endGameCamera;

    public void Disable()
    {
        mainMenuCamera.Priority = 1;
        gameCamera.Priority = 1;
        endGameCamera.Priority = 1;
    }
}
