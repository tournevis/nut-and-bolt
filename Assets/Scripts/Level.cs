using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level : MonoBehaviour {
	public Text anounce;
	public float turetInterval = 5.0f;
	public float trapdoorsInterval = 3.0f;
	public float weaponsInterval = 10.0f;
	public float bonusInterval = 7.0f;

	private static Text _announcer;
	private WeaponTrigger weaponTrigger;
	private BonusTrigger bonusTrigger;
	private static int playersAlive = 0;
	private static Level instance;

	public static PlayerRobot[] players;
	public static Bonus bonusManager;

	// Use this for initialization
	void Start () {
		instance = this;
		_announcer = anounce;
		DisplayAnnounce ("GO!");

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
		for (int i = 0; i < players.Length; i++) {
			if(players[i].isAlive) {
				string text = "PLAYER " + (players[i].id + 1).ToString () + " WINS!";
				DisplayAnnounce(text);
			}
		}
	}

	public static void DisplayAnnounce(string text) {
		_announcer.text = text;
		instance.Invoke ("ClearAnnouce", 1.5f);
	}

	private void ClearAnnouce() {
		_announcer.text = "";
	}
}
