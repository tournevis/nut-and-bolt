using UnityEngine;
using System.Collections;

public class directionShoot : MonoBehaviour {
	PlayerRobot robotParent;
	private float viewV;
	private float viewH;

	// Use this for initialization
	void Start () {
		robotParent = transform.parent.GetComponent<PlayerRobot> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (robotParent.id == 0) {
			viewV = Input.GetAxis("VerticalView1");
			viewH = Input.GetAxis("HorizontalView1");
		} else if (robotParent.id == 1) {

		} else {

		}
	
		Debug.Log (viewV);
		transform.rotation = Quaternion.Euler(0, -(Mathf.Atan2(viewH, viewV) * Mathf.Rad2Deg), 0);
	}
}
