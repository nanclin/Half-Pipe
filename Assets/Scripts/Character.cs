using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[SerializeField] private float Angle;
	[SerializeField] private float Radius;
	[SerializeField] private float Gravity = -9.81f;
	[SerializeField] private float Mass = 10f;
	[SerializeField] private float Friction = 0.95f;
	[SerializeField] private float InputForce = 1;
	[SerializeField] private float InputAcceleration = 1;

	private float Speed = 0;
	private float Acceleration;
	private float Position;
	private int InputDir;

	void Update () {
		if( Input.GetKey(KeyCode.LeftArrow)){
			InputDir = -1;
		}else if( Input.GetKey(KeyCode.RightArrow)){
			InputDir = 1;
		}else{
			InputDir = 0;
		}

		if( Input.GetKey(KeyCode.Alpha1)){
			Time.timeScale = 1;
		}

		if( Input.GetKey(KeyCode.Alpha3)){
			Time.timeScale = 0.1f;
		}
	}

	void FixedUpdate(){

		// F = M * a
		// Fg = M * g

		Vector2 InputForceVector = transform.right * InputDir * InputForce;
//		Vector2 InputForceVector = transform.right * InputDir * InputAcceleration * Mass;
		Vector2 GravityForceVector = Vector2.down * Gravity * Mass;
		Vector2 ProjectedGravityForceVector = Vector3.Project(GravityForceVector, transform.right);
		Vector2 SumForce = InputForceVector + ProjectedGravityForceVector;

		float moveDir = Vector3.Dot(SumForce,transform.right) > 0 ? 1 : -1;

		Acceleration = SumForce.magnitude * moveDir / 22.92f / Mass;

		Speed += Acceleration;
		Speed *= Friction;
		Position += Speed;

//		transform.position = Vector3.right * Position;

		Angle = (Position * 180f) / (Mathf.PI * Radius);
//		Angle = Position;

		transform.position = PutOnCircle(Angle, Radius);
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle));
	
		Debug.DrawRay(transform.position, InputForceVector / Mass, Color.red);
		Debug.DrawRay(transform.position, GravityForceVector / Mass, Color.green/2);
		Debug.DrawRay(transform.position, ProjectedGravityForceVector / Mass, Color.green);
		Debug.DrawRay(transform.position + transform.up * 0.1f, SumForce / Mass, Color.white);
	}

	private Vector2 PutOnCircle(float angle, float radius){
		angle = angle - 90f;
		Vector2 pos = new Vector2( Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad) ) * radius;
		return pos;
	}
}
