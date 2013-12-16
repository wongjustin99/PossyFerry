using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TouchControlScheme : ControlScheme
{
  private float _speed = 550.0f;

  // `MoveCharacter()` variables
  private float _xDiff;
  private float _yDiff;
  private float _distance;
  private float xVelocity;
  private float yVelocity;
  private float _radius;
  private float _distancePercentage;
  private float _slowXVelocity;
  private float _slowYVelocity;
  public GameObject gameObject;

  public TouchControlScheme(){
    gameObject = new GameObject();
  }

  public void MoveCharacter(FTouch touch)
  {
    // movement algorithm from [http://www.somethinghitme.com/2013/11/13/snippets-i-always-forget-movement/](here)
    // Thank you!

    if( _target != null ) {
      // _target.x = touch.position.x;
      // _target.y = touch.position.y;

      _xDiff = touch.position.x - _target.x;
      _yDiff = touch.position.y - _target.y;
      _distance = (float) Math.Sqrt( _xDiff*_xDiff + _yDiff*_yDiff );

      xVelocity = (_xDiff / _distance) * _speed;
      yVelocity = (_yDiff / _distance) * _speed;

      if( float.IsNaN( xVelocity ) ) {
        xVelocity = 0;
      }

      if( float.IsNaN( yVelocity ) ) {
        yVelocity = 0;
      }

      _radius = (float) Math.Sqrt( _target.height*_target.height + _target.width*_target.width );

      float radiusRatio = 0.25f;

      if ( _distance > _radius*radiusRatio ) {
        // add our velocities
        _target.x += xVelocity * Time.deltaTime;
        _target.y += yVelocity * Time.deltaTime;
      } else {
        // interpolated velocities for inside the radius
        _distancePercentage = _distance/_radius/radiusRatio;

        // tweened velocities
        float _slowXVelocity = Mathf.Lerp( 0, xVelocity, _distancePercentage );
        float _slowYVelocity = Mathf.Lerp( 0, yVelocity, _distancePercentage );

        _target.x += _slowXVelocity * Time.deltaTime;
        _target.y += _slowYVelocity * Time.deltaTime;
      }
    }
  }

  override public void acceptTouchOne(FTouch touch)
  {
    MoveCharacter (touch);
  }

  override public void acceptTouchTwo(FTouch touch)
  {
    HandleShoot ();
  }
}
