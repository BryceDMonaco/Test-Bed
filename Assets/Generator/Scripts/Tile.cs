/*
 *	Author: Bryce Monaco
 *
 *	Last Updated: 8/12/2017
 *
 *	Description: A simple occlusion culling script, it ultimately did not work as expected
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour 
{
	void OnTriggerEnter (Collider col)
	{
		col.GetComponent<MeshRenderer> ().enabled = true;

	}

	void OnTriggerExit (Collider col)
	{
		col.GetComponent<MeshRenderer> ().enabled = false;

	}
}