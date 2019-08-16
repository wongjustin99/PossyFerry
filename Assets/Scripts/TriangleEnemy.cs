using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TriangleEnemy : Enemy
{
  private float _speedX = 170.0f;
  private float _speedY = 0.0f;
  private float _shotRate = RXRandom.Range (0.075f,0.09f);
  private float _last_shot_time;
  private int _burstRate = 2;
  private int _burstCount = 0;
  private bool _burstBool = true;

  public TriangleEnemy() : base("fish-triangle")
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
    this.x -= _speedX * Time.deltaTime;
    this.y += _speedY * Time.deltaTime;

    // shoot
    if( Time.time - _last_shot_time > _shotRate ){
      if( _burstBool)
        _shotStrategy.shoot(this.x, this.y, true);
      _last_shot_time = Time.time;
      ++_burstCount;
    }

    // burst groupings
    if( _burstCount % (_burstRate*2) == 0 ){
      _burstBool = true;
    } else if( (_burstCount % _burstRate) == 0 ) {
      _burstBool = false;
    }

  }
}
