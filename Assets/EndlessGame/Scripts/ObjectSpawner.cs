using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public bool spawningObject = false;
	public float groundSpawnDistance = 50f;

    public static ObjectSpawner instance;

	private void Awake()
	{
		instance = this;
	}

	public void SpawnGround()
	{
		int index = Random.Range(0, 6);

		switch (index)
		{
			case 0:
				ObjectPooler.instance.SpawnFromPool("ground1", new Vector3(0, 0, TileManager.instance.endTile.transform.position.z + 29), Quaternion.identity);
				break;
			case 1:
				ObjectPooler.instance.SpawnFromPool("ground2", new Vector3(0, 0, TileManager.instance.endTile.transform.position.z + 29), Quaternion.identity);
				break;
			case 2:
				ObjectPooler.instance.SpawnFromPool("ground3", new Vector3(0, 0, TileManager.instance.endTile.transform.position.z + 29), Quaternion.identity);
				break;
			case 3:
				ObjectPooler.instance.SpawnFromPool("ground4", new Vector3(0, 0, TileManager.instance.endTile.transform.position.z + 29), Quaternion.identity);
				break;
			case 4:
				ObjectPooler.instance.SpawnFromPool("ground5", new Vector3(0, 0, TileManager.instance.endTile.transform.position.z + 29), Quaternion.identity);
				break;
			case 5:
				ObjectPooler.instance.SpawnFromPool("ground6", new Vector3(0, 0, TileManager.instance.endTile.transform.position.z + 29), Quaternion.identity);
				break;
		}
			

		
	}
}
