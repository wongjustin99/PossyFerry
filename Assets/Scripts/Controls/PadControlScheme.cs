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
		pad = new GamePad();
		AddChild (pad);
		ListenForUpdate(HandleUpdate);
	}
	
	public void HandleUpdate()
	{
		_target.x += speedX;
		_target.y += speedY;
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
        // creates rectnagles to later compare touch collisions
		Rect _up_rect = pad.up_rect();
		Rect _down_rect = pad.down_rect();
		Rect _right_rect = pad.right_rect();
		Rect _left_rect = pad.left_rect();
		Rect _shoot_rect = pad.shootPress();
		
		TouchPhase phase = touch.phase;
		Vector2 position = touch.position;
		
        // Check d-pad for touches inside
		if(phase == TouchPhase.Stationary || phase == TouchPhase.Moved)
		{
			if(_up_rect.Contains(position))
				speedY = 3;
			else if(_down_rect.Contains(position))
				speedY = -3;
			else if(_right_rect.Contains(position))
				speedX = 3;
            else if (_left_rect.Contains(position))
                speedX = -3;
            else
            {
                speedX = 0;
                speedY = 0;
            }
		}

		// check for touch inside shoot_rect
		if(phase == TouchPhase.Began)
		{
			if(_shoot_rect.Contains (position))
				HandleShoot ();
		}
		
        // stop movement after touches are gone
		if(phase == TouchPhase.Ended)
		{
            speedY = 0;
            speedX = 0;
		}
		
	}
}
