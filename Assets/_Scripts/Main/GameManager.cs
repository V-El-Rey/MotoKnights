using Assets.Scripts.Main.Models;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoolConfiguration PoolConfiguration;
    public Transform mainUIRoot;
    public CamerasView camerasView;

    private StateMachineController m_stateMachineController;

    private StateChangeModel m_stateChangeModel;
    private MainMenuUIModel m_mainMenuUIModel;
    private MainUIModel m_mainUIModel;
    private CameraSwitchModel m_cameraSwitchModel;

    private ControllersManager m_persistentControllersManager;

    private void Awake()
    {
        m_cameraSwitchModel = new CameraSwitchModel();
        m_persistentControllersManager = new ControllersManager();
        m_persistentControllersManager.AddController(new CameraSwitchController(m_cameraSwitchModel, camerasView));

        m_stateChangeModel = new StateChangeModel();
        m_mainMenuUIModel = new MainMenuUIModel();
        m_mainUIModel = new MainUIModel();
        m_stateMachineController = new StateMachineController(m_stateChangeModel, m_cameraSwitchModel);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_persistentControllersManager.OnEnterControllersExecute();
        m_stateMachineController.AddGameState(new MainMenuState(mainUIRoot, m_mainMenuUIModel));
        m_stateMachineController.AddGameState(new MainGameState(mainUIRoot, m_mainUIModel));
        m_stateMachineController.AddGameState(new EndGameState(mainUIRoot, m_mainUIModel));
        m_stateMachineController.InitializeFirstState();
    }

    // Update is called once per frame
    void Update()
    {
        m_persistentControllersManager.OnUpdateControllersExecute();
        m_stateMachineController.Update();
    }

    private void FixedUpdate()
    {
        m_persistentControllersManager.OnFixedUpdateControllersExecute();
        m_stateMachineController.FixedUpdate();
    }
}
