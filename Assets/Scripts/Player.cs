using UnityEngine;
using System.Collections;

public class Player : FSprite {
	
    // last shot time
    private float last_shot_time;

	public Player() : base("Banana")
	{
	}
	
	public void playerDeath()
	{
		//return player to the middle of the screen
		this.x = 0;
		this.y = 0;
		
		//handle any death consequences
	}

    public void shoot()
    {
        if( Time.time-last_shot_time > 0.15 ){
            Shot _shot = new Shot(5.0f, 0.0f);
            _shot.x = x + 10;
            _shot.y = y;
		    ShotManager.addPlayerShot(_shot);

            last_shot_time = Time.time;
        }
    }
	
}
