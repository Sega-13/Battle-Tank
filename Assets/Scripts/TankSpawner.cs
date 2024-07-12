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
        CreateTank();
    }
    void CreateTank()
    {
        TankModel tankModel = new TankModel(tankList[0].momentemSpeed, tankList[0].rotationSpeed, tankList[0].tankType, tankList[0].colour);
        TankController tankController = new TankController(tankModel, tankView);
    }
    
}
