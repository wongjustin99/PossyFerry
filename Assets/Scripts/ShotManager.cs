using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class ShotManager
{
  private static FContainer _container;

  private static List<Shot> _allShots = new List<Shot>();
  private static List<Shot> _enemyShots = new List<Shot>();
  private static List<Shot> _playerShots = new List<Shot>();

  public static void checkBoundaries()
  {
    // delete out-of-boundary shots
    for(int i = _allShots.Count - 1; i>=0; --i)
    {
      Shot shot = _allShots[i];
      if ((shot.x < -Futile.screen.halfWidth) || (shot.x > Futile.screen.halfWidth))
      {
        ShotManager.removeShot(shot);
      }
    }
  }

  public static void setContainer(FContainer fc)
  {
    reset();
    _container = fc;
  }

  public static void addPlayerShot(Shot shot)
  {
    if( _container != null ) {
      _playerShots.Add(shot);
      _allShots.Add(shot);
      _container.AddChild(shot);
    }
  }

  public static void addEnemyShot(Shot shot)
  {
    if( _container != null ) {
      _enemyShots.Add(shot);
      _allShots.Add(shot);
      _container.AddChild(shot);
    }
  }

  public static void removePlayerShot(Shot shot)
  {
    if( _container != null ) {
      _playerShots.Remove(shot);
      _allShots.Remove(shot);
      _container.RemoveChild(shot);
    }
  }

  public static void removeEnemyShot(Shot shot)
  {
    if( _container != null ) {
      _enemyShots.Remove(shot);
      _allShots.Remove(shot);
      _container.RemoveChild(shot);
    }
  }

  public static void removeShot(Shot shot)
  {
    if( _container != null ) {
      _playerShots.Remove(shot);
      _enemyShots.Remove(shot);
      _allShots.Remove(shot);
      _container.RemoveChild(shot);
    }
  }

  public static void reset()
  {
    for(int i = _allShots.Count - 1; i>=0; --i)
    {
      ShotManager.removeShot( _allShots[i] );
    }
    _container = null;
  }

  public static List<Shot> allShots()
  {
    return _allShots;
  }

  public static List<Shot> enemyShots()
  {
    return _enemyShots;
  }

  public static List<Shot> playerShots()
  {
    return _playerShots;
  }

}
