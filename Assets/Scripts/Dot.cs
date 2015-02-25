﻿using UnityEngine;
using System.Collections;

public class Dot : MonoBehaviour {
	public float rateDamage = 0.3f;
	public float minDamage = 0.0f;
	public float maxDamage = 2.0f;
	public float activityTime;
	public bool isActive = false;

	private float damage;

	// Use this for initialization
	void Start () {
		InvokeRepeating("OnDotTick", 0.1f, rateDamage);

		damage = Random.Range(minDamage, maxDamage);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Called when user quit game
	void OnApplicationQuit () {
		isActive = false;
		CancelInvoke("onDotTick");
	}

	void OnDotTick () {
		if (isActive) {
			Debug.Log("Apply dot damage");
//			Apply(player, damage); // TODO: Determine player affected by dot
		}
	}

	void Apply (PlayerRobot p, float damages) {
		p.ReceiveDamages (damages);
	}
}
