using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float speed = 360;
    [SerializeField] private Vector3 axis;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    private void Update()
    {
        myTransform.Rotate(Time.deltaTime * speed * axis);
    }
}
