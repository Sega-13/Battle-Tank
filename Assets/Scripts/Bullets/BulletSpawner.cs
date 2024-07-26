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
   
    [SerializeField] private BulletView bulletView;
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    public void SpawnBullet(BulletType bulletType, Transform gunTransform,TankType tankType)
    {
        switch (bulletType)
        {
            case BulletType.Sniper:
                BulletModel bulletModel = new BulletModel(bullet[0].speed, bullet[0].damageValue, bullet[0].color, bullet[0].bulletType);
                BulletController bulletController = new BulletController(bulletModel, bulletView,this);
                bulletController.EnableBullet(gunTransform, tankType);
                break;
            case BulletType.Assault:
                BulletModel bulletModelAssault = new BulletModel(bullet[1].speed, bullet[1].damageValue, bullet[1].color, bullet[1].bulletType);
                BulletController bulletControllerAssault = new BulletController(bulletModelAssault, bulletView,this);
                bulletControllerAssault.EnableBullet(gunTransform, tankType);
                break;
            case BulletType.Pistol:
                BulletModel bulletModelPistol = new BulletModel(bullet[2].speed, bullet[2].damageValue, bullet[2].color, bullet[2].bulletType);
                BulletController bulletControllerPistol = new BulletController(bulletModelPistol, bulletView,this);
                bulletControllerPistol.EnableBullet(gunTransform, tankType);
                break;
        }
    }
    public void BulletExplosion(BulletController bulletController, Vector3 position, BulletView bulletView, BulletType bulletType)
    {
        bulletController.DisableBullet();
    }

    }
