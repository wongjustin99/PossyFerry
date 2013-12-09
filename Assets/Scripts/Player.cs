using UnityEngine;
using System.Collections;

public class Player : FSprite {

  // last shot time
  private float _last_shot_time;
  private float _shotRate = 0.15f;
  private ShotStrategy _shotStrategy;

  public Player() : base("fish-frond")
  {
    this.scale = 1.0f;
    this.scaleX = -1.0f;
  }

  public void setShotStrategy( ShotStrategy _shotStrategy )
  {
    this._shotStrategy = _shotStrategy;
  }

  public void playerDeath()
  {
  }

  public void shoot()
  {
    // shotrate limiting based on time
    if( Time.time - _last_shot_time > _shotRate ){
      _shotStrategy.shoot(this.x, this.y, false);
      _last_shot_time = Time.time;
    }
  }
}
