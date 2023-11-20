using log4net.Util;
using System;
using UnityEngine;

public class MotorcycleController : IBaseController, IFixedUpdateController
{
    private MotorcycleView m_motorcycleView;
    private InputModel m_inputModel;

    private Vector3 uprightTarget = Vector3.up;
    private float uprightTorque = 1f;

    public MotorcycleController(MotorcycleView view, InputModel inputModel)
    {
        m_motorcycleView = view;
        m_inputModel = inputModel;
    }
    public void OnFixedUpdateExecute()
    {
        if (m_inputModel.acceletarion != 0)
        {
            m_motorcycleView.WheelF.brakeTorque = 0;
            m_motorcycleView.WheelR.brakeTorque = 0;
            m_motorcycleView.WheelR.motorTorque = Mathf.Clamp(m_inputModel.torqueCoeff * m_inputModel.acceletarion, -m_inputModel.maxSpeed, m_inputModel.maxSpeed);
        }
        else
        {
            m_motorcycleView.WheelR.motorTorque = 0;
        }

        if (m_inputModel.brake != 0)
        {
            m_motorcycleView.WheelF.brakeTorque = m_inputModel.brakeCoeff;
            m_motorcycleView.WheelR.brakeTorque = m_inputModel.brakeCoeff;
        }
        else
        {
            m_motorcycleView.WheelF.brakeTorque = 0;
            m_motorcycleView.WheelR.brakeTorque = 0;
        }
        if (m_inputModel.steer != 0)
        {
            m_motorcycleView.WheelF.steerAngle = m_inputModel.maxSteeringAngle * m_inputModel.steer;
        }
        else
        {
            m_motorcycleView.WheelF.steerAngle = 0;
        }
        var rotationDiff = Quaternion.FromToRotation(m_motorcycleView.objectTransform.up, uprightTarget);
        m_motorcycleView.rb.AddTorque(new Vector3(rotationDiff.x, rotationDiff.y, rotationDiff.z) * uprightTorque, ForceMode.Acceleration);
    }
}
