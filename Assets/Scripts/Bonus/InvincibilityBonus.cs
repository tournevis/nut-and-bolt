using UnityEngine;
using System.Collections;

/**
 * Make player invincible during 3.5s
 */
public class InvincibilityBonus : IBonus {
	private float _duration;

	public InvincibilityBonus () {
		duration = 3.5f;
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

	public void Apply(PlayerRobot p) {
		p.receivedDamageFactor = 0.0f;
	}

	public void Unapply (PlayerRobot p) {
		p.receivedDamageFactor = 1.0f;
	}
}
