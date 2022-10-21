using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GridScript gridScript;
    public AStarScript aStar;

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        //sets target position
        targetPos = transform.position;

        //caches data
        gridScript = GameObject.Find("Grid").GetComponent<FirstGridScript>();
        aStar = GameObject.Find("Princess").GetComponent<AStarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // find click position
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // add offset
            float offsetX = (gridScript.gridWidth * -gridScript.spacing) / 2f;
            float offsetY = (gridScript.gridHeight * gridScript.spacing) / 2f;
            targetPos.x = offsetX + targetPos.x * gridScript.spacing;
            targetPos.y = offsetY - (int)targetPos.y * gridScript.spacing;
            targetPos.z = 0;

            // update start and goal positions
            gridScript.start = GameObject.Find("Princess").transform.position;
            gridScript.goal = targetPos;

            // update aStar
            aStar.InitAstar();
        }
    }
}
