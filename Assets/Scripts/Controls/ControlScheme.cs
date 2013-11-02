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
		Shot _shot = new Shot(5.0f, 0.0f);
		_shot.x = _target.x + 10;
		_shot.y = _target.y;
		ShotManager.createPlayerShot(_shot);
	}
	
	public abstract void acceptTouchOne(FTouch touch);
	public abstract void acceptTouchTwo(FTouch touch);
	
}
