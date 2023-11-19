using Assets.Scripts.Main.Models;
using UnityEngine;

namespace Assets.Scripts.Main.Controllers
{
    public class InputUIController : IBaseController, IEnterController, IExitController
    {
        private GameObject m_uiPrefab;
        private GameUIView m_gameUIView;
        private Transform m_uiRoot;

        public InputUIController(Transform uiRoot)
        {
            m_uiRoot = uiRoot;
            m_uiPrefab = Resources.Load<GameObject>(GameobjectsNameKeys.MainUI);
        }
        public void OnEnterExecute()
        {
            var obj = GameObject.Instantiate(m_uiPrefab, m_uiRoot);
            m_gameUIView = obj.GetComponent<GameUIView>();
        }

        public void OnExitExecute()
        {
            GameObject.Destroy(m_gameUIView.gameObject);
        }
    }
}
