using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
	public static TileManager instance;
	public GameObject endTile;

	private void Awake()
	{
		instance = this;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ground"))
		{
			endTile = other.gameObject.transform.parent.gameObject;
		}
	}

}
