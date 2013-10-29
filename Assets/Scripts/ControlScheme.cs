using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class ControlScheme : FContainer {
	// target is what the ControlScheme will move
	protected Player _target;
	// list of shots
	private List<Shot> _shots = new List<Shot>();
	
	public ControlScheme( Player target ){
		this._target = target;
	}
	
	//default shooting behavior
	public void HandleShoot()
	{
		Shot _shot = new fanShot(false, _target.GetPosition());
		//_shot.x = _target.x + 10;
		//_shot.y = _target.y;
		//ShotContainer.addPlayerShotToContainer(_shot);
	}
	
	
	public abstract void MoveCharacter(FTouch touch);
	
	public abstract void acceptTouchOne(FTouch touch);
	public abstract void acceptTouchTwo(FTouch touch);
	
	
}
