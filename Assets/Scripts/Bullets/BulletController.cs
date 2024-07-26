using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletModel bulletModel;
    BulletView bulletView;
    private Rigidbody bulletRigidBody;
    private BulletSpawner bulletSpawner;

    public BulletController(BulletModel bulletModel, BulletView _bulletView,BulletSpawner bulletSpawner)
    {
        this.bulletModel = bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView);
        bulletRigidBody = bulletView.GetRigidbody();
        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);
        bulletView.ChangeColour(bulletModel.colour);
        this.bulletSpawner = bulletSpawner;
    }

    public void EnableBullet(Transform gunTransform, TankType tankType)
    {
        SetBulletTankType(tankType);

        bulletRigidBody.transform.position = gunTransform.position;
        bulletRigidBody.transform.rotation = gunTransform.rotation;

        bulletRigidBody.gameObject.SetActive(true);
        Shoot();
    }
    public void DisableBullet()
    {
        bulletRigidBody.velocity = Vector3.zero;
        bulletRigidBody.angularVelocity = Vector3.zero;
        bulletRigidBody.rotation = Quaternion.identity;

        bulletRigidBody.gameObject.SetActive(false);
    }
    public void SetBulletTankType(TankType tankType)
    {
        bulletModel.SetTankType(tankType);
    }
    public TankType GetTankType()
    {
        return bulletModel.tankType;
    }
    public void Shoot()
    {
        bulletRigidBody.AddForce(bulletRigidBody.transform.forward*bulletModel.speed,ForceMode.Impulse);
    }
    public void BulletCollision(Vector3 position)
    {
        bulletRigidBody.rotation = Quaternion.identity;
        bulletSpawner.BulletExplosion(this, position, bulletView, bulletModel.bulletType);
      //  BulletService.Instance.BulletExplosion(this, position, bulletView, bulletModel.bulletType);
    }
    public int GetBulletDamage()
    {
        return bulletModel.damageValue;
    }
}