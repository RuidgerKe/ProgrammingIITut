using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera cam;
    [SerializeField] Animator animator;

    [SerializeField] float jumpHeight = 8f;
    [SerializeField] float moveSpeed = 10f;

    PlayerBehavior behavior;

    Vector2 move;
    Vector2 lookVector;
    Vector3 cameraRotation;

    private float distanceToGround;
    private bool isGrounded = true;
    private bool isWalking = false;
    private Vector2 rotate;

    public GameObject projectile;
    public Transform projectilePos;

    //health check
    CharacterStats cs;

    private void Awake()
    {
        behavior = new PlayerBehavior();

        behavior.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        behavior.Player.Move.canceled += cntxt => move = Vector2.zero;

        behavior.Player.Jump.performed += cntxt => Jump();

        behavior.Player.Look.performed += cntxt => rotate = cntxt.ReadValue<Vector2>();
        behavior.Player.Look.canceled += cntxt => rotate = Vector2.zero;

        behavior.Player.Attack.performed += cntxt => Attack();

        //health check
        cs = GetComponent<CharacterStats>();
        behavior.Player.TakeDamage.performed += cntxt => cs.TakeDamage(2);
            
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        distanceToGround = GetComponent<Collider>().bounds.extents.y;

        cameraRotation = transform.eulerAngles; //easier than imputting all seperate axis's
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        behavior.Player.Enable();
    }
    private void Update()
    {
        cameraRotation = new Vector3(cameraRotation.x + rotate.y, cameraRotation.y + rotate.x, 0);

        transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * moveSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * moveSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);

    }
    private void LateUpdate()
    {
        //cam.transform.eulerAngles = new Vector3(cameraRotation.x, cameraRotation.x, cameraRotation.z);
        cam.transform.rotation = Quaternion.Euler(cameraRotation);
    }
    private void OnDisable()
    {
        behavior.Player.Disable();
    }

    void Attack()
    {
        Rigidbody rbBullet = Instantiate(projectile, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        rbBullet.AddForce(Vector3.forward * 32f, ForceMode.Impulse);
        Destroy(rbBullet, 5);
    }

    private void Jump()
    {
        if (!isGrounded) return;
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -Vector3.up * distanceToGround);
    }

}