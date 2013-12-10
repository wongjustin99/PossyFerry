using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TouchControlScheme : ControlScheme
{
  private float _speed = 500.0f;

  // moveCharacter variables

  public TouchControlScheme(){
  }

  public void MoveCharacter(FTouch touch)
  {
    // movement algorithm from [http://www.somethinghitme.com/2013/11/13/snippets-i-always-forget-movement/](here)
    // Thank you!

    if( _target != null ) {
      //_target.x = touch.position.x;
      //_target.y = touch.position.y;

      float _xDiff = touch.position.x - _target.x;
      float _yDiff = touch.position.y - _target.y;
      float _distance = (float) Math.Sqrt( _xDiff*_xDiff + _yDiff*_yDiff );

      float xVelocity = (_xDiff / _distance) * _speed;
      float yVelocity = (_yDiff / _distance) * _speed;
      Debug.Log( xVelocity );

      float _radius = (float) Math.Sqrt( _target.height*_target.height + _target.width*_target.width );
      if ( _distance > _radius ) {
        //add our velocities
        _target.x += xVelocity * Time.deltaTime;
        _target.y += yVelocity * Time.deltaTime;
      } else {
        float _distancePercentage = _distance/_radius;
        float _slowXVelocity = Mathf.Lerp( 0, xVelocity, _distancePercentage );
        float _slowYVelocity = Mathf.Lerp( 0, yVelocity, _distancePercentage );

        iTween.ValueTo( gameObject, iTween.Hash(
              "from", 0,
              "to", xVelocity,
              "time", _distancePercentage,
              "onupdatetarget", gameObject,
              "onupdate", "tweenOnUpdateCallBack",
              "easetype", iTween.EaseType.easeOutQuad
              )
            );

        _target.x += _slowXVelocity * Time.deltaTime;
        _target.y += _slowYVelocity * Time.deltaTime;
      }
    }
  }

  void tweenOnUpdateCallBack( int newValue )
  {
    exampleInt = newValue;
    Debug.Log( exampleInt );
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
