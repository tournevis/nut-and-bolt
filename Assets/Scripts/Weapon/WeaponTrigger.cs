using UnityEngine;
using System.Collections;

public class WeaponTrigger : MonoBehaviour {
	public bool isActive = false;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		isActive = true;
		transform.position.Set (0.0f, 0.0f, 0.0f); // TODO: set random position
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0.0f, 35.0f * Time.deltaTime, 0.0f);
	}

	void OnTriggerEnter (Collider col) {
		if(isActive == false) return;

		PlayerRobot p = col.GetComponent<PlayerRobot> ();
		if(p) {
			Level.GetPlayerById(p.id).equipWeapon(Level.GetRandomWeapon());
			renderer.enabled = false;
			isActive = false;
		}
	}
}
