using Assets.Scripts.Main.Controllers;
using Assets.Scripts.Main.Models;
using UnityEngine;

public class MainGameState : GameState
{
    private PlayerModel m_playerModel;
    private ShootingModel m_shootingModel;
    private MainUIModel m_mainUIModel;  
    private InputModel m_inputModel;
    private InputModel m_enemyInputModel;
    private EnemyModel m_enemyModel;
    public MainGameState(Transform uiRoot, MainUIModel mainUIModel) : base()
    {
        Index = GameStateIndex.Game;
        m_shootingModel = new ShootingModel();
        m_playerModel = new PlayerModel();
        m_enemyModel = new EnemyModel();
        m_inputModel = new InputModel();
        m_enemyInputModel = new InputModel();

        m_mainUIModel = mainUIModel;
        m_playerModel.PlayerView = GameObject.FindObjectOfType<PlayerView>().GetComponent<PlayerView>() as PlayerView;
        m_enemyModel.EnemyView = GameObject.FindObjectOfType<EnemyView>().GetComponent<EnemyView>() as EnemyView;

        m_controllersManager.AddController(new MainUIController(uiRoot, m_mainUIModel));
        m_controllersManager.AddController(new KeyboardInputController(m_inputModel));
        m_controllersManager.AddController(new InputUIController(uiRoot, m_inputModel));
        m_controllersManager.AddController(new EnemyController(m_enemyModel, m_playerModel, m_enemyInputModel));
        m_controllersManager.AddController(new PlayerController(m_playerModel, m_mainUIModel, this));
        m_controllersManager.AddController(new MotorcycleController(((PlayerView)m_playerModel.PlayerView).motorcycle, m_inputModel));
        m_controllersManager.AddController(new MotorcycleController(((EnemyView)m_enemyModel.EnemyView).motorcycle, m_enemyInputModel));
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
    }

    public override void OnExitState()
    {
        base.OnEnterState();
    }
}
