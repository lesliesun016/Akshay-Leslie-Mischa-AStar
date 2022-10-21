using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarScript : MonoBehaviour {

	public bool check = true;

	//references to scrips
	public GridScript gridScript;
	public HueristicScript hueristic;

	//declares variables
	protected int gridWidth;
	protected int gridHeight;

	GameObject[,] pos;

	public Vector3 start;
	public Vector3 goal;

	public Path path;

	protected PriorityQueue<Vector3> frontier;
	protected Dictionary<Vector3, Vector3> cameFrom = new Dictionary<Vector3, Vector3>();
	protected Dictionary<Vector3, float> costSoFar = new Dictionary<Vector3, float>();
	protected Vector3 current;

	List<Vector3> visited = new List<Vector3>();

	// Use this for initialization
	protected virtual void Start () {
		InitAstar();													//calls the function to initialise A*
	}

	public virtual void InitAstar(){
        InitAstar(new Path(hueristic.gameObject.name, gridScript));     //recursive function to find the path for the object
	}

	protected virtual void InitAstar(Path path){						
		this.path = path;

		//obtains the start and end positions from the grid
		start = gridScript.start;
		goal = gridScript.goal;
		
		//sets the grid width and height from the grid
		gridWidth = gridScript.gridWidth;
		gridHeight = gridScript.gridHeight;

		pos = gridScript.GetGrid();					//gets the posiiton of the Game Object in the grid

		

        //initialize all the variables
        frontier = new PriorityQueue<Vector3>();
        cameFrom = new Dictionary<Vector3, Vector3>();
        costSoFar = new Dictionary<Vector3, float>();
        visited = new List<Vector3>();

        //add the start position to frontier
        frontier.Enqueue(start, 0);

        cameFrom.Add(start, start);                 //sets positions for points A and B which keep updating?
        costSoFar.Add(start, 0);                    // calculates the cost uptil this point
		int exploredNodes = 0;

		while(frontier.Count != 0){
			exploredNodes++;
			current = frontier.Dequeue();			//saves the removed item to current

			visited.Add(current);					//adds current node to a list called visited to track visited nodes

			// changes the scale of tiles
			//pos[(int)current.x, (int)current.y].transform.localScale = 
				//Vector3.Scale(pos[(int)current.x, (int)current.y].transform.localScale, new Vector3(.8f, .8f, .8f));

			if(current.Equals(goal)){
				//Debug.Log("GOOOAL!");
				break;
			}
			
			// adds nodes to frontier horizontally and vertically
			for(int x = -1; x < 2; x+=2){
				AddNodesToFrontier((int)current.x + x, (int)current.y);
			}
			for(int y = -1; y < 2; y+=2){
				AddNodesToFrontier((int)current.x, (int)current.y + y);
			}
		}

		current = goal;

		// initialize line renderer
		LineRenderer line = GetComponent<LineRenderer>();
		line.positionCount = 0;

		int i = 0;
		float score = 0;

		while(!current.Equals(start)){
			line.positionCount++;
			
			GameObject go = pos[(int)current.x, (int)current.y];
			path.Insert(0, go, new Vector3((int)current.x, (int)current.y));

			current = cameFrom[current];

			Vector3 vec = Util.clone(go.transform.position);
			vec.z = -1;

			line.SetPosition(i, vec);
			score += gridScript.GetMovementCost(go);
			i++;
		}

		path.Insert(0, pos[(int)current.x, (int)current.y]);
		path.nodeInspected = exploredNodes;
		/*
		Debug.Log(path.pathName + " Terrian Score: " + score);
		Debug.Log(path.pathName + " Nodes Checked: " + exploredNodes);
		Debug.Log(path.pathName + " Total Score: " + (score + exploredNodes));
		*/
	}

	void AddNodesToFrontier(int x, int y){
		if(x >=0 && x < gridWidth && 
		   y >=0 && y < gridHeight)
		{
			Vector3 next = new Vector3(x, y);
			float new_cost = costSoFar[current] + gridScript.GetMovementCost(pos[x, y]);
			if(!costSoFar.ContainsKey(next) || new_cost < costSoFar[next])
			{
				costSoFar[next] = new_cost;
				float priority = new_cost + hueristic.Hueristic(x, y, start, goal, gridScript);

				frontier.Enqueue(next, priority);
				cameFrom[next] = current;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
