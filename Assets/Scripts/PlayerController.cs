using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera cam;
    [SerializeField] Animator animator;

    [SerializeField] float jumpHeight = 8f;
    [SerializeField] float moveSpeed = 10f;

    PlayerBehavior behavior;

    Vector2 xy;
    Vector2 lookVector;
    Vector3 cameraRotation;

    private float distanceToGround;
    private bool isGrounded;
    private bool isWalking;

    private void Awake()
    {
        behavior = new PlayerBehavior();
        
        behavior.Player.Move.performed += cntxt => xy = cntxt.ReadValue<Vector2>();
        behavior.Player.Move.canceled += cntxt => xy = Vector2.zero;

        behavior.Player.Jump.performed += cntxt => Jump();
    }

    private void OnEnable()
    {
        
    }
    private void Update()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void Jump()
    {

    } 

}
