using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	public float speed = 5f;
	private Rigidbody2D rb;
	//public Camera camera1;
	private BoxCollider2D  box;
	public float JumpPauseTime = 0f;
	float JumpPauseTimeLeft = 0f;
	public float gemBonus = 1f; 
	public GameObject gem; 
	int score = 0;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<BoxCollider2D> ();

	}
	

	void Update () {
		TextMesh textobject = GameObject.Find ("text").GetComponent<TextMesh> ();
		textobject.text = score.ToString(); 
		Vector2 origin = this.transform.position;
		origin.y = origin.y - this.transform.localScale.y / 2;
		RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down);

		Debug.Log (hit.distance);
		Vector2 f = new Vector2(0, 0);

		if(Input.GetKey(KeyCode.D)) {
			f.x = speed * Time.deltaTime/6;
		}
		if (Input.GetKeyDown (KeyCode.W) && hit.distance == 0 && JumpPauseTimeLeft == 0) {
			f.y = speed * Time.deltaTime*10*gemBonus;
			JumpPauseTimeLeft = JumpPauseTime*gemBonus; 
		}

		if (Input.GetKey (KeyCode.A)) {
			f.x = -speed * Time.deltaTime/6;

		}
		if (Input.GetKeyDown (KeyCode.S)) {
			f.y = -speed * Time.deltaTime*10;

		}
		rb.AddForce (f);

		JumpPauseTimeLeft -= Time.deltaTime;
		if (JumpPauseTimeLeft < 0) {
			JumpPauseTimeLeft = 0;
		}
	}


	void OnCollisionEnter2D(Collision2D coll){
		Controls control = new Controls();
		if (coll.gameObject.tag == "RedGem") {
			gemBonus = 2f; 
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.tag == "Finish") {
			gemBonus = 0.9f; 
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.tag == "Respawn") {
			gemBonus = 1f; 
			score++; 
			Destroy (coll.gameObject);
		}
	}

}
