using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour {
	public float bonus = 4f;

	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll){
		Controls control = new Controls();
		if (coll.gameObject.tag == "Player") {
			control.gemBonus = bonus; 
		}

	}
	void Update () {
		
	}
}
