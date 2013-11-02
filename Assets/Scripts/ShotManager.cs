using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShotManager : FContainer
{
	private static List<Shot> _allShots = new List<Shot>();
	private static List<Shot> _enemyShots = new List<Shot>();
	private static List<Shot> _playerShots = new List<Shot>();

    public ShotManager(Gamepage gamepage)
    {
    }

    public static void checkBoundaries()
    {
        // delete out-of-boundary shots
		for(int i = _allShots.Count - 1; i>=0; --i)
		{
			Shot shot = _allShots[i];
            if ((shot.x < -Futile.screen.halfWidth) || (shot.x > Futile.screen.halfWidth))
            {
                ShotManager.deleteShot(shot);
            }
		}
    }
	
	public static void createPlayerShot(Shot shot)
	{
		_playerShots.Add(shot);
		_allShots.Add(shot);
		Futile.stage.AddChild(shot);
	}
	
	public static void createEnemyShot(Shot shot)
	{
		_enemyShots.Add(shot);
		_allShots.Add(shot);
		Futile.stage.AddChild(shot);
	}
	
	public static void deletePlayerShot(Shot shot)
	{
		_playerShots.Remove(shot);
		_allShots.Remove(shot);
        Futile.stage.RemoveChild(shot);
	}
	
	public static void deleteEnemyShot(Shot shot)
	{
		_enemyShots.Remove(shot);
		_allShots.Remove(shot);
        Futile.stage.RemoveChild(shot);
	}

    public static void deleteShot(Shot shot)
    {
		_playerShots.Remove(shot);
        _enemyShots.Remove(shot);
		_allShots.Remove(shot);
        Futile.stage.RemoveChild(shot);
    }

    public static void reset()
    {
		for(int i = _allShots.Count - 1; i>=0; --i)
		{
            ShotManager.deleteShot( _allShots[i] );
		}
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
