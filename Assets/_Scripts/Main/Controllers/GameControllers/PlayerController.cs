using Assets.Scripts.Main.Models;
using System;
using UnityEngine;

public class PlayerController : IBaseController, IUpdateController, IEnterController, IExitController
{
    private GameState m_gameState;

    private PlayerModel m_playerModel;
    private PlayerView m_playerView;
    private MainUIModel m_mainUIModel;

    public PlayerController(PlayerModel playerModel, MainUIModel mainUIModel, GameState currentState)
    {
        m_gameState = currentState;
        m_playerModel = playerModel;
        m_playerView = playerModel.PlayerView as PlayerView;
        m_mainUIModel = mainUIModel;
    }

    public void OnEnterExecute()
    {
    }

    private void OnPlayerCollisionHandler(string tag)
    {
    }

    public void OnExitExecute()
    {
    }

    public void OnUpdateExecute()
    {
    }
}
