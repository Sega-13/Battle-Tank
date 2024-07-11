using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    TankController tankController;

    public float movementSpeed;
    public float roatationSpeed;
    public TankModel(float movementSpeed, float roatationSpeed)
    {
        this.movementSpeed = movementSpeed;
        this.roatationSpeed = roatationSpeed;
    }
    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
