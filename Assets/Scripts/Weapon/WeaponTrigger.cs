using UnityEngine;
using System.Collections;

public class WeaponTrigger : MonoBehaviour {
	public bool isActive = false;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
		renderer.enabled = false;
	}

	void Awake () {
		// Randomly place box
		float x = Random.Range (-9.0f, 9.0f);
		float z = Random.Range (-24.0f, 24.0f);
		newPos = new Vector3(x, 0.7f, z);
		transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0.0f, 35.0f * Time.deltaTime, 0.0f);
		transform.position = newPos;
	}

	/**
	 * Called when player walk throught weapon box
	 */
	void OnTriggerEnter (Collider col) {
		if(isActive == false) return;

		PlayerRobot p = col.GetComponent<PlayerRobot> ();
		if(p) {
			Level.GetPlayerById(p.id).equipRandomWeapon();
			renderer.enabled = false;
			isActive = false;
		}
	}

	/**
	 * Randomly place weapon box and activate it
	 */
	public void Activate() {
		if (isActive)
			return;

		float x = Random.Range (-9.0f, 9.0f);
		float z = Random.Range (-24.0f, 24.0f);
		newPos = new Vector3(x, 0.7f, z);

		renderer.enabled = true;
		isActive = true;
	}
}
