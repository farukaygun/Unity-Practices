using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoxesScriptableObject", menuName = "Box")]
public class BoxesScriptableObject : ScriptableObject
{
    public string name = "New Box";
    public Color color = Color.white;
    public Vector3 position = Vector3.zero;
    public Vector3 scale = Vector3.one;
}
