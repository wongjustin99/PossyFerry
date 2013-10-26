using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Gamepage : FContainer, FMultiTouchableInterface
{
	private FSprite _background;
	private Player	_player;
	private FContainer _holder;
	private FButton _shootbutton;
	private FSprite _monkey;
	
	private Enemy _enemy;
	private List<Enemy> _enemies = new List<Enemy>();
	
	private List<Shot> _shots;
	
	private FButton _upbutton;
	private FButton _downbutton;
	private FButton _rightbutton;
	private FButton _leftbutton;
	
	private float frameCount = 0;
	
	public Gamepage()
	{
		
		ListenForUpdate (HandleUpdate);
		
		_holder = new FContainer();
		_background = new FSprite("JungleClearBG");
		_player = new Player();
		_shots = new List<Shot>();
	
		// initialise BG
		AddChild(_background);
	
		// initialise player
		_player.x = 0.0f;
		_player.y = 0.0f;
		AddChild(_player);
		
		// enable MultiTouch
		EnableMultiTouch();
		
		Futile.stage.AddChild(_holder);

        // music loop
		FSoundManager.PlayMusic("loop1", 1.0f);

	}

	
	public void HandleUpdate()
	{
		// generate enemies
		frameCount += 1;
		if(frameCount%60 == 0)
		{
			_enemy = new Enemy();
			Futile.stage.AddChild(_enemy);
			_enemies.Add(_enemy);
		}
			
		// remove shots from edge of screen	
		for(int b = _shots.Count - 1; b>=0; b--)
		{
			Shot shotted = _shots[b];
			if(shotted.x > Futile.screen.halfWidth || shotted.x < -Futile.screen.halfWidth)
			{
				shotted.RemoveFromContainer();
				_shots.Remove(shotted);
			}
		}
		
		// Check if Enemies are out of screen boundaries
		for(int c = _enemies.Count - 1; c>=0; c--)
		{
			Enemy enemy = _enemies[c];
			if(enemy.x < -Futile.screen.halfWidth + 100.0f)
			{
				enemy.RemoveFromContainer();
				_enemies.Remove(enemy);
			}
		}
		
		
		// Kevin's hit detection code - player's bullets on enemies
		for(int b = _shots.Count - 1; b>=0; b--)
		{
			Shot shotted = _shots[b];
			// loop through each enemy
			for(int c = _enemies.Count - 1; c>=0; c--)
				{
					// get the current enemy
					Enemy enemy = _enemies[c];
				
					// get position of the current shot  
					Vector2 shotPos = shotted.GetPosition();
					// draw a box around the enemy not the Monkey....
					Rect enemyBounds = enemy.GetTextureRectRelativeToContainer();
					
					// check if the enemy contains the player shot's position	
					if(enemyBounds.Contains(shotPos))
					{
						List<Shot> deadShots = enemy.getShots();
						for(int j = deadShots.Count - 1; j>=0; j--)
						{
							_shots.Add(deadShots[j]);
						}
						
						enemy.RemoveFromContainer();
						_enemies.Remove(enemy);
						// remove bullet from the list
						shotted.RemoveFromContainer();
						_shots.Remove(shotted);
					}
				}
		}
		
		
		
	}
	// Player input 	
	public void HandleMultiTouch(FTouch[] touches)
	{
		if (touches.Length > 0){
			MoveCharacter(touches[0].position);
		}
		if (touches.Length > 1){
			HandleShoot();
		}
	}
	
	// Handle player shooting	
	public void HandleShoot()
	{
		Shot _shot = new Shot(-5.0f, 0.0f);
		_shot.x = _player.x + 10;
		_shot.y = _player.y;
		AddChild(_shot);
		_shots.Add(_shot);
	}
	
	private void MoveCharacter(Vector2 position)
	{
		_player.x = position.x;
		_player.y = position.y;
	}
	
	
	
	
	
}