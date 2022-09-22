using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{
    [SerializeField] private BoxesScriptableObject boxes;
    [SerializeField] private TMP_Text textName;

    private void Start()
    {
        textName.text = boxes.name;
        GetComponent<Renderer>().material.color = boxes.color;
        transform.position = boxes.position;
        transform.localScale = boxes.scale;
    }
}
