using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletModel bulletModel;
    BulletView bulletView;
    private Rigidbody bulletRigidBody;

    public BulletController(BulletModel bulletModel, BulletView _bulletView)
    {
        this.bulletModel = bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView);
        bulletRigidBody = bulletView.GetRigidbody();
        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);
        bulletView.ChangeColour(bulletModel.colour);
    }

    public void EnableBullet(Transform gunTransform, TankType tankType)
    {
        SetBulletTankType(tankType);

        bulletRigidBody.transform.position = gunTransform.position;
        bulletRigidBody.transform.rotation = gunTransform.rotation;

        bulletRigidBody.gameObject.SetActive(true);
        Shoot();
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
}