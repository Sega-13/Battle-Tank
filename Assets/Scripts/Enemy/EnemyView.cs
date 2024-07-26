using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour,IDamageable
{
    EnemyController enemyController;
    private EnemyState currentState;


    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform gun;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Slider healthBar;

    [SerializeField] public EnemyAttack enemyAttackState;
    [SerializeField] public EnemyChase enemyChaseState;
    [SerializeField] public EnemyIdle enemyIdleState;
    [SerializeField] public EnemyPatrol enemyPatrolState;
    public MeshRenderer[] childs;
    void Start()
    {
        agent.speed = GetEnemySpeed();
        agent.stoppingDistance = 1f;

        ChangeState(enemyIdleState);
    }
    private void Update()
    {
        currentState.Tick();

        enemyController.UpdateHealthBar();
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public float GetEnemySpeed()
    {
        return enemyController.GetSpeed();
    }
    public void ChangeState(EnemyState newState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = newState;
        currentState.OnStateEnter();
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    public Transform GetPlayerTransform()
    {
        return enemyController.GetPlayerTransform();
    }
    public float GetEnemyDetectionRange()
    {
        return enemyController.GetDetectionRange();
    }
    public float GetEnemyVisibilityRange()
    {
        return enemyController.GetVisibilityRange();
    }
    public NavMeshAgent GetAgent()
    {
        return agent;
    }
    public float GetEnemyRotationSpeed()
    {
        return enemyController.GetRotationSpeed();
    }
    public float GetEnemyBPM()
    {
        return enemyController.GetBulletsPerMinute();
    }
    public void EnemyShootBullet()
    {
        enemyController.Shoot(gun);
    }
    public Material GetColor()
    {
        return enemyController.GetColor();
    }
    public Slider GetHealthBar()
    {
        return healthBar;
    }
    public int GetEnemyStrength()
    {
        return enemyController.GetStrength();
    }
    public void TakeDamage(int damage, TankType tankType)
    {
        if (tankType == TankType.Blue || tankType == TankType.Red || tankType == TankType.Green)
        {
            enemyController.TakeDamage(damage);
        }
    }
    
    public void ChangeColour(Material colour)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = colour;
        }
    }
}
