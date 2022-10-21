using UnityEngine;
using System.Collections;

public class Step {

	//declaring variables
	public GameObject gameObject;
	public float moveCost;
	public Vector3 gridPos;

	
	//constructors for step
	public Step(GameObject gameObject, float cost){						//sets up the gameObject and the move cost
		this.gameObject = gameObject;
		moveCost = cost;
	}

	public Step(GameObject gameObject, float cost, Vector3 gridPos){	//sets up the gameObject, grid position and the move cost
		this.gameObject = gameObject;
		moveCost = cost;
		this.gridPos = gridPos;
	}
}
