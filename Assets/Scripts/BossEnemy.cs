using System.Collections.Generic;
using System;

public class BossEnemy : Enemy
{
  private float speedX = 0.5f;
  private float shotrate = 40.0f;
  private float frameCount = 0;
  private int direction = -1;

  public BossEnemy() : base("Monkey_0")
  {
      this.x = Futile.screen.halfWidth;
      this.y = 0f;
      this.scale = 0.5f;
      ListenForUpdate(HandleUpdate);
  }

  public BossEnemy( float x, float y) : base(x, y)
  {
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
          this._shotStrategy.shoot(this.x, this.y, true);
      }
      frameCount += 1;
  }
}
