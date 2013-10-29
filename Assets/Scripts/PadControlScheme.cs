using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PadControlScheme : ControlScheme {
	private GamePad pad;
	private int speedX = 0;
	private int speedY = 0;
	
	public PadControlScheme( Player target ) : base( target ){
		_target = target;
		pad = new GamePad( target );
		AddChild (pad);
		ListenForUpdate(HandleUpdate);
	}
	
	public void HandleUpdate()
	{
		_target.x += speedX;
		_target.y += speedY;
	}
	

	
	override public void MoveCharacter(FTouch touch)
	{
//		_target.x = position.x;
//		_target.y = position.y;
	}
	
	override public void acceptTouchOne(FTouch touch)
	{
		decodeTouch(touch);
	}
		
	override public void acceptTouchTwo(FTouch touch)
	{
		decodeTouch(touch);
	}
	
	
	private void decodeTouch(FTouch touch)
	{
		Rect _up = pad.upPress();
		Rect _down = pad.downPress();
		Rect _right = pad.rightPress();
		Rect _left = pad.leftPress();
		Rect _shoot = pad.shootPress();
		
		TouchPhase phase = touch.phase;
		Vector2 position = touch.position;
		
		if(phase == TouchPhase.Stationary || phase == TouchPhase.Moved)
		{
			if(_up.Contains(position))
				speedY = 3;
			else if(_down.Contains(position))
				speedY = -3;
			else if(_right.Contains(position))
				speedX = 3;
			else if(_left.Contains (position))
				speedX = -3;
			
		}
		
		if(phase == TouchPhase.Began)
		{
			if(_shoot.Contains (position))
				HandleShoot ();
		}
		
		if(phase == TouchPhase.Ended)
		{
			if(_up.Contains(position) || _down.Contains (position))
				speedY = 0;
			else if(_right.Contains(position) || _left.Contains(position))
				speedX = 0;
		}
		
	}
}
