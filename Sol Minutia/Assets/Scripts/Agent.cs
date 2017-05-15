using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
	/*
	 * Each Agent has an area of influence ("creep")
	 * Agent density determines "strength" of creep
	 * Creep forms a shape with a certain defined boundary which will in turn
	 * shape institution boundaries, and then society boundaries.
	 * Creep will also determine resource ownership
	 * Resource ownership and proximal active developments determine available currency*
	 * 	*currency (market) value of that resource	
	 * Agent[] is an "institution"
	 * Agent[][] is a "society"
	 */

	// min and max values can be determined by other functions later on
	[Range (0, 100)]
	public int age;
	[Range (0, 100)]
	public int health;

	// Agent to Agent interactions & Agent to Environment interactions
	public enum AgentRole
	{
		Worker,		// Gathers resources & builds
		Soldier,	// Offense & defense
		Statesman	// Allocates resources & manages other Agents
	};

	// Behavioral parameters
	public int valueInfluence;
	public EconomicAxis economicAxis;
	public DiplomaticAxis diplomaticAxis;
	public CivilAxis civilAxis;
	public SocietalAxis societalAxis;
	// Insert personality model (e.g. big five factor, dark triad, 16personalities)
	// Insert mood model


	/*
	 * Agent:Agent interaction functions
	 * 
	 * Transact
	 * Communicate
	 * Heal
	 * Attack
	 * 
	 * 
	 */

	/*
	 * Agent to Environment action functions
	 * 
	 * Remove
	 * Add
	 * 
	 */

	/*
	 * Environment to Agent action functions
	 * 
	 * Heal
	 * Attack
	 * 
	 */





}
