using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Takes a noiseMap, turns it into a texture, & applies the texture to a plane in the scene.
public class MapDisplay : MonoBehaviour {

	public Renderer textureRenderer;

	public void DrawTexture (Texture2D texture) {

		textureRenderer.sharedMaterial.mainTexture = texture;
		textureRenderer.transform.localScale = new Vector3 (texture.width, 1, texture.height);
	}

}
