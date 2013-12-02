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
		Enemy _myEnemy = new BasicEnemy();
		_myEnemy.x = x;
		_myEnemy.y = y;
      return _myEnemy;
    } else if( enemyName.Equals( "boss1" ) )
    {
      Enemy _myEnemy = new BossEnemy();
		_myEnemy.x = x;
		_myEnemy.y = y;
      return _myEnemy;
    } else
    {
      Debug.Log( "not a valid EnemyType!" );
      return null;
    }

  }
}
