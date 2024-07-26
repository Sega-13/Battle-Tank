using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    EnemyController enemyController;
    public int health { get; }
    public int speed { get; }
    public int strength { get; }
    public int bpm { get; }
    public Material color { get; }

    public float rotationSpeed { get; }
    public float visibilityRange { get; }
    public float detectionRange { get; }

    public BulletType bulletType { get; }
    public EnemyType enemyType { get; }
    public EnemyModel(EnemyScriptableObject enemy, EnemyType enemyType)
    {
        health = enemy.health;
        speed = enemy.speed;
        strength = enemy.strength;
        bpm = enemy.bpm;
        color = enemy.color;
        rotationSpeed = enemy.speed / 100f;
        visibilityRange = enemy.visibilityRange;
        detectionRange = enemy.detectionRange;

        bulletType = enemy.bulletType;
        this.enemyType = enemyType;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
}
