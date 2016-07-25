using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[SerializeField] private float Angle;
	[SerializeField] private float Radius;
	[SerializeField] private float Gravity = -9.81f;
	[SerializeField] private float Mass = 10f;
	[SerializeField] private float Friction = 0.95f;
	[SerializeField] private float InputForce = 1;

	private Vector2 Speed = Vector2.zero;
	private Vector2 Acceleration;
	private Vector2 Position = Vector3.zero;

	void Update () {

		int inputDir = 0;
		if( Input.GetKey(KeyCode.LeftArrow)){
			inputDir = -1;
		}else if( Input.GetKey(KeyCode.RightArrow)){
			inputDir = 1;
		}

		// F = M * a
		// Fg = M * g

		Vector2 InputForceVector = transform.right * inputDir * InputForce;
		Vector2 GravityForceVector = Vector3.Project(Vector2.down * Gravity * Mass, transform.right);
		Vector2 SumForce = InputForceVector + GravityForceVector;

		Acceleration = SumForce / Mass;

		Speed += Acceleration;
		Speed *= Friction;
		Position += Speed;
		Position.y = 0;

		transform.position = (Vector3)Position;

//		transform.position = PutOnCircle(Angle, Radius);
//		transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle));
	}

	private Vector2 PutOnCircle(float angle, float radius){
		angle = angle - 90f;
		Vector2 pos = new Vector2( Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad) ) * radius;
		return pos;
	}
}
