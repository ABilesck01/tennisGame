using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    [Header("Angle controller")]
    [SerializeField] private float minAngle = 0f;
    [SerializeField] private float middleAngle = 0f;
    [SerializeField] private float maxAngle = 0f;
    [Space]
    [SerializeField] private float minPosition_x;
    [SerializeField] private float maxPosition_x;
    [Header("Height controller")]
    [SerializeField] private float minHeight = 0f;

    [SerializeField] private float middleHeightNegative = 0f;
    [SerializeField] private float middleHeightPositive = 0f;
    
    [SerializeField] private float maxHeight = 0f;
    [SerializeField] private float minPosition_y;
    [SerializeField] private float maxPosition_y;

    private Transform myTransform;
    private Vector3 direction;

    void Start()
    {
        direction = new Vector3(0f, 0f, 1f).normalized;
        myTransform = transform;
    }

    void Update()
    {
        HandleHeight();
        myTransform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger enter - {other.tag}");

        if (other.CompareTag("Paddle"))
        {
            switchSides();
            direction.z = -direction.z;
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, -myTransform.rotation.y, myTransform.rotation.z);
        }
        else if (other.CompareTag("Wall"))
        {
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, -myTransform.rotation.y, myTransform.rotation.z);
        }
    }

    public void HandleHeight()
    {
        var lerpValue = SuperMath.Remap(myTransform.position.z, minPosition_y, maxPosition_y, 0, 1);
        var height = SuperMath.CubicLerp(minHeight, middleHeightNegative, middleHeightPositive, maxHeight, lerpValue);
        Debug.Log(lerpValue);
        myTransform.position = new Vector3(myTransform.position.x, height, myTransform.position.z);
    }

    public void HandleSwing(float x)
    {
        var lerpValue = SuperMath.Remap(myTransform.position.x, minPosition_x, maxPosition_x, 0, 1);
        var angle = SuperMath.QuadraticLerp(minAngle, middleAngle, maxAngle, lerpValue);
        switchSides();
        //direction.x = angle;
        myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, angle, myTransform.rotation.z);
        direction.z = -direction.z;
    }

    private void switchSides()
    {
        float temp = middleHeightPositive;
        middleHeightPositive = middleHeightNegative;
        middleHeightNegative = temp;
    }
}
