using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
	Slide slide;
	Rigidbody _rigidbody;
	public Animator _animator;
	public Transform groundCheck;
	public Transform followCameraTarget;
	public LayerMask groundLayer;

	public int desiredLane = 1;
	public float laneDistance = 2.5f;
	public float jumpForce;
	public float forwardSpeed;
	public float currentSpeed;
	public bool isPowerup;

	public bool isGrounded;
	public bool isGameStarted;



	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		slide = GetComponent<Slide>();
	}

	private void Start()
	{
		isGameStarted = true;
	}
	private void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);

		ChangeLane();

		if (isGrounded)
		{
			if (SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}		
		}

		if (SwipeManager.swipeDown) StartCoroutine(slide.DoSlide());

		_animator.SetBool("isGrounded", isGrounded);
		//_animator.SetBool("isGameStarted", isGameStarted);
		

	}
	private void FixedUpdate()
	{
		if(!isPowerup)
		{
			currentSpeed = forwardSpeed;
			forwardSpeed += 0.2f * Time.deltaTime;
		}
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			PlayerManager.instance.GameOver();
		}
	}

	public void ChangeLane()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
		{
			desiredLane++;
			if (desiredLane == 3) desiredLane = 2;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
		{
			desiredLane--;
			if (desiredLane == -1) desiredLane = 0;
		}

		Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

		if (desiredLane == 0) targetPosition += Vector3.left * laneDistance;
		else if (desiredLane == 2) targetPosition += Vector3.right * laneDistance;

		transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
	}

	public void Jump()
	{
		_rigidbody.AddForce(Vector3.up * jumpForce);
	}

}
