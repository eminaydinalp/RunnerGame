using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SmoothFollowUsual : MonoBehaviour
{
    PlayerController playerController;
    private static SmoothFollowUsual instance = null;
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 10.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    // How much we 
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    public float movementDamping = 1.0f;
    private Vector3 lastLocation;
    // Place the script in the Camera-Control group in the component menu
    [AddComponentMenu("Camera-Control/Smooth Follow")]

    public static SmoothFollowUsual Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	private void Start()
	{
        target = playerController.followCameraTarget;
	}

	public void StarttoTurn()
    {
        if (height != 1)
        {
            target.transform.DOLocalMove(new Vector3(0, 1.5f, 0), 0.5f).OnComplete(() => {
                target.transform.DORotate(new Vector3(0, 360, 0), 10, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
            });
            target.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

            rotationDamping = 10;
            distance = 8;
            height = 1;
        }
    }

    void LateUpdate()
    {

        if (!target)
            return;

        var wantedHeight = target.position.y + height;
        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        currentRotationAngle = target.eulerAngles.y;

        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        var pos = target.position;
        pos -= currentRotation * Vector3.forward * distance;
        pos.y = wantedHeight;

        transform.position = Vector3.Lerp(transform.position, pos, movementDamping * Time.deltaTime);

        var q = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationDamping * Time.deltaTime);
    }
}
