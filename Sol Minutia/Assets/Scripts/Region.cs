using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region {

	public string regionName;
	public int population;
	public float[,] territory;
	public float gdp;
	public float gdpPerCapita;
	public EconomicAxis economicAxis;
	public DiplomaticAxis diplomaticAxis;
	public CivilAxis civilAxis;
	public SocietalAxis societalAxis;


	public Region (int seed, string regionName, int population, int[] resources) {
		this.regionName = regionName;
		this.population = population;
		this.gdp = SetGDP (seed, resources);
		this.gdpPerCapita = gdp / (float)population;
		SetValueAxes (seed);
	}


	float SetGDP (int seed, int[] resources) {
		System.Random prng = new System.Random (seed);
		float regionGDP = 0;
		for (int person = 0; person < population; person++) {
			// Each person in the population contributes a random amount to the gdp.
			// Since economics is weird, make a small chance that one person's contribution is scaled by a factor of 100.
			int blackSwan = prng.Next (0, 100);
			if (blackSwan == 0) {
				regionGDP += (float)prng.Next (0, 10000) * 100f;
			} else {
				regionGDP += (float)prng.Next (0, 10000);
			}

		}

		float petroleumMultiplier = 2000f;
		float arableLandMultiplier = 500f;
		float oreMultiplier = 1000f;

		regionGDP += (float)resources [0] * petroleumMultiplier;
		regionGDP += (float)resources [1] * arableLandMultiplier;
		regionGDP += (float)resources [2] * oreMultiplier;

		return regionGDP;
	}

	void SetValueAxes (int seed) {

		System.Random prng = new System.Random (seed);
		economicAxis = new EconomicAxis (prng.Next (0, 101));
		diplomaticAxis = new DiplomaticAxis (prng.Next (0, 101));
		civilAxis = new CivilAxis (prng.Next (0, 101));
		societalAxis = new SocietalAxis (prng.Next (0, 101));

		// TODO
		// account for Agent values

	}


}


