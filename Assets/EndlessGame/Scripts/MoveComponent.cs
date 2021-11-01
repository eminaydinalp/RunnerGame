using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	PlayerController playerController;
    public float objectDistance;
    public float despawnDistance;
    public bool canSpawnGround = true;

	private void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	private void Update()
	{
		transform.position += playerController.forwardSpeed * Time.deltaTime * -transform.forward;

		if(transform.position.z <= objectDistance && transform.CompareTag("Ground") && canSpawnGround)
		{
			ObjectSpawner.instance.SpawnGround();
			canSpawnGround = false;
		}
		if(transform.position.z <= despawnDistance)
		{
			canSpawnGround = true;
			gameObject.SetActive(false);
		}
	}
	


}
