using UnityEngine;
using System.Collections;

public class TestLevel : Level {
  public TestLevel( GamePage _gamepage ) : base( _gamepage )
  {
    setBackground("background_1");
    this._eventQueue.Enqueue( new LevelEvent(0.0f, "enemy1", Futile.screen.halfWidth, -15.0f) );
    this._eventQueue.Enqueue( new LevelEvent(1.0f, "boss1", Futile.screen.halfWidth, 0.0f) );
    this._eventQueue.Enqueue( new LevelEvent(7.0f, "enemy1", Futile.screen.halfWidth, -30.0f) );
    this._eventQueue.Enqueue( new LevelEvent(9.0f, "enemy1", Futile.screen.halfWidth, 30.0f) );
    this._eventQueue.Enqueue( new LevelEvent(15.0f, "boss1", Futile.screen.halfWidth, 0.0f) );
	this._eventQueue.Enqueue( new LevelEvent(25.0f, "enemy1", Futile.screen.halfWidth, -15.0f) );
    this._eventQueue.Enqueue( new LevelEvent(35.0f, "enemy1", Futile.screen.halfWidth, 15.0f) );
	this._eventQueue.Enqueue( new LevelEvent(37.0f, "enemy1", Futile.screen.halfWidth, -90.0f) );
    this._eventQueue.Enqueue( new LevelEvent(37.0f, "enemy1", Futile.screen.halfWidth, 90.0f) );
	this._eventQueue.Enqueue( new LevelEvent(58.0f, "enemy1", Futile.screen.halfWidth, -15.0f) );
    this._eventQueue.Enqueue( new LevelEvent(58.0f, "enemy1", Futile.screen.halfWidth, 15.0f) );
	this._eventQueue.Enqueue( new LevelEvent(65.0f, "enemy1", Futile.screen.halfWidth, -15.0f) );
    this._eventQueue.Enqueue( new LevelEvent(65.0f, "enemy1", Futile.screen.halfWidth, 15.0f) );
	this._eventQueue.Enqueue( new LevelEvent(85.0f, "boss1", Futile.screen.halfWidth, 0.0f) );
	this._eventQueue.Enqueue( new LevelEvent(85.0f, "enemy1", Futile.screen.halfWidth, 15.0f) );
	this._eventQueue.Enqueue( new LevelEvent(110.0f, "enemy1", Futile.screen.halfWidth, 15.0f) );



  }
}
