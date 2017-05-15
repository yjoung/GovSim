using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public enum DrawMode
	{
		NoiseMap,
		ColorMap,
		PoliticalMap
	};
	public DrawMode drawMode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	[Range (0, 1)]
	public float persistence;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public bool autoUpdate;

	public TerrainType[] terrains;

	// Custom

	public enum PlayMode
	{
		ActionINDEPflowing,
		ActionDEPdiscrete
	};


	public int numberOfRegions;
	public Region[] regions;

	// End custom

	public void GenerateMap () {
		float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistence, lacunarity, offset);

		Color[] colorMap = new Color[mapWidth * mapHeight];

		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				float currentHeight = noiseMap [x, y];
				for (int i = 0; i < terrains.Length; i++) {
					if (currentHeight <= terrains [i].height) {
						colorMap [y * mapWidth + x] = terrains [i].color;
						break;
					}
				}
			}
		}


		// CUSTOM SECTION

		// RESOURCES
		int[,] resourceMap = new int[mapWidth, mapHeight];
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				if (noiseMap [x, y] > 0.35f && noiseMap [x, y] < 0.4f) {
					resourceMap [x, y] = 1; //Petroleum
				} else if (noiseMap [x, y] > 0.4f && noiseMap [x, y] < 0.5f) {
					resourceMap [x, y] = 2; //ArableLand
				} else if (noiseMap [x, y] > 0.6f && noiseMap [x, y] < 0.7f) {
					resourceMap [x, y] = 3; //Ore
				}
			}
		}

		// POLITICAL
		float[,] politicalMap = new float[mapWidth, mapHeight];
		regions = new Region[numberOfRegions];
		System.Random prng = new System.Random (seed);
		for (int i = 0; i < numberOfRegions; i++) {
			int regionPopulation = prng.Next (10, 100);
			int territoryWidth = prng.Next (2, mapWidth / numberOfRegions);
			int territoryHeight = prng.Next (territoryWidth, mapHeight / numberOfRegions);
			int territoryTopLeftCornerX = prng.Next (1, mapWidth - territoryWidth);
			int territoryTopLeftCornerY = prng.Next (1, mapHeight - territoryHeight);

			int[] resources = new int[3];
			for (int y = 0; y < territoryHeight; y++) {
				for (int x = 0; x < territoryWidth; x++) {
					politicalMap [x + territoryTopLeftCornerX, y + territoryTopLeftCornerY] = (float)(i + 1);
					int resource = resourceMap [x + territoryTopLeftCornerX, y + territoryTopLeftCornerY];
					switch (resource) {
					case 1:
						resources [0]++;
						break;
					case 2:
						resources [1]++;
						break;
					case 3:
						resources [2]++;
						break;
					}
				}
			}

//			print (resources [0]);
//			print (resources [1]);
//			print (resources [2]);

			string regionName = prng.Next (1, 100).ToString ();
			regions [i] = new Region (seed * i, regionName, regionPopulation, resources);
//			print (regions [i].population);
//			print (regions [i].gdp);
//			print (regions [i].gdpPerCapita);

			print (regions [i].economicAxis.label);
			print (regions [i].diplomaticAxis.label);
			print (regions [i].civilAxis.label);
			print (regions [i].societalAxis.label);

		}



		// END CUSTOM SECTION


		MapDisplay display = FindObjectOfType<MapDisplay> ();
		if (drawMode == DrawMode.NoiseMap) {
			display.DrawTexture (TextureGenerator.TextureFromHeightMap (noiseMap));
		} else if (drawMode == DrawMode.ColorMap) {
			display.DrawTexture (TextureGenerator.TextureFromColorMap (colorMap, mapWidth, mapHeight));
		} else if (drawMode == DrawMode.PoliticalMap) {
			display.DrawTexture (TextureGenerator.TextureFromPoliticalMap (politicalMap, numberOfRegions));
		}


	}

	void OnValidate () {
		if (mapWidth < 1) {
			mapWidth = 1;
		}
		if (mapHeight < 1) {
			mapHeight = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}
		if (lacunarity < 1) {
			lacunarity = 1;
		}
	}

}

[System.Serializable]
public struct TerrainType {
	public string name;
	public float height;
	public Color color;
}