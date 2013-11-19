using UnityEngine;
using System.Collections;

public class FanShotStrategy : ShotStrategy {
   
    public void shoot( float x, float y, bool isEnemy )
  {
    float damage = 6.0f;
    Shot shotToCreate;
    int[] angles = { 45, 15, 0, 315, 345};

    for (int i = 0; i < angles.Length; ++i)
    {
      float angle = angles[i]*Mathf.Deg2Rad;
      shotToCreate = new Shot(x, y, isEnemy, damage, angle);
      if (isEnemy)
        ShotManager.addEnemyShot(shotToCreate);
      else
        ShotManager.addPlayerShot(shotToCreate);
    }
  }
}
