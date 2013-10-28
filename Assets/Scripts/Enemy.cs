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
	
	private Shot _shot;
	private List<Shot> _shots = new List<Shot>();
	
	
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
			_shot = new Shot(-5.0f, 0.0f);
			_shot.x = this.x;
			_shot.y = this.y;
			ShotContainer.addEnemyShotToContainer(_shot);
		}
		
		for(int b = _shots.Count - 1; b>=0; b--)
		{
			Shot shotted = _shots[b];
			if(shotted.x < -Futile.screen.halfWidth)
				ShotContainer.deleteEnemyShotFromContainer(shotted);
		}
		
		frameCount += 1;
	}
	
	public List<Shot> getShots()
	{
		return _shots;
	}
}