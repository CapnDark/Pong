using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

	[SerializeField] private Transform leftPaddle;
	[SerializeField] private Transform rightPaddle;


	[SerializeField] private float speed = 5f;

	private float minimumYPosition;
	private float maximumYPosition;

	void Start() {
		minimumYPosition = -(Camera.main.orthographicSize - (leftPaddle.localScale.y/2));
		maximumYPosition = -minimumYPosition;
	}


	void Update () {
		Vector2 inputOne = new Vector2 (0, Input.GetAxisRaw ("Vertical"));
		Vector2 inputTwo = new Vector2 (0, Input.GetAxisRaw ("Vertical2"));

		leftPaddle.Translate (inputOne * speed * Time.deltaTime);
		rightPaddle.Translate (inputTwo * speed * Time.deltaTime);

		var leftPaddlePos = leftPaddle.position;
		var rightPaddlePos = rightPaddle.position;

		leftPaddlePos.y = Mathf.Clamp (leftPaddlePos.y, minimumYPosition, maximumYPosition);
		rightPaddlePos.y = Mathf.Clamp (rightPaddlePos.y, minimumYPosition, maximumYPosition);

		leftPaddle.position = leftPaddlePos;
		rightPaddle.position = rightPaddlePos;
	}
}
