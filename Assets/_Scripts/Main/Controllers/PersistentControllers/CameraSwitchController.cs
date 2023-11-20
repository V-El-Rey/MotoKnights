public class CameraSwitchController : IBaseController, IEnterController, IExitController
{
    private CameraSwitchModel m_cameraSwitchModel;
    private CamerasView m_camerasView;
    public CameraSwitchController(CameraSwitchModel cameraSwitchModel, CamerasView camerasView)
    {
        m_cameraSwitchModel = cameraSwitchModel;
        m_camerasView = camerasView;
    }
    public void OnEnterExecute()
    {
        m_cameraSwitchModel.onStateSwitched += SwitchCamera;
    }

    public void OnExitExecute()
    {
        m_cameraSwitchModel.onStateSwitched -= SwitchCamera;
    }

    private void SwitchCamera(int stateIndex)
    {
        m_camerasView.Disable();
        switch (stateIndex)
        {
            case 0: m_camerasView.mainMenuCamera.Priority = 10; break;
            case 1: m_camerasView.gameCamera.Priority = 10; break;
            case 2: m_camerasView.endGameCamera.Priority = 10; break;   

        }
    }
}
