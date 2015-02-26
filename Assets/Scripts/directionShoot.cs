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
			viewV = Input.GetAxisRaw("VerticalView1");
			viewH = Input.GetAxisRaw("HorizontalView1");
		} else if (robotParent.id == 1) {

		} else {

		}

		transform.Rotate (0, viewH, 0);
	}
}
