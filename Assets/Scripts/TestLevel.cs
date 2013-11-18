using UnityEngine;
using System.Collections;

public class TestLevel : Level {
    public TestLevel( GamePage _gamepage ) : base( _gamepage )
    {
  		setBackground("JungleClearBG");
      this._eventQueue.Enqueue( new LevelEvent(5.0f, "enemy1", 0.0f, Futile.screen.halfWidth) );
      this._eventQueue.Enqueue( new LevelEvent(15.0f, "enemy1", 0.0f, Futile.screen.halfWidth) );
    }
}
