using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
