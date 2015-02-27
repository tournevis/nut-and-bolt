using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRobot : MonoBehaviour {
	private float maxLife = 100.0f;
	private float minLife = 0.0f;
	private Weapon[] weapons;
	private ThirdPersonController controls;

	public int id = 0;
	public float currentLife;
	public Weapon weapon;
	public Slider sliderLife;
	public bool hasDot;
	public ArrayList dots;
	public float speedFactor = 1.0f;
	public float receivedDamageFactor = 1.0f;
	public bool isAlive = true;

	// Use this for initialization
	void Start () {
		controls = GetComponent<ThirdPersonController> ();
		weapons = GetComponentsInChildren<Weapon> ();
		currentLife = maxLife;
//		sliderLife.value = currentLife;
	}
	
	// Update is called once per frame
	void Update () {
		if (Level.paused) {
			controls.enabled = false;
		}
	}

	/**
	 * Apply damages when bullet hits player
	 */
	public void ReceiveDamages(float damages) {
		if (isAlive == false)
			return;

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
		Renderer[] renderers = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < renderers.Length; i++) {
			renderers[i].enabled = false;
		}
		isAlive = false;
		controls.enabled = false;
		Level.OnPlayerDies ();
	}
	
	/**
	 * Equip new weapon when player win weaopn box
	 */
	public void equipRandomWeapon() {
		if (isAlive == false)
			return;

		long i = Random.Range (0, weapons.Length);

		weapon.Disable ();
		weapon = (Weapon)weapons.GetValue (i);
		Level.DisplayAnnounce (weapon.name + "!");
		weapon.Enable ();
	}
}
