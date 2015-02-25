using System;

public interface IBonus
{
	// Time during bonus is available
	float duration {
		get;
		set;
	}
	// Apply bonus to player
	void Apply (PlayerRobot p);
	// Remove bonus from player
	void Unapply (PlayerRobot p);
}