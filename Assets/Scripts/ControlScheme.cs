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
	
	public abstract void HandleShoot();
	
	public abstract void MoveCharacter(Vector2 position);
	
	
}
