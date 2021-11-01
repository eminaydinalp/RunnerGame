using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems", 0) + 1);
			PlayerManager.instance.coinsText.text = "Coin : " + PlayerPrefs.GetInt("TotalGems", 0).ToString();
			gameObject.SetActive(false);
		}
	}
}
