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

    ShotStrategy _shotStrategy;
	
  public Enemy( float x, float y ) : this()
  {
    this.x = x;
    this.y = y;
  }

	public Enemy() : base("Monkey_0")
	{
		this.x = Futile.screen.halfWidth;
		this.y = RXRandom.Range(-Futile.screen.halfHeight, Futile.screen.halfHeight);
    // once the sprites are swopped out, this needs to be forgone for
    // sprites with proper resolution in the first place 
		this.scale = 0.25f;
		ListenForUpdate (HandleUpdate);
	}

    public void setShotStrategy( ShotStrategy _shotStrategy )
    {
        this._shotStrategy = _shotStrategy;
    }
	
	public void HandleUpdate()
	{
		
		this.x -= speedX;
		this.y += speedY;

		// enemy shoots
		if(frameCount%shotrate == 0)
		{
            _shotStrategy.shoot(this.x, this.y, true);
		}
		frameCount += 1;
	}
}
