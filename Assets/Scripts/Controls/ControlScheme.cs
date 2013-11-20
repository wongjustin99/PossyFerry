using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class ControlScheme : FContainer {
  // target is what the ControlScheme will move
  protected Player _target;

  public ControlScheme(){
  }

  public ControlScheme( Player target ){
    setTarget(target);
  }

  public void setTarget( Player target ){
    this._target = target;
  }

  //default shooting behavior
  public void HandleShoot()
  {
    if( _target != null )
      _target.shoot();
  }

  public abstract void acceptTouchOne(FTouch touch);
  public abstract void acceptTouchTwo(FTouch touch);

}
