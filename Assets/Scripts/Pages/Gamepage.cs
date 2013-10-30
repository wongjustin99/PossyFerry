using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Gamepage : PageContatiner, FMultiTouchableInterface
{
	private ShotContainer _allShots;
	private FSprite _background;
	private Player	_player;
	private FContainer _holder;
	private FButton _shootbutton;
	private FSprite _monkey;
	private FButton _backButton;
	
	private Enemy _enemy;
	private List<Enemy> _enemies = new List<Enemy>();
	
	private List<Shot> _playerShots;
	private List<Shot> _enemyShots;
	private List<Shot> _shots;
	
	private ControlScheme _control;
	private ControlScheme _debug_control;
	
	private FButton _upbutton;
	private FButton _downbutton;
	private FButton _rightbutton;
	private FButton _leftbutton;
	
	private float frameCount = 0;
	
	public Gamepage()
	{
		_allShots = new ShotContainer();
		ListenForUpdate (HandleUpdate);
		
		//_holder = new FContainer();
		_background = new FSprite("JungleClearBG");
		_player = new Player();
		_shots = new List<Shot>();
		_playerShots = new List<Shot>();
		_enemyShots = new List<Shot>();
	
		_backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
		_backButton.AddLabel("Franchise", "X", new Color(0.45f,0.25f,0.0f,1.0f));
		_backButton.x = -Futile.screen.halfWidth + 100.0f;
		_backButton.y = -Futile.screen.halfHeight + 30.0f;

		// initialise BG
		AddChild(_background);
	
		// initialise player
		_player.x = 0.0f;
		_player.y = 0.0f;
		AddChild(_player);
		
		// enable MultiTouch
		EnableMultiTouch();
		
        // add backbutton
		AddChild(_backButton);

		//_control = new TouchControlScheme(_player);
		_control = new PadControlScheme(_player);
		_debug_control = new XboxControlScheme(_player);
		
		AddChild (_control);
		AddChild (_debug_control);

        // music loop
		//FSoundManager.PlayMusic("loop1", 1.0f);

		_backButton.SignalRelease += HandleBackButtonRelease;
	}

	private void HandleBackButtonRelease(FButton fbutton)
	{
		Main.instance.GoToPage(PageType.TitlePage);
	}
	
	public void HandleUpdate()
	{
		_playerShots = _allShots.requestPlayerShots();
		_enemyShots = _allShots.requestEnemyShots();
		_shots = _allShots.requestAllShots();
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
		for(int b = _playerShots.Count - 1; b>=0; b--)
		{
			Shot shotted = _playerShots[b];
			
			// get position of the current shot  
			Vector2 shotPos = shotted.GetPosition();
			
			// loop through each enemy
			for(int c = _enemies.Count - 1; c>=0; c--)
				{
					// get the current enemy
					Enemy enemy = _enemies[c];
				
					
					// draw a box around the enemy not the Monkey....
					Rect enemyBounds = enemy.GetTextureRectRelativeToContainer();
					
					// check if the enemy contains the player shot's position	
					if(enemyBounds.Contains(shotPos))
					{
						enemy.RemoveFromContainer();
						_enemies.Remove(enemy);
						// remove bullet from the list
						ShotContainer.deletePlayerShotFromContainer(shotted);
					}
				}
		}
		
		//loop through shots to check if player has been hit
		for( int b = _enemyShots.Count - 1; b>=0; b--)
		{
			Shot shotted = _enemyShots[b];
			
			// get position of the current shot  
			Vector2 shotPos = shotted.GetPosition();
			
			Rect playerBounds = _player.GetTextureRectRelativeToContainer();
			
			if(playerBounds.Contains(shotPos))
			{	
				_player.playerDeath ();
				ShotContainer.deleteEnemyShotFromContainer(shotted);
			}
		}
		
		
		
	}
	
	// Player input 	
	public void HandleMultiTouch(FTouch[] touches)
	{
		if (touches.Length > 0){
			_control.acceptTouchOne(touches[0]);
		}
		if (touches.Length > 1){
			_control.acceptTouchTwo(touches[1]);
		}
	}
	
	
	
	
}