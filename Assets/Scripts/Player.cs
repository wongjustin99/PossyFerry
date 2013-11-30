using UnityEngine;
using System.Collections;

public class Player : FSprite {

  // last shot time
  private float last_shot_time;
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
    if( Time.time-last_shot_time > 0.15 ){
      _shotStrategy.shoot(this.x, this.y, false);
      last_shot_time = Time.time;
    }
  }
}
