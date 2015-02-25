﻿using UnityEngine;
using System.Collections;

public class BonusTrigger : MonoBehaviour {
	public bool isActive = false;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		isActive = true;
		transform.position.Set (5.0f, 0.0f, 5.0f); // TODO: set random position
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col) {
		if(isActive == false) return;
		
		PlayerRobot p = col.GetComponent<PlayerRobot> ();
		if(p) {
			Level.GetRandomBonus().Apply( Level.GetPlayerById(p.id) );
			renderer.enabled = false;
			isActive = false;
		}
	}
}