using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class XboxControlScheme : ControlScheme {
  private GamePad pad;
  private float speedX = 0;
  private float speedY = 0;

  public XboxControlScheme(){
    ListenForUpdate(HandleUpdate);
  }

  public void HandleUpdate()
  {
    if( _target != null ){
      _target.x += speedX;
      _target.y += speedY;
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
    speedX = 3 * (Input.GetAxis("Horizontal"));
    speedY = 3 * (Input.GetAxis("Vertical"));

  }
}
