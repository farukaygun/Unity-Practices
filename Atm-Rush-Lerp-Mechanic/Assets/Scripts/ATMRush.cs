using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ATMRush : MonoBehaviour
{
	public static ATMRush Instance { get; private set; }

	private InputAction leftMouseClick;
	private bool isMoving;

	public List<GameObject> cubes;

	private void OnDisable()
	{
		leftMouseClick.Disable();
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		leftMouseClick = new InputAction(binding: "<Mouse>/leftButton");
		leftMouseClick.performed += _ => isMoving = true;
		leftMouseClick.canceled += _ => isMoving = false;
		leftMouseClick.Enable();

		cubes = new List<GameObject>();
		cubes.Add(transform.GetChild(0).gameObject);
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (isMoving) MoveListElements();
		else MoveOrigin();
	}

	// other: collided cube
	public void Stack(GameObject other, int index)
	{
		other.transform.parent = transform;
		Vector3 newPos = cubes[index].transform.localPosition;
		newPos.z += 1; // every cube's scale is 1.
		other.transform.localPosition = newPos;
		cubes.Add(other);

		StartCoroutine(BiggerAnimation());
	}

	private IEnumerator BiggerAnimation()
	{
		for (int i = cubes.Count - 1 ; i > 0; i--)
		{
			int index = i;
			Vector3 scale = Vector3.one;
			scale *= 1.5f;
			cubes[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
				cubes[index].transform.DOScale(Vector3.one, 0.1f)
			);
			yield return new WaitForSeconds(0.05f);
		}
	}

	private void MoveListElements()
	{
		for (int i = 1; i < cubes.Count; i++)
		{
			Vector3 pos = cubes[i].transform.localPosition;
			pos.x = cubes[i - 1].transform.localPosition.x;
			cubes[i].transform.DOLocalMove(pos, 0.25f);
		}
	}

	// Return to base cube's x position.
	private void MoveOrigin()
	{
		for (int i = 1; i < cubes.Count; i++)
		{
			Vector3 pos = cubes[i].transform.localPosition;
			pos.x = cubes[0].transform.localPosition.x;
			cubes[i].transform.DOLocalMove(pos, 0.25f);
		}
	}
}
