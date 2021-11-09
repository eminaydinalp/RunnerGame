using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Magnet : MonoBehaviour
{
    PlayerController playerController;
    public Collider[] hitColliders;

    Vector3 _center;
    float _radius;
    LayerMask _layerMask;


    private void Awake()
	{
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	public void ExplosionDamage(Vector3 center, float radius, LayerMask layerMask)
    {
        _center = center;
        _radius = radius;
        _layerMask = layerMask;
        InvokeRepeating(nameof(Overlap), 0, 0.5f);
    }
    void Overlap()
	{
        hitColliders = Physics.OverlapSphere(_center, _radius, _layerMask);
        StartCoroutine(DoMagnet());
    }
    IEnumerator DoMagnet()
	{
        foreach (var hitCollider in hitColliders)
        {
            GameObject gem = hitCollider.gameObject;
            gem.transform.DOMove(playerController.transform.position, 0.3f);
            yield return new WaitForSeconds(0.1f);
        }
	}
}
