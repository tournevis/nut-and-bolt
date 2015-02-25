using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public const int MAX_PLAYERS = 4;

	public float turetInterval = 5.0f;
	public float trapdoorsInterval = 3.0f;

	public static PlayerRobot[] players;
	public static Bonus bonusManager;
	public static Weapon[] weapons;

	// Use this for initialization
	void Start () {
        Debug.Log("Level Start");
		// Turet timer
		InvokeRepeating ("EnableTurret", 0.0f, turetInterval);
		// Trapdoor timer
		InvokeRepeating ("EnableTrapdoors", 0.0f, trapdoorsInterval);

		players = gameObject.GetComponentsInChildren<PlayerRobot> ();
		weapons = gameObject.GetComponentsInChildren<Weapon> ();
		bonusManager = gameObject.GetComponentInChildren<Bonus> ();
    }

    // Update is called once per frame
    void Update () {

    }

	// Called when user quit game
    void OnApplicationQuit () {
		CancelInvoke ("EnableTurret");
		CancelInvoke ("EnableTrapdoors");
    }

	/**
	 * Enable tourret  
	 */
    private void EnableTurret () {
        Debug.Log("Enable turret");
    }

	/**
	 * Enable trapdoors  
	 */
	private void EnableTrapdoors () {
		Debug.Log("Enable trapdoors");
	}

	/**
	 * Get random weapon from weapons array
	 */
	public static Weapon GetRandomWeapon() {
		long i = Random.Range (0, weapons.Length);

		return (Weapon)weapons.GetValue (i);
	}

	/**
	 * Get player by its id
	 */
	public static PlayerRobot GetPlayerById(int id) {
		return (PlayerRobot)players.GetValue(id);
	}
}
