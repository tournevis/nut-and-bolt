using UnityEngine;
using System.Collections;

public class BonusTrigger : MonoBehaviour {
	public bool isActive = false;
	private int bonusType;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		isActive = true;
		transform.position.Set (5.0f, 0.0f, 5.0f); // TODO: set random position
		bonusType = Random.Range (1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0.0f, 35.0f * Time.deltaTime, 0.0f);
	}

	void OnTriggerEnter (Collider col) {
		if(isActive == false) return;
		
		PlayerRobot p = col.GetComponent<PlayerRobot> ();
		if(p) {
			Level.bonusManager.Apply( Level.GetPlayerById(p.id), bonusType );
			renderer.enabled = false;
			isActive = false;
		}
	}
}
