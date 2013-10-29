using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class basicShot :  Shot
{

    public basicShot(bool isEnemy, Vector2 pos)
        : base("Banana")
	{

        this.x = pos.x;
        this.y = pos.y;

		this.scale = 0.25f;
        if (isEnemy)
            this.speedX = -5.0f;
        else
            this.speedX = 5.0f;
        this.speedY = 0f;

        placeShot(this, isEnemy);
		ListenForUpdate (HandleUpdate);
	}

    public void HandleUpdate()
    {
        this.x += speedX;
        this.y += speedY;
    }
	
}