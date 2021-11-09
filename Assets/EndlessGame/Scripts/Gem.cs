using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
	public MeshRenderer meshRenderer;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems", 0) + 1);
			PlayerManager.instance.coinsText.text = "Coin : " + PlayerPrefs.GetInt("TotalGems", 0).ToString();
			meshRenderer.enabled = false;
		}
	}
	private void OnEnable()
	{
		meshRenderer.enabled = true;
	}

}
