using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{

    public Dictionary<IPowerup, float> activePowerups = new Dictionary<IPowerup, float>();

    public List<IPowerup> keys = new List<IPowerup>();

    // Handles the beginning and ending of activated Powerups.
    // Inactive Powerups are removed automatically.
    void Update()
    {
        HandleGlobalPowerups();
    }
    private void HandleGlobalPowerups()
    {
        bool changed = false;

        if (activePowerups.Count > 0)
        {
            foreach (IPowerup powerup in keys)
            {
                if (activePowerups[powerup] > 0)
                {
                    activePowerups[powerup] -= Time.deltaTime;
                }
                else
                {
                    changed = true;

                    activePowerups.Remove(powerup);

                    //if (powerup.endAction != null)
                    powerup.EndProcess();
                }
            }
        }

        if (changed)
        {
            keys = new List<IPowerup>(activePowerups.Keys);
        }
    }

    // Adds a global Powerup to the activePowerups list.
    public void ActivatePowerup(IPowerup powerup)
    {
        if (!activePowerups.ContainsKey(powerup))
        {
            powerup.StartProcess();
            activePowerups.Add(powerup, powerup.Duration);
        }
        else
        {
            activePowerups[powerup] += powerup.Duration;
        }

        keys = new List<IPowerup>(activePowerups.Keys);
    }
    
}
