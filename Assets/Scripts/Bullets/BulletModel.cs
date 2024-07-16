using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel 
{
    BulletController bulletController;
    public int speed;
    public int damageValue;
    public Material colour;
    BulletType bulletType;
    public TankType tankType { private set; get; }
    public BulletModel(int speed, int damageValue,Material colour,BulletType bulletType)
    {
        this.speed = speed;
        this.damageValue = damageValue;
        this.colour = colour;
        this.bulletType = bulletType;
    }
    public void SetTankType(TankType _tankType)
    {
        tankType = _tankType;
    }
    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}
