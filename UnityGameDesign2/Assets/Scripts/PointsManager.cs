using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour {

	public GameObject Point;

	public GameObject[] spawnPoints;
    public GameObject[] spawnPointsBackwards;
	//make two lots of spawn points for when you switch the points will spawn on the other sides of platforms

	GameWorld gameWorld;
	// Use this for initialization
	void Start () {

		gameWorld = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameWorld>();


	}

	// Update is called once per frame
	void Update () {

		
			
	}


    public void spawn(bool backwards)
    {

		//if backward ==false
		if (gameWorld.backwards == false)
		{
			int size = spawnPoints.Length;
			List<int> index = new List<int>();

			for (int count = 0; count < size; count++)
			{
				if (spawnPoints[count].GetComponent<spawnPoint>().Collision == false)
				{
					index.Add(count);
				}
			}



			int spawnPointIndex = Random.Range(0, index.Count);

			//creates instanceof the point prefab at selected location
			Vector3 pos = new Vector3(spawnPoints[index[spawnPointIndex]].transform.position.x, spawnPoints[index[spawnPointIndex]].transform.position.y, 5);

			Instantiate(Point, pos, spawnPoints[index[spawnPointIndex]].transform.rotation);

		}
		else {

			int size = spawnPointsBackwards.Length;
			List<int> index = new List<int>();

			for (int count = 0; count < size; count++)
			{
				if (spawnPointsBackwards[count].GetComponent<spawnPoint>().Collision == false)
				{
					index.Add(count);
				}
			}



			int spawnPointIndex = Random.Range(0, index.Count);

			//creates instanceof the point prefab at selected location
			Vector3 pos = new Vector3(spawnPointsBackwards[index[spawnPointIndex]].transform.position.x, spawnPointsBackwards[index[spawnPointIndex]].transform.position.y, 5);

			Instantiate(Point, pos, spawnPointsBackwards[index[spawnPointIndex]].transform.rotation);

		}

        //if backwards == true use the second array of transforms to spawn points at

    }

}
