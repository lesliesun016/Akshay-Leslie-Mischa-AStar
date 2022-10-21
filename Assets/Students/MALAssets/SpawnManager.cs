using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> sprites;
    private Vector2 spritePos;
    private int spawnSprite;

    private bool isRunning = false;

    //-81,45  -81,-39  75,45 75, -39
    // Start is called before the first frame update
    void Start()
    {
        randomPosGen();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the coroutine is running if false then starts coroutine
        if(!isRunning)
        {
            StartCoroutine("TimedSpawn");
        }
    }

    //recursive function to generate random spwan position within given limits
    void randomPosGen()
    {
        spritePos = new Vector2(Random.Range(-81,75), Random.Range(-39, 45));
        randomPosGen();                                                                 //used to call function again like a loop instead of calling it everytime on every frame on Update()
    }

//generates a random number for the Spawn Manager to spawn a gameObject 
    void randomSpiteGen()
    {
        spawnSprite = Random.Range(0, sprites.Count);
    }

    //coroutine to create a sprite every 5s
    private IEnumerator TimedSpawn()
    {
        isRunning = true;
        Instantiate(sprites[spawnSprite], spritePos, Quaternion.identity);

        yield return new WaitForSeconds(3);
        isRunning = false;
    }
}
