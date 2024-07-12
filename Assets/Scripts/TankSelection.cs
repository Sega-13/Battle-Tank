using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public TankSpawner tankSpawner;
    public void BlueTankSelected()
    {
        tankSpawner.CreateTank(TankType.Blue);
        this.gameObject.SetActive(false);
    }
    public void GreenTankSelected()
    {
        tankSpawner.CreateTank(TankType.Green);
        this.gameObject.SetActive(false);
    }
    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankType.Red);
        this.gameObject.SetActive(false);
    }
}
