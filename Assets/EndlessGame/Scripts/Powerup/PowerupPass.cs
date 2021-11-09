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
	[SerializeField]
	string _name;
	public string Name => _name;

	public MeshRenderer meshRenderer;

	private void Awake()
	{
		powerupController = GameObject.FindGameObjectWithTag("PowerupController").GetComponent<PowerupController>();
	}
	private void OnEnable()
	{
		meshRenderer.enabled = true;
	}
	public void EndProcess()
	{
		CancelInvoke(nameof(SetObstacle));
		for (int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].GetComponent<BoxCollider>().isTrigger = false;
		}
	}

	public void StartProcess()
	{
		InvokeRepeating(nameof(SetObstacle), 0, 1);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			powerupController.ActivatePowerup(this);
			meshRenderer.enabled = false;
		}
	}
	public void SetObstacle()
	{
		obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		for (int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].GetComponent<BoxCollider>().isTrigger = true;
		}
	}
}
