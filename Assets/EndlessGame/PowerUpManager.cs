using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    //public List<IPowerup> powerUps = new List<IPowerup>();
    public List<GameObject> powerUps = new List<GameObject>();
	public List<float> powerUpsStartDuration = new List<float>();
	public List<float> powerUpsCurrentTimers = new List<float>();

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (powerUps[0].activeInHierarchy)
			{
				//AddTime(duration);
			}
			else
			{
				StartCoroutine(OpenPowerUp(powerUps[0], 5));
			}
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			OpenPowerUp(powerUps[1], powerUps[1].GetComponent<PowerupMagnet>().Duration);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			OpenPowerUp(powerUps[2], powerUps[2].GetComponent<PowerupMagnet>().Duration);
		}
	}

	private IEnumerator OpenPowerUp(GameObject powerUp, float duration)
	{
		powerUp.SetActive(true);
		yield return new WaitForSeconds(duration);
		powerUp.SetActive(false);
	}
}
