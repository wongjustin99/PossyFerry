using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BasicEnemy : Enemy
{
  private float speedX = 3.0f;
  private float speedY = 0.0f;
  private float shotrate = RXRandom.Range (60.0f,80.0f);

  private float frameCount = 0;

  public BasicEnemy() : base("fish-fred")
  {
    this.x = Futile.screen.halfWidth;
    this.y = RXRandom.Range(-Futile.screen.halfHeight, Futile.screen.halfHeight);


    // once the sprites are swopped out, this needs to be forgone for
    // sprites with proper resolution in the first place 
  }

  override protected void initEnemy()
  {
    _shotStrategy = new BasicShotStrategy();
    points = 1;
    health = 10.0f;
    scale = 0.5f;
  }

  override public void HandleUpdate()
  {
    this.x -= speedX;
    this.y += speedY;

    // enemy shoots
    if(frameCount % shotrate == 0)
    {
      _shotStrategy.shoot(this.x, this.y, true);
    }
    frameCount += 1;
  }
}
