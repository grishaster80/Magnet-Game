using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Color BlueColor;
	public Color RedColor;
	private GameController gameController;


	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((GetComponent<SpriteRenderer> ().color == BlueColor) && Input.GetKeyDown ("space")) {
			GetComponent<SpriteRenderer> ().color = RedColor;
		} else if ((GetComponent<SpriteRenderer> ().color == RedColor) && Input.GetKeyDown ("space")) {
			GetComponent<SpriteRenderer> ().color = BlueColor;
		}
		if ((GetComponent<SpriteRenderer> ().color == BlueColor)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);
		} else if ((GetComponent<SpriteRenderer> ().color == RedColor)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-10, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Coin")) {
			GetComponent<AudioSource>().Play();
			Destroy (col.gameObject);
			gameController.score += 1;
			Debug.Log ("TOUCHING");
		} else if (col.CompareTag ("Enemy")) {
			Debug.Log ("Platform");
			Destroy (this);
			SceneManager.LoadScene ("Game");

		}
			
	}
		
}