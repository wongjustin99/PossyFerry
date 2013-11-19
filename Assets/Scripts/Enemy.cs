using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Enemy : FSprite
{
  protected ShotStrategy _shotStrategy;

  protected float health;
    

	public Enemy() : this("Monkey_0")
	{
    // default shotStrategy
    _shotStrategy = new BasicShotStrategy();
		this.x = Futile.screen.halfWidth;
		this.y = RXRandom.Range(-Futile.screen.halfHeight, Futile.screen.halfHeight);
    // once the sprites are swopped out, this needs to be forgone for
    // sprites with proper resolution in the first place 
		this.scale = 0.25f;
		ListenForUpdate (HandleUpdate);
	}

    public bool takeDamage(float damage)
    {
        bool hasDied = false;
        //change health by subtracting damage
        health = health - damage;
        //check if unit has died from this damage
        if (health <= 0)
            hasDied = true;
        
        return hasDied;

    }

  public Enemy( float x, float y ) : this()
  {
    this.x = x;
    this.y = y;
    
  }

  public Enemy( string sprite ) : base(sprite)
  {
  }

  public void setShotStrategy( ShotStrategy _shotStrategy )
  {
      this._shotStrategy = _shotStrategy;
  }
  public abstract void HandleUpdate();
}
