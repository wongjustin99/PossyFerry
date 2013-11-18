using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class EnemyFactory
{
  public static Enemy generateEnemy( string enemyName )
  {
    // this should really be changed, so LevelEvents have some
    // sort of EnemyType built into them, so they can be type-
    // checked versus being a string.
    //
    
    if( enemyName.Equals( "enemy1" ) )
    {
      return new Enemy();
    } else if( enemyName.Equals( "boss1" ) )
    {
      Enemy _myEnemy = new BossEnemy();
      _myEnemy.setShotStrategy(new FanShotStrategy());
      return _myEnemy;
    } else
    {
      Debug.Log( "not a valid EnemyType!" );
      return null;
    }

  }
}
