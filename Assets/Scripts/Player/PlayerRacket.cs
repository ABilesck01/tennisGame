using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : MonoBehaviour
{
    [SerializeField] private Transform racketPosition;
    [SerializeField] private float range;
    [SerializeField] private LayerMask ballLayer;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("swing");
        }
    }

    public void Swing()
    {
        var ball = Physics.OverlapSphere(racketPosition.position, range, ballLayer);
        if (ball.Length <= 0) return;

        if(ball[0].TryGetComponent(out BallController controller))
        {
            controller.HandleSwing(-transform.position.x);
        }
    }
}
