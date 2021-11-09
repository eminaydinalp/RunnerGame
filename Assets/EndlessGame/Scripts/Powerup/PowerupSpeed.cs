using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupSpeed : MonoBehaviour, IPowerup 
{
	PowerupController powerupController;
	PlayerController playerController;

	[SerializeField]
	float _duration;
	public float speed;
	public float Duration => _duration;
	[SerializeField]
	int index;
	public int Index => index;
	[SerializeField]
	string _name;
	public string Name => _name;

	public MeshRenderer meshRenderer;

	private void Awake()
	{
		powerupController = GameObject.FindGameObjectWithTag("PowerupController").GetComponent<PowerupController>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	private void OnEnable()
	{
		meshRenderer.enabled = true;
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
			meshRenderer.enabled = false;
		}
	}

}
