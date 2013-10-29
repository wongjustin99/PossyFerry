using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class shotComponent : Shot
{

    public shotComponent(float speedX, float speedY, Vector2 pos)
        : base("Banana")
    {
        this.x = pos.x;
        this.y = pos.y;
        this.scale = 0.25f;
        
        this.speedX = speedX;
        this.speedY = speedY;

        ListenForUpdate(HandleUpdate);
    }

    public void HandleUpdate()
    {
        this.x += speedX;
        this.y += speedY;
    }

}