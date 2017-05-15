using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(MapGenerator))]
public class MapGeneratorEditor : Editor {

	public override void OnInspectorGUI () {
		MapGenerator mapGen = (MapGenerator)target;

		// If any value was changed in the Inspector, DrawDefaultInspector () is called.
		if (DrawDefaultInspector ()) {
			if (mapGen.autoUpdate) {
				mapGen.GenerateMap ();
			}
		}

		if (GUILayout.Button ("Generate")) {
			mapGen.GenerateMap ();
		}
	}

}
