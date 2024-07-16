using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankSelection : MonoBehaviour
{
    private TankType tankType;
    public TankSpawner tankSpawner;
    [SerializeField] GameObject skinSelectionPanel;
    [SerializeField] GameObject heatlhBarPanel;

    public TankType GetTankType() { return tankType; }
    public void SetTankType(TankType tankType)
    {
        this.tankType = tankType;
    }
    public void BlueTankSelected()
    {
        tankSpawner.CreateTank(TankType.Blue);
        skinSelectionPanel.SetActive(false);
        heatlhBarPanel.SetActive(true);
        SetTankType(TankType.Blue);
    }
    public void GreenTankSelected()
    {
        tankSpawner.CreateTank(TankType.Green);
        this.gameObject.SetActive(false);
        SetTankType(TankType.Green);
    }
    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankType.Red);
        this.gameObject.SetActive(false);
        SetTankType(TankType.Red);
    }
}
