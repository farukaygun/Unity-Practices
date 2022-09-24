using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
	private void OnTriggerEnter(UnityEngine.Collider other)
	{
		//print("1");
		if (other.gameObject.tag == "Cube")
		{
			//print("2");
			if (!ATMRush.Instance.cubes.Contains(other.gameObject))
			{
				//print("3");
				other.GetComponent<BoxCollider>().isTrigger = false;
				other.gameObject.tag = "Untagged";
				other.gameObject.AddComponent<Collider>();
				other.gameObject.AddComponent<Rigidbody>();
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

				ATMRush.Instance.Stack(other.gameObject, ATMRush.Instance.cubes.Count - 1);
			}
		}
	}
}