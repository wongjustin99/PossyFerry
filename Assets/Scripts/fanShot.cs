using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class fanShot : Shot
{

    public fanShot(bool isEnemy, Vector2 pos)
    {
        if (isEnemy)
            this.speedX = -5.0f;
        else
            this.speedX = 5.0f;
        this.speedY = 0f;

        placeShot(new shotComponent(this.speedX, this.speedX / 2, pos), isEnemy);
        placeShot(new shotComponent(this.speedX, this.speedX / 4, pos), isEnemy);
        placeShot(new shotComponent(this.speedX, this.speedY, pos), isEnemy);
        placeShot(new shotComponent(this.speedX, -this.speedX / 4, pos), isEnemy);
        placeShot(new shotComponent(this.speedX, -this.speedX / 2, pos), isEnemy);
        ListenForUpdate(HandleUpdate);
    }

    public void HandleUpdate()
    {
    }

}