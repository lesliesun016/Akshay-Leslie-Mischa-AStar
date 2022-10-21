using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class GetMouseClick : MonoBehaviour
{
    public Vector3 clickedTile;

    public GridScript gridScript;
    public AStarScript aStar;
    public FollowAStarScript followAStar;

    private void Start()
    {
        //caches data
        gridScript = GameObject.Find("Grid").GetComponent<FirstGridScript>();
        aStar = GameObject.Find("Princess").GetComponent<AStarScript>();
        followAStar = GameObject.Find("Princess").GetComponent<FollowAStarScript>();
    }

    private void OnMouseDown()
    {
        //reset A star path based on the locations of current tile and clicked tile
        int steps = aStar.path.steps;
        if (steps > 1)
        {
            if (followAStar.currentStep < steps)
            {
                gridScript.start = aStar.path.Get(followAStar.currentStep).gridPos;
            }
            else
            {
                // minus 1 if the character reached the goal in the last click
                gridScript.start = aStar.path.Get(followAStar.currentStep - 1).gridPos;
            }

        }
        gridScript.goal = clickedTile;
        aStar.InitAstar();

        //change move steps in followAStar
        followAStar.path = aStar.path;
        followAStar.move = true;
        followAStar.currentStep = 1;
        followAStar.startPos = followAStar.path.Get(0);
        followAStar.destPos = followAStar.path.Get(1);

        //transform.position = followAStar.startPos.gameObject.transform.position;
        GameObject.Find("Princess").transform.position = followAStar.startPos.gameObject.transform.position;
        //followAStar.startTime = Time.realtimeSinceStartup;
        //followAStar.travelStartTime = Time.realtimeSinceStartup;
    }
}
