﻿using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour
{

	public GameObject player;       //Public variable to store a reference to the player game object


	private float offset;         //Private variable to store the offset distance between the player and camera

	Vector3 temp;

	// Use this for initialization
	void Start()
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position.x - player.transform.position.x;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate()
	{
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if ((player.transform.position.x + offset) > 251 && (player.transform.position.x + offset) < 541) {
			temp = new Vector3(player.transform.position.x + offset+1, transform.position.y, transform.position.z);
			transform.position = temp;
		}
    }
}