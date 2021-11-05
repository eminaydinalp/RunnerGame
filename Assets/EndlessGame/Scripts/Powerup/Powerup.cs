using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powerup: MonoBehaviour
{
    PowerupController powerupController;
    PlayerController playerController;

    public float duration;
    public float speed;

	private void Awake()
	{
        powerupController = FindObjectOfType<PowerupController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	public void EndProcess()
    {
        playerController.forwardSpeed = playerController.currentSpeed;
    }

    public void StartProcess()
    {
        playerController.forwardSpeed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePowerup();
            gameObject.SetActive(false);
        }
    }

    private void ActivatePowerup()
    {
        powerupController.ActivatePowerup(this);
    }
}