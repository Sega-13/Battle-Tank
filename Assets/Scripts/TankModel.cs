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
    public TankModel(float movementSpeed, float roatationSpeed, TankType tankType, Material tankColor)
    {
        this.movementSpeed = movementSpeed;
        this.roatationSpeed = roatationSpeed;
        this.tankType = tankType;
        this.tankColor = tankColor;
    }
    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
