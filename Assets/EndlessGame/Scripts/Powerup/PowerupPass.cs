using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerupPass : MonoBehaviour, IPowerup
{
	PowerupController powerupController;

	[SerializeField]
	float _duration;
	public float Duration => _duration;
	[SerializeField]
	int index;
	public int Index => index;
	public GameObject[] obstacles;

	private void Awake()
	{
		powerupController = GameObject.FindGameObjectWithTag("PowerupController").GetComponent<PowerupController>();
	}
	
	public void EndProcess()
	{
		for (int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].GetComponent<BoxCollider>().isTrigger = false;
		}
	}

	public void StartProcess()
	{
		obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		for (int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].GetComponent<BoxCollider>().isTrigger = true;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			powerupController.ActivatePowerup(this);
			gameObject.SetActive(false);
		}
	}
}
