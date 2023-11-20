using Assets.Scripts.Main.Models;
using Assets.Scripts.Main.Views;
using UnityEngine;

namespace Assets.Scripts.Main.Controllers
{
    public class EndGameUIController : IBaseController, IEnterController, IExitController
    {
        private GameState m_currentState;
        private MainUIModel m_mainUiModel;
        private GameObject m_uiPrefab;
        private EndGameUIView m_endGameView;
        private Transform m_uiRoot;
        public EndGameUIController(Transform uiRoot, MainUIModel mainUIModel, GameState currentState)
        {
            m_mainUiModel = mainUIModel; m_uiRoot = uiRoot;
            m_uiPrefab = Resources.Load<GameObject>(GameobjectsNameKeys.EndGameMenu);
            m_currentState = currentState;
        }
        public void OnEnterExecute()
        {
            var obj = GameObject.Instantiate(m_uiPrefab, m_uiRoot);
            m_endGameView = obj.GetComponent<EndGameUIView>();
            m_endGameView.Restart.onClick.AddListener(() => m_currentState.changeStateRequest?.Invoke(GameStateIndex.Game));
        }

        public void OnExitExecute()
        {
            m_endGameView.Restart.onClick.RemoveAllListeners();
            GameObject.Destroy(m_endGameView.gameObject);
        }
    }

}
