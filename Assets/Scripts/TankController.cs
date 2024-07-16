using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    TankSpawner tankSpawner;
    TankModel tankModel;
    TankView tankView;
    private Rigidbody tankRigidbody;
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
        /*if(tankType == TankType.Blue)
        {
            tankSpawner.ShootBullet(BulletType.Sniper, gun);
        }else if(tankType == TankType.Green)
        {
            tankSpawner.ShootBullet(BulletType.Assault, gun);
        }
        else if( tankType == TankType.Red)
        {
            tankSpawner.ShootBullet(BulletType.Pistol, gun);
        }*/
        
    }
    
}
