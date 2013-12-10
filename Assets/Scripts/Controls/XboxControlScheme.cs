using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class XboxControlScheme : ControlScheme {
  private float speedX = 500.0f;
  private float _currentSpeedX = 0.0f;
  private float speedY = 500.0f;
  private float _currentSpeedY = 0.0f;

  public XboxControlScheme(){
    ListenForUpdate(HandleUpdate);
  }

  public void HandleUpdate()
  {
    if( _target != null ){
      _target.x += _currentSpeedX * Time.deltaTime;
      _target.y += _currentSpeedY * Time.deltaTime;
      decodeTouch();
    }
  }

  // these touch mehods aren't used
  override public void acceptTouchOne(FTouch touch)
  {
  }

  override public void acceptTouchTwo(FTouch touch)
  {
  }

  private void decodeTouch()
  {
    // shoot
    if (Input.GetButton( "Fire1" ))
      HandleShoot();

    // convert change axis to movement
    _currentSpeedX = speedX * (Input.GetAxis("Horizontal"));
    _currentSpeedY = speedY * (Input.GetAxis("Vertical"));

  }
}
