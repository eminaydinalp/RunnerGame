using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{

    public Dictionary<Powerup, float> activePowerups = new Dictionary<Powerup, float>();

    private List<Powerup> keys = new List<Powerup>();

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
            foreach (Powerup powerup in keys)
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
            keys = new List<Powerup>(activePowerups.Keys);
        }
    }

    // Adds a global Powerup to the activePowerups list.
    public void ActivatePowerup(Powerup powerup)
    {
        if (!activePowerups.ContainsKey(powerup))
        {
            powerup.StartProcess();
            activePowerups.Add(powerup, powerup.duration);
        }
        else
        {
            activePowerups[powerup] += powerup.duration;
        }

        keys = new List<Powerup>(activePowerups.Keys);
    }

    // Calls the end action of each powerup and clears them from the activePowerups
    public void ClearActivePowerups()
    {
        foreach (KeyValuePair<Powerup, float> Powerup in activePowerups)
        {
            Powerup.Key.EndProcess();
        }

        activePowerups.Clear();
    }

    
}
