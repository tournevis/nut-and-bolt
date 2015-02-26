using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float rate = 1.0f;
	public float damage = 0.0f;
	public bool isRoulette = false;
	public bool isDefault = false;
//	public Dot dot;
	public Time usageTime;

	// Use this for initialization
	void Start () {
		if (isDefault == false) {
			renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
