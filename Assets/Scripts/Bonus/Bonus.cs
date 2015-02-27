using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {
	private const int LIFE_BONUS = 1;
	private const int SHIELD_BONUS = 2;
	private const int INVINCIBILITY_BONUS = 3;

	public Time activityTime;
	public bool isActive;
	public LifeBonus lifeBonus;
	private IBonus applicator;
	private PlayerRobot _player;

	// Use this for initialization
	void Start () {

	}

	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Apply random bonus to player
	 */
	public void Apply (PlayerRobot p, int bonusType) {
		if (isActive)
			return;

		_player = p;
		this.EnableBonus ();
		switch (bonusType) {
			case LIFE_BONUS:
				applicator = new LifeBonus ();
				applicator.Apply (_player);
				Level.DisplayAnnounce("Life!");
				Invoke ("DisableBonus", applicator.duration);
				break;
			case SHIELD_BONUS:
				applicator = new ShieldBonus ();
				applicator.Apply (_player);
				Level.DisplayAnnounce("Shield!");
				Invoke ("DisableBonus", applicator.duration);
				break;
			case INVINCIBILITY_BONUS:
				applicator = new InvincibilityBonus ();
				applicator.Apply (_player);
				Level.DisplayAnnounce("Invincibility!");
				Invoke ("DisableBonus", applicator.duration);
				break;
		}

	}

	void EnableBonus() {
		isActive = true;
	}

	/**
	 * Remove bonus to player
	 */
	void DisableBonus() {
		isActive = false;
		applicator.Unapply (_player);
	}
}
