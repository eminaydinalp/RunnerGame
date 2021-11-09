using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupController : MonoBehaviour
{
	public Button[] buttons;
	public Dictionary<string, float> activePowerups = new Dictionary<string, float>();

	public List<IPowerup> powerupList = new List<IPowerup>();
	
	void Update()
	{
		HandleGlobalPowerups();
	}
	private void HandleGlobalPowerups()
	{

		foreach (IPowerup powerup in powerupList)
		{
			if (activePowerups[powerup.Name] > 0)
			{
				buttons[powerup.Index].interactable = true;
				buttons[powerup.Index].gameObject.transform.GetChild(0).GetComponent<Text>().text = "" + ((int)activePowerups[powerup.Name]);
				activePowerups[powerup.Name] -= Time.deltaTime;
			}
			else
			{
				buttons[powerup.Index].interactable = false;
				powerupList.Remove(powerup);
				activePowerups.Remove(powerup.Name);
				powerup.EndProcess();
			}
		}
	}

	public void ActivatePowerup(IPowerup powerup)
	{
		if (!activePowerups.ContainsKey(powerup.Name))
		{
			powerup.StartProcess();
			activePowerups.Add(powerup.Name, powerup.Duration);
			powerupList.Add(powerup);
		}
		else
		{
			activePowerups[powerup.Name] += powerup.Duration;
		}

	}

}
