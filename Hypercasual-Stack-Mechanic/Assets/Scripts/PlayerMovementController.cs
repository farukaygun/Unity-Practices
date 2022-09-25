using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
	[SerializeField] private InputAction movementAction;
	
	private bool isMoving;
	private Vector2 direction;
	private float horizontal;
	private float vertical;
	private float speed;


	private void OnEnable()
	{
		movementAction.Enable();
	}

	private void OnDisable()
	{
		movementAction.Disable();
	}

	private void Start()
	{
		movementAction.performed += ctx =>
		{
			isMoving = true;
			direction = ctx.ReadValue<Vector2>();
		};
		movementAction.canceled += _ =>
		{
			isMoving = false;
			direction = Vector2.zero;
		};

		speed = 10f;
	}

	private void FixedUpdate()
	{
		if (isMoving)
			Move();
	}

	private void Move()
	{
		transform.position += (Vector3.forward * direction.y + Vector3.right * direction.x) * speed * Time.fixedDeltaTime;
	}
}
