using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public const int MAX_PLAYERS = 4;

	public float turetInterval = 5.0f;
	public float trapdoorsInterval = 3.0f;

	private ArrayList players;
	private ArrayList bonuses;
	private ArrayList weapons;

	// Use this for initialization
	void Start () {
        Debug.Log("Level Start");
		// Turet timer
		InvokeRepeating ("EnableTurret", 0.0f, turetInterval);
		// Trapdoor timer
		InvokeRepeating ("EnableTrapdoors", 0.0f, trapdoorsInterval);
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

	/* ******************************
	 * Getters and setters
	 * ******************************/
	public ArrayList GetPlayers() {
		return players;
	}

	public ArrayList GetBonuses() {
		return bonuses;
	}

	public ArrayList GetWeapons() {
		return weapons;
	}
}
