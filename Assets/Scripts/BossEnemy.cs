using System.Collections.Generic;
using System;
using UnityEngine;

public class BossEnemy : Enemy
{
  private float speedX = 0.5f;
  private float shotrate = 40.0f;
  private float frameCount = 0;
  private int direction = -1;

  public BossEnemy() : base("fish-jam")
  {
    this.x = Futile.screen.halfWidth;
    this.y = 0f;
    this.scale = 0.5f;
  }

	override protected void initEnemy()
	{
		_shotStrategy = new FanShotStrategy();
		health = 50.0f;
		points = 5; // the other constructor isn't used, PLEASE FIX THIS LATER
	}
	
  override public void HandleUpdate()
  {
    //movement of boss, slowly moves across screen and up and down
    this.x -= speedX;
    this.y -= direction * 1.5f; 
    if (this.y >= Futile.screen.halfHeight - 10f || this.y <= -Futile.screen.halfHeight + 10f)
      direction = direction * -1;

    // enemy shoots
    if (frameCount % shotrate == 0)
    {
      _shotStrategy.shoot(this.x, this.y, true);
    }
    frameCount += 1;
  }

}
