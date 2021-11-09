using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupMagnet : MonoBehaviour, IPowerup
{
	PowerupController powerupController;
	PlayerController playerController;
	[SerializeField]
	float _duration;
	public float Duration => _duration;
	
	[SerializeField]
	int index;
	public int Index => index;
	[SerializeField]
	string _name;
	public string Name => _name;

	public MeshRenderer meshRenderer;

	public GameObject magnetPrefab;
	GameObject magnet;
	public LayerMask layerMask;

	private void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		powerupController = GameObject.FindGameObjectWithTag("PowerupController").GetComponent<PowerupController>();
	}
	private void OnEnable()
	{
		meshRenderer.enabled = true;
	}
	public void EndProcess()
	{
		Destroy(magnet);
	}

	public void StartProcess()
	{
		magnet = Instantiate(magnetPrefab, playerController.gameObject.transform.position, Quaternion.identity);
		magnet.GetComponent<Magnet>().ExplosionDamage(magnet.transform.position, 10f, layerMask);
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
