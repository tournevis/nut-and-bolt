using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public const int MAX_PLAYERS = 4;

	private ArrayList players;
	private ArrayList bonuses;
	private ArrayList weapons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
