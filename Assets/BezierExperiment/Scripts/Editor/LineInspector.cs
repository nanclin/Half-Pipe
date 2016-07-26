using UnityEngine;
using UnityEditor;

/**
 * Source: http://catlikecoding.com/unity/tutorials/curves-and-splines/
 */

[CustomEditor(typeof(Line))]
public class LineInspector : Editor
{

	// Executes when mouse moves on editor window
	private void OnSceneGUI()
	{
		Line line = target as Line;

		// Take targets transform into account
		Transform handleTransform = line.transform;
		// Rotate handles relative to world or transform
		Quaternion handleRotation = ( Tools.pivotRotation == PivotRotation.Local ) ? handleTransform.rotation : Quaternion.identity;
		Vector3 p0 = handleTransform.TransformPoint( line.p0 );
		Vector3 p1 = handleTransform.TransformPoint( line.p1 );

		// Draw line
		Handles.color = Color.white;
		Handles.DrawLine( p0, p1 );

		// Add handles
		Handles.DoPositionHandle( p0, handleRotation );
		Handles.DoPositionHandle( p1, handleRotation );

		// Assing handle position back to line points.
		EditorGUI.BeginChangeCheck();
		p0 = Handles.DoPositionHandle( p0, handleRotation );
		if( EditorGUI.EndChangeCheck() )
		{
			// Before making change, record state
			// and set state to changed/dirty
			Undo.RecordObject( line, "Move Point" );
			EditorUtility.SetDirty( line );
			// Transform from world space back to lines' local space
			line.p0 = handleTransform.InverseTransformPoint( p0 );
		}
		EditorGUI.BeginChangeCheck();
		p1 = Handles.DoPositionHandle( p1, handleRotation );
		if( EditorGUI.EndChangeCheck() ) {
			// Before making change, record state
			// and set state to changed/dirty
			Undo.RecordObject( line, "Move Point" );
			EditorUtility.SetDirty( line );
			// Transform from world space back to lines' local space
			line.p1 = handleTransform.InverseTransformPoint( p1 );
		}
	}
}
