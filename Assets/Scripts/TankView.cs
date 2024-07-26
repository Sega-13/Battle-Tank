using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour,IDamageable
{
    TankController tankController;
    private float roatation;
    private float movement;
    public Rigidbody rb;
    public MeshRenderer[] childs;
    [SerializeField] private Transform gun;
    bool isKeyPressed;
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
        EventService.Instance.OnPlayerShoot += PlayerShootBullet;
    }

    void Update()
    {
        isKeyPressed = false;
        TankMovement();
        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }
        if(roatation != 0)
        {
            tankController.Rotate(roatation, tankController.GetTankModel().roatationSpeed);
        }
        if (Input.GetKeyDown(KeyCode.F) && !isKeyPressed)
        {
            tankController.Shoot(gun);
        }if (Input.GetKeyUp(KeyCode.F))
        {
            isKeyPressed=true;
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
    public void ChangeColour(Material colour)
    {
        for(int i = 0; i < childs.Length; i++)
        {
            childs[i].material = colour;
        }
    }
    
    void IDamageable.TakeDamage(int damage, TankType tankType)
    {
        if(tankType == TankType.EnemyBlack || tankType == TankType.EnemyBrown || tankType == TankType.EnemyPurple)
        {
            tankController.TakeDamage(damage);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        /*if (col.gameObject.GetComponent<EnemyView>() != null)
        {
            EnemyView enemyView = col.gameObject.GetComponent<EnemyView>();
            tankController.TakeDamage(enemyView.GetEnemyStrength());
        }*/
    }
    private void PlayerShootBullet()
    {
        tankController.Shoot(gun);
    }
    private void OnDestroy()
    {
        EventService.Instance.OnPlayerShoot -= PlayerShootBullet;
    }
}
