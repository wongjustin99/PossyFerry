using UnityEngine;
using System.Collections;

public class Player : FSprite {
	
	public Player() : base("Banana")
	{
	}
	
	public void playerDeath()
	{
		//return player to the middle of the screen
		this.x = 0;
		this.y = 0;
		
		Debug.Log (" you died");
		
		//handle any death consequences
	}
	
}
