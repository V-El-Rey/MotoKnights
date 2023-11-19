using Assets.Scripts.Main.Controllers;
using Assets.Scripts.Main.Models;
using UnityEngine;

public class MainGameState : GameState
{
    private PlayerModel m_playerModel;
    private ShootingModel m_shootingModel;
    private MainUIModel m_mainUIModel;  
    private InputModel m_inputModel;
    private EnemiesModel m_enemiesModel;
    public MainGameState(Transform uiRoot, MainUIModel mainUIModel) : base()
    {
        Index = GameStateIndex.Game;
        m_shootingModel = new ShootingModel();
        m_playerModel = new PlayerModel();
        m_enemiesModel = new EnemiesModel();
        m_inputModel = new InputModel();

        m_mainUIModel = mainUIModel;
        //m_playerModel.PlayerView = poolsManager.GetObjectFromPool(GameobjectsNameKeys.Player) as PlayerView;

        m_controllersManager.AddController(new MainUIController(uiRoot, m_mainUIModel));
        m_controllersManager.AddController(new InputUIController(uiRoot));
        m_controllersManager.AddController(new PlayerController(m_playerModel, m_mainUIModel, this));
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
