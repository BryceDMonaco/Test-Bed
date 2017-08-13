/*
 *	Author: Bryce Monaco
 *
 *	Last Updated: 8/12/2017
 *
 *	Description: A simple script to move a camera along the x and y axes
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	public float moveSpeed;

	void Start () 
	{
		
	}
	
	void FixedUpdate () 
	{
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

		Vector3 translateDirection = new Vector3(h, v, 0); //Ask students what would happen if v was moved to the z axis slot

		transform.Translate(translateDirection); //Once the code is written to here, have the students save and test the movement, check and solve any bugs
	}
}