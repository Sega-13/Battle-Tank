using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    TankModel tankModel;
    TankView tankView;
    private Rigidbody tankRigidbody;
    public TankController(TankModel tankModel, TankView _tankView)
    {
        this.tankModel = tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankRigidbody = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColour(tankModel.tankColor);
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
}
