using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour {

	[SerializeField] private float speed = 7f;

	[SerializeField] private Text leftPlayerText; 
	[SerializeField] private Text rightPlayerText;

	private Vector2 velocity;

	private Rigidbody rb;

	private int leftPlayerScoreCount;
	private int rightPlayerScoreCount;



	void Start () {

		leftPlayerScoreCount = 0;
		rightPlayerScoreCount = 0;

		rightPlayerText.text = rightPlayerScoreCount.ToString ();
		leftPlayerText.text = leftPlayerScoreCount.ToString ();

		velocity = GetBallDirection() * speed;

		rb = GetComponent<Rigidbody> ();

		rb.velocity = velocity;
	}
	

	void OnTriggerEnter(Collider col) {

		if (col.tag == "LeftWall") {
			rightPlayerScoreCount++;
			rightPlayerText.text = rightPlayerScoreCount.ToString ();
			Reset ();
		}

		if (col.tag == "RightWall") {
			leftPlayerScoreCount++;
			leftPlayerText.text = leftPlayerScoreCount.ToString ();
			Reset ();
		}
			
	}


	void Reset() {

		rb.velocity = Vector2.zero;
			
		transform.position = Vector2.zero;

		Invoke ("RestartBall", 1.5f);
	}

	void RestartBall() {

		velocity = GetBallDirection() * speed;

		rb.velocity = velocity;
	}

	Vector2 GetBallDirection() {
		float xValue = Random.Range (0, 1f) > 0.5f ? 1 : -1;
		float yValue = Random.Range (0, 1f) > 0.5f ? 1 : -1;


		return new Vector2 (xValue, yValue);
	}
}
