using UnityEngine;
using System.Collections;

public class Player : FSprite {
	
	public Player() : base("Banana")
	{
	}
	
	public void playerDeath()
	{
		//return player to the middle of the screen
		this.x = Futile.screen.halfWidth;
		this.y = Futile.screen.halfHeight;
		
		Debug.Log (" you died");
		
		//handle any death consequences
	}
	
}
