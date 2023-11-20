using Assets.Scripts.Main.Models;
using UnityEngine;

public class EnemyController : IBaseController, IUpdateController
{
    private InputModel m_enemyInputModel;
    private EnemyModel m_enemyModel;
    private PlayerModel m_playerModel;

    private float m_cooldown;
    public EnemyController(EnemyModel enemyModel, PlayerModel playerModel, InputModel inputModel)
    {
        m_enemyModel = enemyModel;
        m_enemyInputModel = inputModel;
        m_playerModel = playerModel;
        m_enemyModel.currentEnemyState = EnemyState.Attack;
        m_cooldown = m_enemyModel.attackCooldown;
    }
    public void OnUpdateExecute()
    {
        RaycastHit hit;
        Ray ray = new Ray(m_enemyModel.EnemyView.objectTransform.position, m_enemyModel.EnemyView.objectTransform.forward);
        Physics.Raycast(ray, out hit);
        var angle = HandleAngleBetweenPlayer();
       
        Debug.Log(m_enemyModel.currentEnemyState);
        switch (m_enemyModel.currentEnemyState)
        {
            case EnemyState.Attack:
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.tag != "Player")
                        {
                            m_enemyInputModel.acceleration = 0.2f;
                            if (angle < -5.0F)
                                m_enemyInputModel.steer = 1;
                            else if (angle > 5.0F)
                                m_enemyInputModel.steer = -1;
                            else
                                m_enemyInputModel.steer = 0;
                        }
                        else
                        {
                            if (Vector3.SqrMagnitude(m_playerModel.PlayerView.objectTransform.position - m_enemyModel.EnemyView.objectTransform.position) >= m_enemyModel.sqrDistance)
                            {
                                m_enemyInputModel.acceleration = 1;
                            }
                            if (Vector3.SqrMagnitude(m_playerModel.PlayerView.objectTransform.position - m_enemyModel.EnemyView.objectTransform.position) <= 1.7*1.7)
                            {
                                m_enemyModel.currentEnemyState = EnemyState.Stop;
                            }
                        }
                        Debug.DrawLine(ray.origin, hit.point, Color.red);
                    }
                }
                break;
            case EnemyState.Retreat:
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.tag == "Walls")
                        {
                            if (Vector3.SqrMagnitude(hit.collider.gameObject.transform.position - m_enemyModel.EnemyView.objectTransform.position) <= 4 * 4)
                            {
                                m_enemyInputModel.acceleration = -1;
                            }
                            else
                            {
                                m_enemyInputModel.acceleration = 0;
                            }
                        }
                        if (hit.collider.gameObject.tag != "Player")
                        {
                            if (Vector3.SqrMagnitude(m_playerModel.PlayerView.objectTransform.position - m_enemyModel.EnemyView.objectTransform.position) >= m_enemyModel.sqrDistance)
                            {
                                m_enemyModel.currentEnemyState = EnemyState.Attack;
                            }
                        }
                        else
                        {
                            m_enemyInputModel.acceleration = 0.5f;
                            if (angle < -160.0F)
                                m_enemyInputModel.steer = -1;
                            else if (angle > 160.0F)
                                m_enemyInputModel.steer = 1;
                            else
                                m_enemyInputModel.steer = 0;
                        }
                        Debug.DrawLine(ray.origin, hit.point, Color.red);
                    }
                }
                break;
            case EnemyState.Stop:
                {
                    m_enemyInputModel.acceleration = 0;
                    m_enemyInputModel.brake = 1;
                    m_enemyInputModel.steer = 0;
                    m_cooldown -= Time.deltaTime;
                    Debug.Log(m_cooldown);
                    if(m_cooldown <= 0.0f)
                    {
                        m_enemyModel.currentEnemyState = EnemyState.GetBack;
                        m_cooldown = m_enemyModel.attackCooldown;
                    }

                }
                break;
            case EnemyState.GetBack:
                {
                    m_enemyInputModel.brake = 0;
                    m_enemyInputModel.steer = 0;
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.tag == "Player")
                        {
                            if (Vector3.SqrMagnitude(hit.collider.gameObject.transform.position - m_enemyModel.EnemyView.objectTransform.position) <= 4 * 4)
                            {
                                m_enemyInputModel.acceleration = -1;
                            }
                        }
                        else
                        {
                            m_enemyModel.currentEnemyState = EnemyState.Retreat;
                        }
                    }
                }
                break;
        }
    }
    private float HandleAngleBetweenPlayer()
    {
        Vector3 targetDir = m_playerModel.PlayerView.objectTransform.position - m_enemyModel.EnemyView.objectTransform.position;
        Vector3 forward = m_enemyModel.EnemyView.objectTransform.forward;
        return Vector3.SignedAngle(targetDir, forward, Vector3.up);
        //if (angle < -5.0F)
        //    m_enemyInputModel.steer = 1;
        //else if (angle > 5.0F)
        //    m_enemyInputModel.steer = -1;
        //else
        //    m_enemyInputModel.steer = 0;
    }
}
