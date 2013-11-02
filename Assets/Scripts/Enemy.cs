using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Enemy :  FSprite
{
	private float speedX = 3.0f;
	private float speedY = 0.0f;
	private float shotrate = RXRandom.Range (60.0f,80.0f);
	private float frameCount = 0;
	//private Shot _shot;
	
	public Enemy() : base("Monkey_0")
	{
		
		this.x = Futile.screen.halfWidth;
		this.y = RXRandom.Range(-Futile.screen.halfHeight, Futile.screen.halfHeight);
		this.scale = 0.25f;
		ListenForUpdate (HandleUpdate);
		
	}
	
	public void HandleUpdate()
	{
		
		this.x -= speedX;
		this.y += speedY;

		// enemy shoots
		if(frameCount%shotrate == 0)
		{
			Shot _shot = new Shot(this.x, this.y, -5.0f, 0.0f);
			ShotManager.addEnemyShot(_shot);
		}
		frameCount += 1;
	}
}