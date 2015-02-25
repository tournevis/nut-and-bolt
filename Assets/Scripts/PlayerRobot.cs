using UnityEngine;
using System.Collections;

public class PlayerRobot : MonoBehaviour {
	public int id = 0;
	public Color color;
	private float maxLife = 100.0f;
	private float minLife = 0.0f;
	public float currentLife;
	public Weapon weapon;
	public bool hasDot;
	public ArrayList dots;
	public float speedFactor = 1.0f;
	public float receivedDamageFactor = 1.0f;

	// Use this for initialization
	void Start () {
		currentLife = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReceiveDamages(float damages) {
		Debug.Log ("Player receives damages");
		currentLife -= damages;
		if (currentLife <= minLife) {
			Die();
		}
	}

	public void AddLife(float value) {
		currentLife += value;
		if (currentLife >= maxLife) {
			currentLife = maxLife;
		}
	}

	void Die () {
		Debug.Log ("Player dies");
	}

	public void equipWeapon(Weapon w) {
		weapon = w;
	}
}
