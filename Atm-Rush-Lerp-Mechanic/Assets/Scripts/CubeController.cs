using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
	private InputAction leftMouseClick;

	private Camera camera;

	private bool isMoving;
	private float moveSpeed;
	private float swipeSpeed;

	private void OnDisable()
	{
		leftMouseClick.Disable();
	}

	private void Start()
	{
		leftMouseClick = new InputAction(binding: "<Mouse>/leftButton");
		leftMouseClick.performed += _ => isMoving = true;
		leftMouseClick.canceled += _ => isMoving = false;
		leftMouseClick.Enable();

		camera = Camera.main;

		isMoving = false;
		moveSpeed = 10f;
		swipeSpeed = 10f;
	}

	private void Update()
	{
		
	}

	private void FixedUpdate()
	{
		transform.position += Vector3.forward * moveSpeed * Time.fixedDeltaTime;
		if (isMoving)
		{
			Move();
		}
	}

	private void Move()
	{
		Vector3 mousePos = Mouse.current.position.ReadValue();
		mousePos.z = camera.transform.localPosition.z;

		Ray ray = camera.ScreenPointToRay(mousePos);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100f))
		{
			GameObject firstCube = ATMRush.Instance.cubes[0];
			Vector3 hitVec = hit.point;
			hitVec.y = firstCube.transform.localPosition.y;
			hitVec.z = firstCube.transform.localPosition.z;

			firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.fixedDeltaTime * swipeSpeed);
		}
	}
}
