using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path {

	//declaring variables
	public string pathName;
	public int nodeInspected;

	public GridScript gridScipt;
	public List<Step> path = new List<Step>();

	public float score;
	public int steps;

	//construcors for Path
	public Path(string name, GridScript gridScipt){								//sets path name and grid Script. Constructor for the class Path
		this.gridScipt = gridScipt;
		pathName = name;
	}

	public Step Get(int index){													//returns an element of type Step from the List path
		return path[index];
	}
	
	public virtual void Insert(int index, GameObject go){						//stores stepcost and gameobkect in the list name path
		float stepCost = gridScipt.GetMovementCost(go);
		score += stepCost;
		
		path.Insert(index, new Step(go, stepCost));
		
		steps++;
	}

	public virtual void Insert(int index, GameObject go, Vector3 gridPos){		//overloaded insert function that saves the stepcost, the game object and grid position
		float stepCost = gridScipt.GetMovementCost(go);
		score += stepCost;
		
		path.Insert(index, new Step(go, stepCost, gridPos));

		steps++;
	}
}
