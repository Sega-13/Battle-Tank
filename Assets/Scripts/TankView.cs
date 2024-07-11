using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;
    private float roatation;
    private float movement;
    public Rigidbody rb;
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
    }

    void Update()
    {
        TankMovement();
        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }
        if(roatation != 0)
        {
            tankController.Rotate(roatation, tankController.GetTankModel().roatationSpeed);
        }

    }
    private void TankMovement()
    {
        movement = Input.GetAxis("Vertical");
        roatation = Input.GetAxis("Horizontal");
    }
    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
    public Rigidbody GetRigidbody() { return rb; }
}
