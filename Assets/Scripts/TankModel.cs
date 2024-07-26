using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    TankController tankController;

    public float movementSpeed;
    public float roatationSpeed;
    public TankType tankType;
    public Material tankColor;
    public int health;

    public TankModel(float movementSpeed, float roatationSpeed, TankType tankType, Material tankColor, int health)
    {
        this.movementSpeed = movementSpeed;
        this.roatationSpeed = roatationSpeed;
        this.tankType = tankType;
        this.tankColor = tankColor;
        this.health = health;
    }
    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
