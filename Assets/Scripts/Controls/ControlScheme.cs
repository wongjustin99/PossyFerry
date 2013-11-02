using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class ControlScheme : FContainer {
	// target is what the ControlScheme will move
	protected Player _target;
	
	public ControlScheme( Player target ){
		this._target = target;
	}
	
	//default shooting behavior
	public void HandleShoot()
	{
        _target.shoot();
	}
	
	public abstract void acceptTouchOne(FTouch touch);
	public abstract void acceptTouchTwo(FTouch touch);
	
}
