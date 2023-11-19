using System.Collections.Generic;
using UnityEngine;

public class StateMachineController
{
    private Dictionary<GameStateIndex, GameState> m_gameStates;
    private StateChangeModel m_stateChangeModel;
    private CameraSwitchModel m_cameraSwitchModel;

    private GameState m_currentState;
    private GameState CurrentState
    {
        get
        {
            return m_currentState;
        }
        set
        {
            m_gameStates[m_currentState.Index].OnExitState();
            m_currentState = value;
            m_gameStates[value.Index].OnEnterState();
            m_stateChangeModel.onStateChanged?.Invoke();
        }
    }

    public StateMachineController(StateChangeModel stateChangeModel, CameraSwitchModel cameraSwitchModel)
    {
        m_stateChangeModel = stateChangeModel;
        m_cameraSwitchModel = cameraSwitchModel;
        m_gameStates = new Dictionary<GameStateIndex, GameState>();
    }

    public void AddGameState(GameState stateToAdd)
    {
        if (!m_gameStates.ContainsKey(stateToAdd.Index))
        {
            m_gameStates.Add(stateToAdd.Index, stateToAdd);
            stateToAdd.changeStateRequest += ChangeState;
        }
    }

    public void ChangeState(GameStateIndex state)
    {
        CurrentState = m_gameStates[state];
        m_cameraSwitchModel.onStateSwitched?.Invoke((int)state);
    }

    public void Update()
    {
        m_currentState.OnUpdateState();
    }

    public void InitializeFirstState()
    {
        m_currentState = m_gameStates[GameStateIndex.MainMenu];
        m_gameStates[CurrentState.Index].OnEnterState();
    }
}
