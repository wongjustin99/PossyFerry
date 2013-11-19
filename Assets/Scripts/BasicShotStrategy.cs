using UnityEngine;
using System.Collections;

public class BasicShotStrategy : ShotStrategy {
    public void shoot( float x, float y, bool isEnemy ) 
    {
      Shot shotToCreate = new Shot(x, y, isEnemy);
      if (isEnemy)
        ShotManager.addEnemyShot(shotToCreate);
      else
        ShotManager.addPlayerShot(shotToCreate);
    }
}
