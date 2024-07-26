using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController
{
    EnemySpawner enemySpawner;
    EnemyView enemyView;
    EnemyModel enemyModel;

    private int health;
    private Camera playerCamera;
    private Canvas enemyCanvas;
    private Transform playerTransform;
    private Transform enemyTransform;
    private Slider healthBar;
    private Material color;
    public EnemyController(EnemyScriptableObject enemyData, EnemySpawner enemySpawner ,EnemyType enemyType, Camera _playerCamera, Canvas _enemyCanvas)
    {
        enemyView = GameObject.Instantiate<EnemyView>(enemyData.enemyView);
        enemyModel = new EnemyModel(enemyData, enemyType);

        health = enemyModel.health;
        playerCamera = _playerCamera;
        enemyCanvas = _enemyCanvas;
        healthBar = enemyView.GetHealthBar();
        enemyTransform = enemyView.transform;
        color = enemyData.color;

        enemyView.SetEnemyController(this);
        enemyModel.SetEnemyController(this);
        this.enemySpawner = enemySpawner;
        enemyView.ChangeColour(enemyModel.color);
        SetupHealthBar();
    }
    public float GetSpeed()
    {
        return enemyModel.speed;
    }
    public int GetStrength()
    {
        return enemyModel.strength;
    }
    public void EnableEnemyTank(Transform _playerTransform, Vector3 _newPosition)
    {
        health = enemyModel.health;
        healthBar.value = enemyModel.health;
        healthBar.gameObject.SetActive(true);

        playerTransform = _playerTransform;
        enemyView.transform.position = _newPosition;
        enemyView.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        enemyView.gameObject.SetActive(true);
    }
    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
    public float GetDetectionRange()
    {
        return enemyModel.detectionRange;
    }
    public float GetVisibilityRange()
    {
        return enemyModel.visibilityRange;
    }
    public float GetRotationSpeed()
    {
        return enemyModel.rotationSpeed;
    }
    public float GetBulletsPerMinute()
    {
        return enemyModel.bpm;
    }
    public Material GetColor()
    {
        return enemyModel.color;
    }
    public Vector3 GetPosition()
    {
        return enemyView.transform.position;
    }
    public void Shoot(Transform gunTransform)
    {
        enemySpawner.ShootBullet(enemyModel.bulletType, gunTransform);
    }
    public void UpdateHealthBar()
    {
        healthBar.transform.LookAt(healthBar.transform.position + playerCamera.transform.rotation * Vector3.back, playerCamera.transform.rotation * Vector3.up);
        healthBar.transform.localPosition = new Vector3(enemyTransform.position.x, 9, enemyTransform.position.z);
    }
    public void DisableEnemyTank()
    {
        healthBar.transform.localPosition = Vector3.zero;
        healthBar.gameObject.SetActive(false);
        enemyView.gameObject.SetActive(false);
    }
    private void SetupHealthBar()
    {
        healthBar.transform.SetParent(enemyCanvas.transform, false);
        healthBar.maxValue = enemyModel.health;
    }
   
    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.value = health;

        if (health <= 0)
            EnemyDeath();
    }
    private void EnemyDeath()
    {
        enemySpawner.DestoryEnemy(this, enemyModel.enemyType);
    }
}
