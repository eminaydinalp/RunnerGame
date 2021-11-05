using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour, IPowerup 
{
	PowerupController powerupController;
	PlayerController playerController;

	[SerializeField]
	float _duration;
	public float speed;

	public float Duration => _duration;

	private void Awake()
	{
		powerupController = FindObjectOfType<PowerupController>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	public void EndProcess()
	{
		playerController.forwardSpeed = playerController.currentSpeed;
		playerController.isPowerup = false;
	}

	public void StartProcess()
	{
		playerController.isPowerup = true;
		playerController.forwardSpeed = speed;
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
