using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    BulletSpawner spawner;
    BulletController bulletController;
    [SerializeField] private Rigidbody bulletRigidbody;
    BulletType bulletType;
    public MeshRenderer[] childs;
    public BulletView(BulletType bulletType)
    {
        this.bulletType = bulletType;
    }
    void Start()
    {
        
    }

    void Update()
    {
        BulletMovement();
    }
    void BulletMovement()
    {
        
    }
    public Rigidbody GetRigidbody() { return bulletRigidbody; }
    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
    public void ChangeColour(Material colour)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = colour;
        }
    }
}
