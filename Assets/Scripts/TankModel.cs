using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    TankController tankController;
    public TankModel()
    {

    }
    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
