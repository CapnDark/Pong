using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	[SerializeField] private float ballSpeedX = 5f;
	[SerializeField] private float ballSpeedY = 6f;


	private float horizontalExtent;

	void Start () {
		horizontalExtent = Camera.main.orthographicSize * Screen.width / Screen.height;

		Debug.Log (horizontalExtent);
	}
	

	void Update () {
		Vector3 pos = transform.position; 	

		pos.x += ballSpeedX * Time.deltaTime;
		pos.y += ballSpeedY * Time.deltaTime;

		if (pos.y > Camera.main.orthographicSize) {
			ballSpeedY *= -1;
		}

		if (pos.x > horizontalExtent) {
			ballSpeedX *= -1;
		}

		transform.position = pos;
	}

	void CheckBallCollision() {
		if (transform.position.y > Camera.main.orthographicSize) {
			
			var pos = transform.position;
			pos.y = Camera.main.orthographicSize;
			transform.position = pos;
			ballSpeedY *= -1;
		}
	}
}
