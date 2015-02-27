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
		if (Level.paused)
			return;

		switch (robotParent.id) {
			case 0 :
				viewV = Input.GetAxis("VerticalView1");
				viewH = Input.GetAxis("HorizontalView1");
				break;

			case 1 :
				viewV = Input.GetAxis("VerticalView2");
				viewH = Input.GetAxis("HorizontalView2");
				break;
				
			case 2 :
				viewV = Input.GetAxis("VerticalView3");
				viewH = Input.GetAxis("HorizontalView3");
				break;

			case 3 :
				viewV = Input.GetAxis("VerticalView4");
				viewH = Input.GetAxis("HorizontalView4");
				break;

			default :

				break;
		}


		if (viewH == 0 && viewV == 0) {
			switch (robotParent.id) {
			case 0 :
				viewV = Input.GetAxis("Vertical1");
				viewH = Input.GetAxis("Horizontal1");
				break;
				
			case 1 :
				viewV = Input.GetAxis("Vertical2");
				viewH = Input.GetAxis("Horizontal2");
				break;
				
			case 2 :
				viewV = Input.GetAxis("Vertical3");
				viewH = Input.GetAxis("Horizontal3");
				break;
				
			case 3 :
				viewV = Input.GetAxis("Vertical4");
				viewH = Input.GetAxis("Horizontal4");
				break;
				
			default :
				
				break;
			}

			transform.rotation = Quaternion.Euler(0, -(Mathf.Atan2(viewH, viewV) * Mathf.Rad2Deg), 0);
		} else {
			transform.rotation = Quaternion.Euler(0, -(Mathf.Atan2(viewH, viewV) * Mathf.Rad2Deg), 0);
		}
	}
}
