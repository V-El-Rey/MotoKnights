using UnityEngine;

namespace Assets.Scripts.Main.Controllers
{
    public class InputUIController : IBaseController, IEnterController, IExitController
    {
        private GameObject m_uiPrefab;
        private InputUIView m_gameUIView;
        private Transform m_uiRoot;

        private InputModel m_inputModel;

        public InputUIController(Transform uiRoot, InputModel inputModel)
        {
            m_inputModel = inputModel;
            m_uiRoot = uiRoot;
            m_uiPrefab = Resources.Load<GameObject>(GameobjectsNameKeys.InputUI);
        }
        public void OnEnterExecute()
        {
            var obj = GameObject.Instantiate(m_uiPrefab, m_uiRoot);
            m_gameUIView = obj.GetComponent<InputUIView>();
            m_gameUIView.Gas.onButtonDown += SetAcceleration;
            m_gameUIView.Brake.onButtonDown += SetBrake;
            m_gameUIView.Left.onButtonDown += SetLeftSteer;
            m_gameUIView.Right.onButtonDown += SetRightSteer;
            m_gameUIView.Gas.onButtonUp += ReleaseAcceleration;
            m_gameUIView.Brake.onButtonUp += ReleaseBrake;
            m_gameUIView.Left.onButtonUp += ResetSteer;
            m_gameUIView.Right.onButtonUp += ResetSteer;
        }

        private void SetRightSteer() => m_inputModel.steer = 1;
        private void SetLeftSteer() => m_inputModel.steer = -1;
        private void ResetSteer() => m_inputModel.steer = 0;
        private void SetBrake() => m_inputModel.brake = 1;
        private void ReleaseBrake() => m_inputModel.brake = 0;
        private void SetAcceleration() => m_inputModel.acceleration = 1;
        private void ReleaseAcceleration() => m_inputModel.acceleration = 0;

        public void OnExitExecute()
        {
            m_gameUIView.Gas.onButtonDown -= SetAcceleration;
            m_gameUIView.Brake.onButtonDown -= SetBrake;
            m_gameUIView.Left.onButtonDown -= SetLeftSteer;
            m_gameUIView.Right.onButtonDown -= SetRightSteer;
            m_gameUIView.Gas.onButtonUp -= ReleaseAcceleration;
            m_gameUIView.Brake.onButtonUp -= ReleaseBrake;
            m_gameUIView.Left.onButtonUp -= ResetSteer;
            m_gameUIView.Right.onButtonUp -= ResetSteer;
            GameObject.Destroy(m_gameUIView.gameObject);
        }
    }
}
