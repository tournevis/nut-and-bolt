using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Color color;
	private float maxLife = 100.0f;
	private float minLife = 0.0f;
	public float currentLife;
	public Weapon weapon;
	public bool hasDot;
	public ArrayList dots;
	public float speedFactor = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
