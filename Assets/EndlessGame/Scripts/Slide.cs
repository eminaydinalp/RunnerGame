using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
	PlayerController playerController;
    public Vector3 firstColliderSize;
    public Vector3 firstColliderCenter;
    public Vector3 slideColliderSize;
    public Vector3 slideColliderCenter;

    public float slideTime;

	private void Awake()
	{
		playerController = GetComponent<PlayerController>();
	}
	public IEnumerator DoSlide()
	{
		playerController._animator.SetBool("isSliding", true);
		BoxCollider boxCollider = GetComponent<BoxCollider>();
		boxCollider.center = slideColliderCenter;
		boxCollider.size = slideColliderSize;

		yield return new WaitForSeconds(slideTime);

		playerController._animator.SetBool("isSliding", false);
		boxCollider.center = firstColliderCenter;
		boxCollider.size = firstColliderSize;
	}




}
