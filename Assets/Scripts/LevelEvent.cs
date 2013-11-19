using UnityEngine;
using System.Collections;

public class LevelEvent {
    private float _triggerTime;
    private string _enemyName;
    private float _xSpawn;
    private float _ySpawn;

    public LevelEvent ()
    {
    }

    public LevelEvent( float time, string enemyName, float x, float y )
    {
      this._triggerTime = time;
      this._enemyName = enemyName;
      this._xSpawn = x;
      this._ySpawn = y;
    }

    public float getTime()
    {
        return _triggerTime;
    }

    public string getEnemyName()
    {
        return _enemyName;
    }

    public float getXSpawn()
    {
      return _xSpawn;
    }

    public float getYSpawn()
    {
      return _ySpawn;
    }
}
