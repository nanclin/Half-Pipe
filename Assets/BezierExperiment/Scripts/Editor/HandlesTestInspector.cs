using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HandlesTest))]
public class HandlesTestInspector : Editor {

	void OnSceneGUI(){
		HandlesTest handlesTest = target as HandlesTest;

		Transform handleTransform = handlesTest.transform;

//		Vector3 p0 = handleTransform.TransformPoint( handlesTest.DistanceA );
//		Vector3 p1 = handleTransform.TransformPoint( handlesTest.DistanceB );
//
//		// Draw line
//		Handles.DrawLine( p0, p1 );
//
//		// Add handles
//		Handles.DoPositionHandle( p0, Quaternion.identity );
//		Handles.DoPositionHandle( p1, Quaternion.identity );
		
		Handles.color = Color.yellow;
		float snap = 0.5f;
		float radius = 2f;
		handlesTest.DistanceA = Handles.Slider(handlesTest.DistanceA, -Vector3.forward, HandleUtility.GetHandleSize(handlesTest.DistanceA), Handles.ArrowCap, snap);
		handlesTest.DistanceB = Handles.Slider(handlesTest.DistanceB, Vector3.forward, HandleUtility.GetHandleSize(handlesTest.DistanceB), Handles.ArrowCap, snap);

//		Quaternion rotA = Quaternion.Euler(new Vector3(0, 0, handlesTest.AngleA ));
//		rotA = Handles.Disc( rotA, handlesTest.DistanceA, Vector3.forward, radius, false, 30f);
//		handlesTest.AngleA = rotA.eulerAngles.z;
//
//		Quaternion rotB = Quaternion.Euler(new Vector3(0, 0, handlesTest.AngleB ));
//		rotB = Handles.Disc( rotB, handlesTest.DistanceB, Vector3.forward, radius, false, 30f);
//		handlesTest.AngleB = rotB.eulerAngles.z;

		Handles.Disc( Quaternion.identity, handlesTest.DistanceA, Vector3.forward, radius, false, 30f);
		Handles.Disc( Quaternion.identity, handlesTest.DistanceB, Vector3.forward, radius, false, 30f);

//		Handles.SphereCap(0, PointOnCircle(handlesTest.AngleA, radius) + handlesTest.DistanceA, rotA, HandleUtility.GetHandleSize(handlesTest.DistanceA) * 0.2f);
//		Handles.SphereCap(0, PointOnCircle(handlesTest.AngleB, radius) + handlesTest.DistanceB, rotA, HandleUtility.GetHandleSize(handlesTest.DistanceB) * 0.2f);

		int num = handlesTest.NumOfCoins;
		for( int i = 0; i < num; i++){
			float t = (float)i / (float)(num-1);
			float angle = Mathf.Lerp(handlesTest.AngleA, handlesTest.AngleB, t) * handlesTest.NumOfLoops;
			Vector3 posA = handlesTest.DistanceA;
			Vector3 posB = handlesTest.DistanceB;
			Vector3 pos = Vector3.Lerp(posA, posB, t) + PointOnCircle(angle, radius);;
			Handles.SphereCap(0, pos, Quaternion.identity, 0.2f);
		}
	}

	private float RemapValue(float value, float a, float b, float min, float max){
		return min + (value - a) * ( (max - min) / (b - a) );
	}

	private Vector3 PointOnCircle(float angle, float radius){
		return new Vector3( Mathf.Cos(angle * Mathf.Deg2Rad) * radius, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);
	}
}
