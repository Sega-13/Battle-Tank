using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float momentemSpeed;
        public float rotationSpeed;
        public TankType tankType;
        public Material colour;
    }
    public List<Tank> tankList;
    public TankView tankView;
    void Start()
    {
    }
    public void CreateTank(TankType tankType)
    {
        if(tankType == TankType.Green)
        {
            TankModel tankModel = new TankModel(tankList[0].momentemSpeed, tankList[0].rotationSpeed, tankList[0].tankType, tankList[0].colour);
            TankController tankController = new TankController(tankModel, tankView);
        }
        if(tankType == TankType.Blue)
        {
            TankModel tankModel = new TankModel(tankList[1].momentemSpeed, tankList[1].rotationSpeed, tankList[1].tankType, tankList[1].colour);
            TankController tankController = new TankController(tankModel, tankView);
        }
        if(tankType == TankType.Red)
        {
            TankModel tankModel = new TankModel(tankList[2].momentemSpeed, tankList[2].rotationSpeed, tankList[2].tankType, tankList[2].colour);
            TankController tankController = new TankController(tankModel, tankView);
        }
        
    }
    
}
