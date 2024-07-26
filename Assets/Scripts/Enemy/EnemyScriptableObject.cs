using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    public int speed;
    public int strength;
    public int bpm;

    public float rotationSpeed;
    public float visibilityRange;
    public float detectionRange;
    public Material color;

    public BulletType bulletType;
    public EnemyView enemyView;
}
