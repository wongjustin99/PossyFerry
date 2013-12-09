using System.Collections.Generic;
using System;
using UnityEngine;

public class BossEnemy : Enemy
{
  private float _speedX = 45.0f;
  private float _speedY = 80.0f;
  private float _shotRate = 0.8f;
  // vertical direction, not horisontal ... 
  private int direction = -1;
  private float _last_shot_time;

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
    this.x -= _speedX * Time.deltaTime;
    this.y -= direction * _speedY * Time.deltaTime;
    if (this.y >= Futile.screen.halfHeight - 10f || this.y <= -Futile.screen.halfHeight + 10.0f)
      direction = direction * -1;

    // shoot
    if( Time.time - _last_shot_time > _shotRate ){
      _shotStrategy.shoot(this.x, this.y, true);
      _last_shot_time = Time.time;
    }
  }

}
