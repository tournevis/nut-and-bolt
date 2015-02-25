using UnityEngine;
using System.Collections;

/**
 * Divide player damage received per two
 */
public class ShieldBonus : IBonus {
	private float _duration;

	public ShieldBonus () {
		duration = 5.0f;
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
		p.receivedDamageFactor = 0.5f;
	}

	public void Unapply (PlayerRobot p) {
		p.receivedDamageFactor = 1.0f;
	}
}
