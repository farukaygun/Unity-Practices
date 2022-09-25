using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
	public static Stack Instance;

	public List<GameObject> cubes; // = new List<GameObject>();


	private void Awake()
	{
		Instance = this;	
	}

	private void Start()
	{
		cubes = new List<GameObject>();
		cubes.Add(transform.GetChild(0).gameObject); // assign cubes at the definition line if want to add to list from editor.
	}

	public void StackBoxes(GameObject other)
	{
		other.transform.parent = transform;
		Vector3 newPos = cubes[cubes.Count - 1].transform.localPosition; // last element of cubes' localPosition.
		newPos.y += 0.5f; // height of cube
		other.transform.localPosition = newPos;
		cubes.Add(other);
	}
}
