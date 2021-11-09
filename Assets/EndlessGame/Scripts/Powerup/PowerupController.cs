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
		for (int i = 0; i < powerupList.Count; i++)
		{
			if(activePowerups.ContainsKey(powerupList[i].Name))
			{
				if (activePowerups[powerupList[i].Name] > 0)
				{
					buttons[powerupList[i].Index].interactable = true;
					buttons[powerupList[i].Index].gameObject.transform.GetChild(0).GetComponent<Text>().text = "" + ((int)activePowerups[powerupList[i].Name]);
					activePowerups[powerupList[i].Name] -= Time.deltaTime;
				}
				else
				{
					buttons[powerupList[i].Index].interactable = false;
					activePowerups.Remove(powerupList[i].Name);
					powerupList[i].EndProcess();
					powerupList.Remove(powerupList[i]);					
				}
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
