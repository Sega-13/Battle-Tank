using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
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
        public int health;
        
    }
    public List<Tank> tankList;
    public TankView tankView;
    [SerializeField]private BulletSpawner bulletSpawner;
    private TankType tankValue;
    TankController tankController;
    public TankHealth tankHealth;
    [SerializeField] private GameObject enemySpawner;
    //SerializeField] private CameraController mainCamera;

    void Start()
    {
    }
    public void CreateTank(TankType tankType)
    {
        if(tankType == TankType.Green)
        {
            TankModel tankModel = new TankModel(tankList[0].momentemSpeed, tankList[0].rotationSpeed, tankList[0].tankType, tankList[0].colour, tankList[0].health);
            tankController = new TankController(tankModel, tankView,this);
            tankValue = TankType.Green;
        }
        if(tankType == TankType.Blue)
        {
            TankModel tankModel = new TankModel(tankList[1].momentemSpeed, tankList[1].rotationSpeed, tankList[1].tankType, tankList[1].colour, tankList[1].health);
            tankController = new TankController(tankModel, tankView,this);
            tankValue = TankType.Blue;
        }
        if(tankType == TankType.Red)
        {
            TankModel tankModel = new TankModel(tankList[2].momentemSpeed, tankList[2].rotationSpeed, tankList[2].tankType, tankList[2].colour, tankList[2].health);
            tankController = new TankController(tankModel, tankView, this);
            tankValue = TankType.Red;
        }
        tankHealth.OnEnable();
        enemySpawner.gameObject.SetActive(true);
    }
    public void ShootBullet(Transform gunTransform)
    {
        if(tankValue == TankType.Blue)
        {
            bulletSpawner.SpawnBullet(BulletType.Sniper, gunTransform,TankType.Blue);
        }else if(tankValue == TankType.Red)
        {
            bulletSpawner.SpawnBullet(BulletType.Pistol, gunTransform,TankType.Red);
        }else if (tankValue == TankType.Green)
        {
            bulletSpawner.SpawnBullet(BulletType.Assault, gunTransform,TankType.Green);
        }
        
    }
    public Transform GetPlayerTransform()
    {
        return tankController.GetTransform();
    }
    public void DestoryTank(TankView tankView)
    {
        Vector3 pos = tankView.transform.position;

       // mainCamera.SetTankTransform(null);
        Destroy(tankView.gameObject);

        //StartCoroutine(TankExplosion(pos));
        //StartCoroutine(LevelService.Instance.DestroyLevel());
    }

}
