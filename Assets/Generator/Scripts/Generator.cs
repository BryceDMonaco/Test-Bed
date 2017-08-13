/*
 *	Author: Bryce Monaco
 *
 *	Last Updated: 8/12/2017
 *
 *	Description: This script generates a simple 2D map using random generation
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour 
{
	[Header("Generator Settings")]
	public bool useSeed = false;
	public int generatorSeed;

	public int maxTileAmount = 10;
	private int tileCount = 0;
	private int attemptCount = 0;

	public int maxDirectionChecks = 3; //Number of times the gen will attept to find an open direction (it picks a dir randomly)

	public GameObject tileObject;

	public float tileSize = 10f;

	private GameObject[] tileArray;
	private GameObject lastFocusedTile; //The tile to use as a base to generate the next tile
	private Vector3[] offsets = {new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1)};

	void Start () 
	{
		if (useSeed)
		{
			Random.InitState (generatorSeed);

		}
			
		tileArray = new GameObject[maxTileAmount];

		PlaceFirstTile ();

		while (tileCount < maxTileAmount)
		{
			GenerateNewTile ();

		}
		
	}

	void PlaceFirstTile ()
	{
		GameObject newTile = Instantiate (tileObject, new Vector3(0, 0, 0), Quaternion.identity);

		tileArray [tileCount] = newTile;

		tileCount++;

		lastFocusedTile = newTile;

		return;

	}

	void GenerateNewTile ()
	{
		attemptCount++;

		bool isSpaceOpen = false;
		int direction = 0;

		for (int i = 0; i < maxDirectionChecks; i++)
		{
			direction = Random.Range (0, 3);

			if (CheckForTileAtDirection(direction)) //True if an open space is found
			{
				isSpaceOpen = true;

				break;

			} else if (i == (maxDirectionChecks - 1)) //If the last check failed
			{
				lastFocusedTile = tileArray [Random.Range (0, tileCount - 1)]; //Move back to a new tile

			}
		}

		if (!isSpaceOpen)
		{
			return; //Try again with the new randomly chosen tile

		}

		//By this point in the algorithm a valid spot should be found
		attemptCount = 0;

		GameObject newTile = Instantiate (tileObject, lastFocusedTile.transform.position + (tileSize * offsets [direction]), Quaternion.identity);

		tileArray [tileCount] = newTile;

		tileCount++;

		lastFocusedTile = newTile;

		return;


	}

	bool CheckForTileAtDirection (int direction)
	{
		/*
		 *	0 = +x Right
		 *	1 = -x Left
		 *	2 = +z Up
		 *	3 = -z Down
		 */

		//Debug.Log ("Checking in direction " + direction);

		if (Physics.Raycast(lastFocusedTile.transform.position, offsets[direction], tileSize))
		{
			return false; //The space is occupied

		} else
		{
			return true; //The space is open

		}
	}
}