using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class ControlScheme : FContainer {
	// target is what the ControlScheme will move
	protected FSprite _target;
	// list of shots
	private List<Shot> _shots = new List<Shot>();
	
	public ControlScheme( FSprite target ){
		this._target = target;
	}
	
}
