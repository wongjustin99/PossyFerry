using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TouchControlScheme : ControlScheme
{
	
	public TouchControlScheme( Player target ) : base( target ){
		_target = target;
	
	}
	
	
	// Handle player shooting	
	override public void HandleShoot()
	{
		Shot _shot = new Shot(-5.0f, 0.0f);
		_shot.x = _target.x + 10;
		_shot.y = _target.y;
		ShotContainer.addPlayerShotToContainer(_shot);
	}
	
	override public void MoveCharacter(Vector2 position)
	{
		_target.x = position.x;
		_target.y = position.y;
	}
}
