using UnityEngine;
using System.Collections;
using System.Timers;

public class Level : MonoBehaviour {
	public const int MAX_PLAYERS = 4;

	public int enableTuretMaxTime = 5000;

	private ArrayList players;
	private ArrayList bonuses;
	private ArrayList weapons;
    private static System.Timers.Timer timerTurret;

	// Use this for initialization
	void Start () {
        Debug.Log("Level Start");
	    timerTurret = new System.Timers.Timer(10000);
        timerTurret.Elapsed += new ElapsedEventHandler(enableTuret);
        timerTurret.Interval = enableTuretMaxTime; // Turret 
        timerTurret.Enabled = true;
    }

    // Update is called once per frame
    void Update () {

    }
	
    void OnApplicationQuit () {
        timerTurret.Enabled = false;
    }

	/**
	 * Enable tourret randomly each  
	 */
    private void enableTuret (object source, ElapsedEventArgs e) {
        Debug.Log("Enable turret");
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
