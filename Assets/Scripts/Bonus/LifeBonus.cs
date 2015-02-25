using UnityEngine;
using System.Collections;

/**
 * Give 20PV to player
 */
public class LifeBonus : IBonus {
	private float _duration;

	public LifeBonus () {
		duration = 0.0f;
	}

	public float duration
	{
		get
		{
			return _duration;
		}
		
		set
		{
			_duration = value;
		}
	}

	public void Apply (PlayerRobot p) {
		p.AddLife (20.0f);
	}

	public void Unapply (PlayerRobot p) {
	
	}
}
