using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Shot : FSprite
{

    protected float speedX = 0.0f;
    protected float speedY = 0.0f;

    public Shot() { }
    //pass texture name to FSprite to create the shot
    public Shot(String p)
        : base(p)
    {}

    protected void placeShot(Shot s, bool isEnemy)
    {
        if (isEnemy)
            ShotContainer.addEnemyShot(s);
        else
            ShotContainer.addPlayerShot(s);
    }
}