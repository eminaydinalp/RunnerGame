using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPass : MonoBehaviour, IPowerup
{
	PowerupController powerupController;

	[SerializeField]
	float _duration;
	public float Duration => _duration;

	public BoxCollider[] obstacles;

	private void Awake()
	{
		powerupController = FindObjectOfType<PowerupController>();
	}
	public void EndProcess()
	{
		for (int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].isTrigger = false;
		}
	}

	public void StartProcess()
	{
		for (int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].isTrigger = true;
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
