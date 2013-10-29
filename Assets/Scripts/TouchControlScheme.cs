using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TouchControlScheme : ControlScheme
{
	
	public TouchControlScheme( Player target ) : base( target ){
		_target = target;
	}
	
	override public void MoveCharacter(FTouch touch)
	{
		_target.x = touch.position.x;
		_target.y = touch.position.y;
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
