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
    } else if( enemyName.Equals( "enemy2" ) )
    {
      // another kind of enemy
      return new Enemy();
    } else
    {
      Debug.Log( "not a valid EnemyType!" );
      return null;
    }

  }
}
