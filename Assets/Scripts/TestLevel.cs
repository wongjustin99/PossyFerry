using UnityEngine;
using System.Collections;

public class TestLevel : Level {
  public TestLevel( GamePage _gamepage ) : base( _gamepage )
  {
    setBackground("background_1");
    this._eventQueue.Enqueue( new LevelEvent(5.0f, "enemy1", Futile.screen.halfWidth, -15.0f) );
    this._eventQueue.Enqueue( new LevelEvent(5.0f, "enemy1", Futile.screen.halfWidth, 15.0f) );
    this._eventQueue.Enqueue( new LevelEvent(1.0f, "boss1", Futile.screen.halfWidth, 0.0f) );
    this._eventQueue.Enqueue( new LevelEvent(10.0f, "enemy1", Futile.screen.halfWidth, 0.0f) );
    this._eventQueue.Enqueue( new LevelEvent(10.0f, "enemy1", Futile.screen.halfWidth, 0.0f) );
    this._eventQueue.Enqueue( new LevelEvent(15.0f, "boss1", Futile.screen.halfWidth, 0.0f) );
  }
}
