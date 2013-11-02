using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Gamepage : PageContatiner, FMultiTouchableInterface
{
	private FSprite _background;
	private Player	_player;
	private FContainer _holder;
	private FButton _shootbutton;
	private FSprite _monkey;
	private FButton _backButton;
	
	private Enemy _enemy;
    private List<Enemy> _enemies;
	
	private List<Shot> _playerShots;
	private List<Shot> _enemyShots;
	
	private ControlScheme _control;
	private ControlScheme _debug_control;
	
	private FButton _upbutton;
	private FButton _downbutton;
	private FButton _rightbutton;
	private FButton _leftbutton;
	
	private float frameCount = 0;
	
	public Gamepage()
	{
		ListenForUpdate (HandleUpdate);
		
		_background = new FSprite("JungleClearBG");
		_player = new Player();
        _enemies = new List<Enemy>();
	
		_backButton = new FButton("CloseButton_normal", "CloseButton_down", "CloseButton_over", "ClickSound");
		_backButton.x = Futile.screen.halfWidth - 30.0f;
		_backButton.y = Futile.screen.halfHeight - 30.0f;

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

    override public void HandleRemovedFromStage()
    {
        base.HandleRemovedFromStage();
        ShotManager.reset();
    }

	private void HandleBackButtonRelease(FButton fbutton)
	{
		Main.instance.GoToPage(PageType.TitlePage);
	}
	
	public void HandleUpdate()
	{
		_playerShots = ShotManager.playerShots();
		_enemyShots = ShotManager.enemyShots();
		// generate enemies
		frameCount += 1;
		if(frameCount%60 == 0)
		{
			_enemy = new Enemy();
			AddChild(_enemy);
			_enemies.Add(_enemy);
		}
			
		// remove shots from edge of screen	
        ShotManager.checkBoundaries();
		
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
			Shot _shot = _playerShots[b];
			
			// get position of the current shot  
			Vector2 shotPos = _shot.GetPosition();
			
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
						ShotManager.deleteShot(_shot);
					}
				}
		}
		
		//loop through shots to check if player has been hit
		for( int b = _enemyShots.Count - 1; b>=0; b--)
		{
			Shot _shot = _enemyShots[b];
			
			// get position of the current shot  
			Vector2 shotPos = _shot.GetPosition();
			
			Rect playerBounds = _player.GetTextureRectRelativeToContainer();
			
			if(playerBounds.Contains(shotPos))
			{	
				_player.playerDeath ();
				ShotManager.deleteShot(_shot);
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