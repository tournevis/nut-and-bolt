using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRobot : MonoBehaviour {
	public int id = 0;
	private float maxLife = 100.0f;
	private float minLife = 0.0f;
	public float currentLife;
	public Weapon weapon;
	public Slider sliderLife;
	public bool hasDot;
	public ArrayList dots;
	public float speedFactor = 1.0f;
	public float receivedDamageFactor = 1.0f;
	private bool isAlive = true;

	// Use this for initialization
	void Start () {
		currentLife = maxLife;
		sliderLife.value = currentLife;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Apply damages when bullet hits player
	 */
	public void ReceiveDamages(float damages) {
		if (isAlive == false)
			return;

		Debug.Log ("Player receives damages");
		currentLife -= (receivedDamageFactor * damages);
		sliderLife.value = currentLife;

		if (currentLife <= minLife) {
			currentLife = minLife;
			sliderLife.value = currentLife;
			Die();
		}
	}

	/**
	 * Add HP when player has life bonus
	 */
	public void AddLife(float value) {
		if (isAlive == false)
			return;

		currentLife += value;
		if (currentLife >= maxLife) {
			currentLife = maxLife;
		}
		sliderLife.value = currentLife;
	}

	/**
	 * Player loose
	 */
	void Die () {
		Debug.Log ("Player dies");
		renderer.enabled = false;
		isAlive = false;
		Level.OnPlayerDies ();
	}

	/**
	 * Equip new weapon when player win weaopn box
	 */
	public void equipWeapon(Weapon w) {
		if (isAlive == false)
			return;

		weapon = w;
	}
}
