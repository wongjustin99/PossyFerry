using UnityEngine;
using System.Collections;

public enum ShotType
{
	Basic,
    Fan
}

public class Player : FSprite {
	
    // last shot time
    private float last_shot_time;

	private ShotType _currentShotType = ShotType.Fan;

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
            makeShot(_currentShotType, 5.0f, 0.0f);
            last_shot_time = Time.time;
        }
    }
    public void makeShot(ShotType shotType, float speedX, float speedY)
	{
        if(!System.Enum.IsDefined(typeof(ShotType), shotType))
        {
            return;
        }

        Shot shotToCreate = null;

		if( shotType == ShotType.Basic)
		{
            shotToCreate = ShotFactory.basicShot(this.x, this.y, speedX, speedY);
            ShotManager.addPlayerShot(shotToCreate);
		}
		else if(shotType == ShotType.Fan)
		{
            int[] angles = { 45, 15, 0, 315, 345};

            for (int i = 0; i < angles.Length; ++i)
            {
                float angle = angles[i]*Mathf.Deg2Rad;
                shotToCreate = ShotFactory.basicShot(this.x, this.y, speedX*Mathf.Cos(angle), speedX*Mathf.Sin(angle)) ;
                ShotManager.addPlayerShot(shotToCreate);
            }
		}
	}
	
}
