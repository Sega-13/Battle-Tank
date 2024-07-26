using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    TankSpawner tankSpawner;
    TankModel tankModel;
    TankView tankView;
    private Rigidbody tankRigidbody;
    private int health;
    BulletSpawner bulletSpawner;
    public TankController(TankModel tankModel, TankView _tankView,TankSpawner tankSpawner)
    {
        this.tankModel = tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankRigidbody = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColour(tankModel.tankColor);
        this.tankSpawner = tankSpawner;
        health = tankModel.health;
        EventService.Instance.InvokeSetMaxHealthBar(health);
        EventService.Instance.InvokeSetPlayerHealthBar(health);
    }

    public void Move(float movement, float movementSpeed)
    {
        tankRigidbody.velocity = tankView.transform.forward*movement*movementSpeed;
    }
    public void Rotate(float rotate, float rotateSpeed)
    {
        Vector3 vector = new Vector3(0f,rotate*rotateSpeed,0f);
        Quaternion deltaRotation = Quaternion.Euler(vector*Time.deltaTime);
        tankRigidbody.MoveRotation(tankRigidbody.rotation*deltaRotation);
    }
    public TankModel GetTankModel()
    {
        return tankModel;
    }
    public void Shoot(Transform gun)
    {
        tankSpawner.ShootBullet(gun);
       
    }
    public Transform GetTransform()
    {
        return tankRigidbody.transform;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        EventService.Instance.InvokeSetPlayerHealthBar(health);
        if (health <= 0)
            TankDeath();
    }
    private void TankDeath()
    {
        EventService.Instance.InvokeGameOver();
        tankSpawner.DestoryTank(tankView);
    }
}
