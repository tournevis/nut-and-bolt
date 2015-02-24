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
		InvokeRepeating ("enableTurret", 0.0f, turetInterval);
		// Trapdoor timer
		InvokeRepeating ("enableTrapdoors", 0.0f, trapdoorsInterval);
    }

    // Update is called once per frame
    void Update () {

    }

	// Called when user quit game
    void OnApplicationQuit () {
		CancelInvoke ("enableTurret");
		CancelInvoke ("enableTrapdoors");
    }

	/**
	 * Enable tourret  
	 */
    private void enableTurret () {
        Debug.Log("Enable turret");
    }

	/**
	 * Enable trapdoors  
	 */
	private void enableTrapdoors () {
		Debug.Log("Enable trapdoors");
	}

	/* ******************************
	 * Getters and setters
	 * ******************************/
	public ArrayList getPlayers() {
		return players;
	}

	public ArrayList getBonuses() {
		return bonuses;
	}

	public ArrayList getWeapons() {
		return weapons;
	}
}
