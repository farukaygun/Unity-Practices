using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
	private void OnTriggerEnter(UnityEngine.Collider other)
	{
		if (other.transform.tag == "Cube")
		{
			if (!Stack.Instance.cubes.Contains(other.gameObject))
			{
				other.gameObject.AddComponent<Rigidbody>();
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				other.gameObject.tag = "Untagged";

				Stack.Instance.StackBoxes(other.gameObject);
			}
		}
	}
}
