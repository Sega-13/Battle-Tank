using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Bullet
    {
        public int speed;
        public int damageValue;
        public BulletType bulletType;
        public Material color;

    }
    [SerializeField] private List<Bullet> bullet;
   /* [SerializeField] private int speed;
    [SerializeField] private int damageValue;
    [SerializeField] private BulletType bulletType;
    [SerializeField] private Material color;*/
    [SerializeField] private BulletView bulletView;
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    public void SpawnBullet(BulletType bulletType, Transform gunTransform)
    {
        switch (bulletType)
        {
            case BulletType.Sniper:
                BulletModel bulletModel = new BulletModel(bullet[0].speed, bullet[0].damageValue, bullet[0].color, bullet[0].bulletType);
                //BulletModel bulletModel = new BulletModel(speed, damageValue);
                BulletController bulletController = new BulletController(bulletModel, bulletView);
                bulletController.EnableBullet(gunTransform, TankType.Blue);
                break;
            case BulletType.Assault:
                BulletModel bulletModelAssault = new BulletModel(bullet[1].speed, bullet[1].damageValue, bullet[1].color, bullet[1].bulletType);
                BulletController bulletControllerAssault = new BulletController(bulletModelAssault, bulletView);
                bulletControllerAssault.EnableBullet(gunTransform, TankType.Green);
                break;
            case BulletType.Pistol:
                BulletModel bulletModelPistol = new BulletModel(bullet[2].speed, bullet[2].damageValue, bullet[2].color, bullet[2].bulletType);
                BulletController bulletControllerPistol = new BulletController(bulletModelPistol, bulletView);
                bulletControllerPistol.EnableBullet(gunTransform, TankType.Red);
                break;
        }
    }
}
