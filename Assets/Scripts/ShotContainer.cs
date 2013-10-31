using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShotContainer :  FContainer
{
	private Shot _shot;
	private static List<Shot> _allShots = new List<Shot>();
	private static List<Shot> _enemyShots = new List<Shot>();
	private static List<Shot> _playerShots = new List<Shot>();
	public static ShotContainer theShots;
	
	public void Start()
	{	
		
	}
	
	
	public void Update()
	{
		
	}
	

    public static void addPlayerShot(Shot shot)
    {
        
        _playerShots.Add(shot);
        _allShots.Add(shot);
        Futile.stage.AddChild(shot);
        
    }

    public static void addEnemyShot(Shot shot)
    {
        
        _enemyShots.Add(shot);
        _allShots.Add(shot);
        Futile.stage.AddChild(shot);
    
    }
	
	public static void deletePlayerShot(Shot shot)
	{
		_playerShots.Remove (shot);
		_allShots.Remove(shot);
		shot.RemoveFromContainer();
	}
	
	public static void deleteEnemyShot(Shot shot)
	{
		_enemyShots.Remove(shot);
		_allShots.Remove(shot);
		shot.RemoveFromContainer();
	}
	
	public List<Shot> requestAllShots()
	{
		return _allShots;
	}
	
	public List<Shot> requestEnemyShots()
	{
		return _enemyShots;
	}
	
	public List<Shot> requestPlayerShots()
	{
		return _playerShots;
	}
	
}
