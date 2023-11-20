using UnityEngine;

public class KeyboardInputController : IBaseController, IUpdateController
{
    private InputModel m_inputModel;
    public KeyboardInputController(InputModel inputModel) 
    {
        m_inputModel = inputModel;
    }
    public void OnUpdateExecute()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        m_inputModel.steer = horizontalInput;

        m_inputModel.acceletarion = verticalInput;
        m_inputModel.brake = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }
}
