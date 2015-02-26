using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public const int MAX_PLAYERS = 4;

	public float turetInterval = 5.0f;
	public float trapdoorsInterval = 3.0f;
	public float weaponsInterval = 10.0f;
	public float bonusInterval = 7.0f;

	private WeaponTrigger weaponTrigger;
	private BonusTrigger bonusTrigger;
	private static int playersAlive = 0;

	public static PlayerRobot[] players;
	public static Bonus bonusManager;

	// Use this for initialization
	void Start () {
        Debug.Log("Level Start");

		InvokeRepeating ("EnableTurret", 0.0f, turetInterval);
		InvokeRepeating ("EnableTrapdoors", 0.0f, trapdoorsInterval);
		InvokeRepeating ("SendWeapon", 5.0f, weaponsInterval);
		InvokeRepeating ("SendBonus", 3.0f, bonusInterval);

		players = gameObject.GetComponentsInChildren<PlayerRobot> ();
		playersAlive = players.Length;
		bonusManager = gameObject.GetComponentInChildren<Bonus> ();
		weaponTrigger = gameObject.GetComponentInChildren<WeaponTrigger> ();
		bonusTrigger = gameObject.GetComponentInChildren<BonusTrigger> ();
    }

    // Update is called once per frame
    void Update () {

    }

	// Called when user quit game
    void OnApplicationQuit () {
		CancelInvoke ("EnableTurret");
		CancelInvoke ("EnableTrapdoors");
		CancelInvoke ("SendWeapon");
		CancelInvoke ("SendBonus");
    }

	/**
	 * Enable tourret  
	 */
    private void EnableTurret () {
//        Debug.Log("Enable turret");
    }

	/**
	 * Enable trapdoors  
	 */
	private void EnableTrapdoors () {
//		Debug.Log("Enable trapdoors");
	}

	/**
	 * Enable weapon box  
	 */
	private void SendWeapon() {
		weaponTrigger.Activate ();
	}

	/**
	 * Enable bonus box  
	 */
	private void SendBonus() {
		bonusTrigger.Activate ();
	}

	/**
	 * Get player by its id
	 */
	public static PlayerRobot GetPlayerById(int id) {
		return (PlayerRobot)players.GetValue(id);
	}

	/**
	 * Remove player from game
	 */
	public static void OnPlayerDies () {
		playersAlive -= 1;
		if (playersAlive <= 1) {
			OnGameEnd();
		}
	}

	/**
	 * End of the game. Very sad moment ...
	 */
	private static void OnGameEnd() {
		Debug.Log ("Game ended");
	}
}
