using UnityEngine;
using System.Collections;

public class BonusTrigger : MonoBehaviour {
	public bool isActive = false;
	private int bonusType;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
		renderer.enabled = false;
	}

	void Awake () {
		bonusType = Random.Range (1, 3);
		float x = Random.Range (-20.0f, 20.0f);
		float z = Random.Range (-30.0f, 30.0f);
		newPos = new Vector3(x, 5.0f, z);
		transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0.0f, 35.0f * Time.deltaTime, 0.0f);
		transform.position = newPos;
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

	public void Activate() {
		if (isActive)
			return;

		float x = Random.Range (-20.0f, 20.0f);
		float z = Random.Range (-30.0f, 30.0f);
		newPos = new Vector3(x, 0.7f, z);

		renderer.enabled = true;
		isActive = true;

		 // TODO: set random position
	}
}
