using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[SerializeField] private float Angle;
	[SerializeField] private float Radius;

	void Update () {
		transform.position = PutOnCircle(Angle, Radius);
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle));
	}

	private Vector2 PutOnCircle(float angle, float radius){
		angle = angle - 90f;
		Vector2 pos = new Vector2( Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad) ) * radius;
		return pos;
	}
}
