using UnityEngine;
using System.Collections;

public class HandlesTest : MonoBehaviour {

	public Vector3 DistanceA;
	public Vector3 DistanceB;
	public float AngleA;
	public float AngleB;
	public int NumOfCoins;
	[Range(1,10)]
	public int NumOfLoops;

	private float RemapValue(float value, float a, float b, float min, float max){
		return min + (value - a) * ( (max - min) / (b - a) );
	}
}
