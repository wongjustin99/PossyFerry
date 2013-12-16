using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GamePage : PageContatiner, FMultiTouchableInterface
{
  private Level _level;
  private LevelEvent _myEvent;
  private float _startTime;

  private Player	_player;
  private int _playerLives;
  private float _invincibility_timer;
  private float _playerBlinkTimer;

  private FContainer _holder;
  private FButton _shootbutton;
  private FSprite _monkey;
  private FButton _backButton;

  // Labels
  private FLabel _scoreLabel;
  private FLabel _timeLabel;
  private FLabel _livesLabel;

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
    _backButton.scale = 0.8f;
    _backButton.x = Futile.screen.halfWidth - 30.0f;
    _backButton.y = Futile.screen.halfHeight - 30.0f;

    //initialize player's lives & invincibility timer
    _playerLives = 3;
    _invincibility_timer = 2.0f;
    _playerBlinkTimer = 0.0f;
    Main.instance.score = 0;

    // initialise level
    LevelInit();

    // lives
    _livesLabel = new FLabel("Franchise", "Player's lives: 3 ");
    _livesLabel.anchorX = 0.0f;
    _livesLabel.anchorY = 1.0f;
    _livesLabel.scale = 1.25f;
    _livesLabel.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    _livesLabel.x = -Futile.screen.halfWidth + 30.0f;
    _livesLabel.y = Futile.screen.halfHeight - 0.0f;

    //score
    _scoreLabel = new FLabel("Franchise", "Score: 0");
    _scoreLabel.anchorX = 0.0f;
    _scoreLabel.anchorY = 1.0f;
    _scoreLabel.scale = 1.25f;
    _scoreLabel.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    _scoreLabel.x = Futile.screen.halfWidth - 200.0f;
    _scoreLabel.y = Futile.screen.halfHeight - 0.0f;

    // initialise player
    _player.x = 0.0f;
    _player.y = 0.0f;
    _player.setShotStrategy(new FanShotStrategy());
    AddChild(_player);

    // enable MultiTouch
    EnableMultiTouch();

    // add backbutton
    AddChild(_backButton);

    // add live label
    AddChild(_livesLabel);

    // add score label
    AddChild(_scoreLabel);

    // add control from the main class
    _control = Main.instance.getControlScheme();
    _control.setTarget ( _player );
    AddChild (_control);

    // add xbox controls for debugging only
#if UNITY_EDITOR
    _debug_control = new XboxControlScheme();
    _debug_control.setTarget ( _player );
    AddChild (_debug_control);
#endif

    // music loop
    FSoundManager.PlayMusic("ingame_music", 1.0f);

    _backButton.SignalRelease += HandleBackButtonRelease;
  }

  // clean up references to other things before GamePage removed
  override public void HandleRemovedFromStage()
  {
    base.HandleRemovedFromStage();
    ShotManager.reset();
    //_control = null;
    //Main.instance.controlScheme = null;
    //_control.setTarget(null);
  }

  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.TitlePage);
  }

  public void HandleUpdate()
  {

    _playerShots = ShotManager.playerShots();
    _enemyShots = ShotManager.enemyShots();

    // level checking code
    // -- eventually this stuff could move to a dedicated level manager or something
    if( _level.eventCount() != 0 ) {
      if( (Time.time - _startTime) > ( _level.nextEventTime()) )
      {
        _myEvent = _level.popEvent();
        _enemy = EnemyFactory.generateEnemy( _myEvent.getEnemyName(), _myEvent.getXSpawn(), _myEvent.getYSpawn() );
        _enemy.x = _myEvent.getXSpawn();
        _enemy.y = _myEvent.getYSpawn();
        AddChild(_enemy);
        _enemies.Add(_enemy);
      }
    } else {
      // end of level
      //  -- either get a new one or end game, yo
      Main.instance.GoToPage(PageType.WinPage);
    }

    // remove shots from edge of screen	
    ShotManager.checkBoundaries();

    // Check if Enemies are out of screen boundaries
    for(int c = _enemies.Count - 1; c>=0; c--)
    {
      Enemy enemy = _enemies[c];
      if(enemy.x < -Futile.screen.halfWidth - 100.0f)
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
        if(enemyBounds.CheckIntersectComplex( new Rect(shotPos.x, shotPos.y, 1.0f, 1.0f) ) )
        {
          //bullet has hit so make enemy take damage
          //takeDamage(damage) returns true if unit has died
          if(enemy.takeDamage(_shot.getDamage()))
          {
            enemy.RemoveFromContainer();
            _enemies.Remove(enemy);
            Main.instance.score += enemy.getPoints();
            _scoreLabel.text = "Score: " + Main.instance.score;
          }
          //remove shot regardless of death or not
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

      if( playerBounds.CheckIntersectComplex( new Rect(shotPos.x, shotPos.y, 1.0f, 1.0f) )  && _invincibility_timer <= 0.0f )
      {	
        ShotManager.removeShot(_shot);
        _player.playerDeath();
        _playerLives--;
        _invincibility_timer = 3.0f;
      }
    }

    // decrease invincibility timer && blink
    if( _invincibility_timer > 0 )
    {
      _playerBlinkTimer = _playerBlinkTimer + Time.deltaTime;
      if( _playerBlinkTimer >= 0.2f )
      {
        _player.isVisible = false;
        _playerBlinkTimer = 0.0f;
      } else if( _playerBlinkTimer >= 0.10f ) {
        _player.isVisible = true;
      }

      _invincibility_timer -= Time.deltaTime;
    } else {
      _player.isVisible = true;
    }

    //decrease the number of player's lives
    if(_playerLives <= 0)
    {
      _livesLabel.text = "Player's Lives: " + _playerLives;
      Main.instance.GoToPage(PageType.GameOverPage);
    }
    else
    {
      _livesLabel.text = "Player's Lives: " + _playerLives;
    }

  } // END HANDLEUPDATE

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
  private void LevelInit()
  {
    _level = new TestLevel(this);
    _startTime = Time.time;
  }

}
