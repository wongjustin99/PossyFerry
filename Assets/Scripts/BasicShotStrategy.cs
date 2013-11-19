using UnityEngine;
using System.Collections;

public class BasicShotStrategy : ShotStrategy{
    
    public void shoot( float x, float y, bool isEnemy ) 
    {
      float damage = 10.0f;
      Shot shotToCreate = new Shot(x, y, isEnemy, damage);
      if (isEnemy)
        ShotManager.addEnemyShot(shotToCreate);
      else
        ShotManager.addPlayerShot(shotToCreate);
    }
}
