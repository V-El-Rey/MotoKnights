using Assets.Scripts.Main.Models;
using log4net.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : IBaseController, IUpdateController
{
    private InputModel m_enemyInputModel;
    private EnemyModel m_enemyModel;
    private PlayerModel m_playerModel;
    public EnemyController(EnemyModel enemyModel, PlayerModel playerModel, InputModel inputModel)
    {
        m_enemyModel = enemyModel;
        m_enemyInputModel = inputModel;
        m_playerModel = playerModel;
    }
    public void OnUpdateExecute()
    {
        //���� ��������� ���� � ����������� ����, ���� ��� �����
        RaycastHit hit;
        //��� ���, ���������� �� ������� ����� ������� � ��������� � ������� ����
        Ray ray = new Ray(m_enemyModel.EnemyView.objectTransform.position, m_enemyModel.EnemyView.objectTransform.forward);
        //������� ���
        Physics.Raycast(ray, out hit);

        //���� ��� � ���-�� ��������, ��..
        if (hit.collider != null)
        {
            //���� ��� �� ����� � ����
            if (hit.collider.gameObject.tag != "Player")
            {
                m_enemyInputModel.acceletarion = 0.2f;

                Vector3 targetDir = m_playerModel.PlayerView.objectTransform.position - m_enemyModel.EnemyView.objectTransform.position;
                Vector3 forward = m_enemyModel.EnemyView.objectTransform.forward;
                float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
                if (angle < -5.0F)
                    m_enemyInputModel.steer = 1;
                else if (angle > 5.0F)
                    m_enemyInputModel.steer = -1;
                else
                    m_enemyInputModel.steer = 0;

                // Debug.Log("���� � ����� ����������� ������: " + hit.collider.name);
            }
            //���� ��� ����� � ����
            else
            {
                if (Vector3.SqrMagnitude(hit.collider.gameObject.transform.position - m_enemyModel.EnemyView.objectTransform.position) >= 20 * 20)
                {
                    m_enemyInputModel.acceletarion = 1;
                }
            }
            //������ ��� ����������� ������ ��� � ���� Scene
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
}
