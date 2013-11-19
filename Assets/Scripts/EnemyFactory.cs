using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class EnemyFactory
{
  public static Enemy generateEnemy( string enemyName, float x, float y )
  {
    // this should really be changed, so LevelEvents have some
    // sort of EnemyType built into them, so they can be type-
    // checked versus being a string.
    //
    
    if( enemyName.Equals( "enemy1" ) )
    {
      return new BasicEnemy(x, y);
    } else if( enemyName.Equals( "boss1" ) )
    {
      Enemy _myEnemy = new BossEnemy(x, y);
      _myEnemy.setShotStrategy(new FanShotStrategy());
      return _myEnemy;
    } else
    {
      Debug.Log( "not a valid EnemyType!" );
      return null;
    }

  }
}
