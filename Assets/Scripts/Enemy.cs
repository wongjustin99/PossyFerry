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
		
		if(frameCount%shotrate == 0)
		{
			Shot _shot = new basicShot(true, this.GetPosition());
			//_shot.x = this.x;
			//_shot.y = this.y;
			//ShotContainer.addEnemyShotToContainer(_shot);
		}
		
		frameCount += 1;
	}
	

}