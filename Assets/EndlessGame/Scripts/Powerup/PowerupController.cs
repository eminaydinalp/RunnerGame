using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupController : MonoBehaviour
{
	public Button[] buttons;
	//public Dictionary<IPowerup, float> activePowerups = new Dictionary<IPowerup, float>();

	public List<IPowerup> activePowerUps = new List<IPowerup>();
	//public List<string> names = new List<string>();


	// Handles the beginning and ending of activated Powerups.
	// Inactive Powerups are removed automatically.
	void Update()
	{
		HandleGlobalPowerups();
	}
	private void HandleGlobalPowerups()
	{

		foreach (IPowerup powerup in activePowerUps)
		{
			if (powerup.Duration > 0)
			{
				buttons[powerup.Index].interactable = true;
				buttons[powerup.Index].gameObject.transform.GetChild(0).GetComponent<Text>().text = "" + ((int)powerup.Duration);
				powerup.Duration -= Time.deltaTime;
			}
			else
			{
				buttons[powerup.Index].interactable = false;
				activePowerUps.Remove(powerup);
				//names.Remove(powerup.Name);
				//count.Remove(activePowerups[powerup]);
				//if (powerup.endAction != null)
				powerup.EndProcess();
			}
		}
	}

	// Adds a global Powerup to the activePowerups list.
	public void ActivatePowerup(IPowerup powerup)
	{
		//if (!activePowerups.ContainsKey(powerup))
		//{
		//    Debug.Log(powerup);
		//    powerup.StartProcess();
		//    activePowerups.Add(powerup, powerup.Duration);
		//}
		//else
		//{
		//    activePowerups[powerup] += powerup.Duration;
		//}

		//keys = new List<IPowerup>(activePowerups.Keys);

		if (activePowerUps == null)
		{
			powerup.StartProcess();
			activePowerUps.Add(powerup);
			//names.Add(powerup.Name);
		}
		else
		{
			for (int i = 0; i < activePowerUps.Count; i++)
			{
				if (activePowerUps[i].Name == powerup.Name)
				{
					activePowerUps[i].Duration += powerup.Duration;
				}
			}
		}

	}

}
