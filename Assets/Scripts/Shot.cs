using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Shot :  FSprite
{
	
	private float speedX = 0.0f;
	private float speedY = 0.0f;
	
	public Shot(float speedX, float speedY) : base("Banana")
	{
		this.scale = 0.25f;
		this.speedX = speedX;
		this.speedY = speedY;
		ListenForUpdate (HandleUpdate);
	}
	
	public void HandleUpdate()
	{
		this.x += speedX;
		this.y += speedY;
	}
	
}