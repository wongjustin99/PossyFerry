using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GamePage : PageContatiner, FMultiTouchableInterface
{
  private Level _level;
  private float _startTime;

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
	
	public GamePage()
	{
    // initialise ShotManager
    ShotManager.setContainer(this);

		ListenForUpdate (HandleUpdate);
		
		_player = new Player();
      _enemies = new List<Enemy>();
	
		_backButton = new FButton("CloseButton_normal", "CloseButton_down", "CloseButton_over", "ClickSound");
		_backButton.x = Futile.screen.halfWidth - 30.0f;
		_backButton.y = Futile.screen.halfHeight - 30.0f;

    // initialise level
    _level = new TestLevel(this);
    _startTime = Time.time;

		// initialise player
		_player.x = 0.0f;
		_player.y = 0.0f;
        _player.setShotStrategy(new FanShotStrategy());
		AddChild(_player);
		
		// enable MultiTouch
		EnableMultiTouch();
		
    // add backbutton
		AddChild(_backButton);

		//_control = new TouchControlScheme(_player);
		_control = new PadControlScheme(_player);
		
		AddChild (_control);
        // add xbox controls for debugging only
        #if UNITY_EDITOR
		    _debug_control = new XboxControlScheme(_player);
		    AddChild (_debug_control);
        #endif

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
    // level checking code
    // check for level and pop off stack if [time-_startTime > getNextEventTime()]
    // if so, create an Enemy matching that string, or use a PFM to do it, yo
    LevelEvent _myEvent;

    // eventually this stuff could move to a dedicated level manager or something
    if( _level.eventCount() != 0 ) {
      if( (Time.time - _startTime) > _level.nextEventTime() )
      {
        _myEvent = _level.popEvent();
        _enemy = EnemyFactory.generateEnemy( _myEvent.getEnemyName(), _myEvent.getXSpawn(), _myEvent.getYSpawn() );
        _enemy.x = _myEvent.getXSpawn();
        _enemy.y = _myEvent.getYSpawn();
        AddChild(_enemy);
        _enemies.Add(_enemy);
      }
    }
    
    _playerShots = ShotManager.playerShots();
		_enemyShots = ShotManager.enemyShots();
			
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
						ShotManager.removeShot(_shot);
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
				ShotManager.removeShot(_shot);
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
