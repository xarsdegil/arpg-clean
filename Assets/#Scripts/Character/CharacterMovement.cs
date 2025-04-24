using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;

    [Header("References")]
    public Animator animator;
    private Rigidbody rb;

    private Vector3 movementInput;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if(DodgeRollController.Instance.IsDodging()) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector3(horizontal, 0f, vertical).normalized;

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        Vector3 localMovement = transform.InverseTransformDirection(movementInput);
        animator.SetFloat("Horizontal", localMovement.x);
        animator.SetFloat("Vertical", localMovement.z);

        float velocityMagnitude = movementInput.magnitude * currentSpeed;
        animator.SetFloat("Velocity", velocityMagnitude);
    }

    void FixedUpdate()
    {
        Vector3 moveOffset = movementInput * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveOffset);
    }
}
