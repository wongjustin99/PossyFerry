using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Enemy : FSprite
{
  protected ShotStrategy _shotStrategy;

  protected float health;
	protected int points;

	public Enemy() : base("fish-fred")
  {
    this.x = Futile.screen.halfWidth;
    this.y = RXRandom.Range(-Futile.screen.halfHeight, Futile.screen.halfHeight);
    // once the sprites are swopped out, this needs to be forgone for
    // sprites with proper resolution in the first place 
    this.scale = 0.75f;
	
	initEnemy ();
    ListenForUpdate (HandleUpdate);
  }
	public Enemy( string sprite ) : base(sprite)
  {
	initEnemy ();
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
	

		abstract protected void initEnemy();
	/*{
		// default STUFFS
   		 _shotStrategy = new BasicShotStrategy();
		points = 1;
		health = 10.0f;
	}*/
	public int getPoints(){
		return points;
	} 

  public void setShotStrategy( ShotStrategy _shotStrategy )
  {
    this._shotStrategy = _shotStrategy;
  }
  public abstract void HandleUpdate();

}
