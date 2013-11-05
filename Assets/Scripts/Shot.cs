using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Shot :  FSprite
{
	
	private float speedX = 0.0f;
	private float speedY = 0.0f;
	
	public Shot(float x, float y, bool isEnemy) : base("Banana")
	{
        this.x = x;
        this.y = y;
		this.scale = 0.25f;
        int direction = isEnemy ? -1 : 1;
        this.speedX = 5*direction;
		this.speedY = 0;
		ListenForUpdate (HandleUpdate);
	}

    public Shot(float x, float y, bool isEnemy,float angle)
        : base("Banana")
    {
        this.x = x;
        this.y = y;
        this.scale = 0.25f;
        int direction = isEnemy ? -1 : 1;
        this.speedX = Mathf.Cos(angle) * direction * 5;
        this.speedY = Mathf.Sin(angle) * 5;
        ListenForUpdate(HandleUpdate);
    }

    // overloaded constructor, for angled shots
//	public Shot(float x, float y, bool isEnemy, float angle) : this(x, y, isEnemy)
//	{
 //       int direction = isEnemy ? -1 : 1;
 //       this.speedX = Mathf.Cos(angle) * direction * speedX;
 //       this.speedY = Mathf.Sin(angle) * speedX;
       
//	}
	
	public void HandleUpdate()
	{
		this.x += speedX;
		this.y += speedY;
	}

}