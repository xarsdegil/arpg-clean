using System.Collections;
using UnityEngine;

public class DodgeRollController : MonoBehaviour
{
    public static DodgeRollController Instance { get; private set; }

    [SerializeField] Animator animator;
    [SerializeField] float dodgeSpeed = 10f;       // Dodge roll sırasında uygulanacak hız
    [SerializeField] float dodgeDuration = 0.5f;   // Dodge roll süresi
    [SerializeField] float rotationDuration = 0.2f; // Dönüş için harcanan süre

    Rigidbody rb;
    bool isDodging = false;
    Camera mainCamera;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Space tuşuna basıldığında ve henüz dodge roll yapılmıyorsa
        if (Input.GetKeyDown(KeyCode.Space) && !isDodging)
        {
            DodgeRoll();
        }
    }

    private void DodgeRoll()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 dodgeDirection;

        if (movementInput == Vector3.zero)
        {
            // Hareket inputu yoksa, ekranın soluna göre dodge yönü belirle
            dodgeDirection = -mainCamera.transform.right;
            dodgeDirection.y = 0f;
            dodgeDirection.Normalize();

            animator.SetTrigger("DodgeRoll");
            StartCoroutine(PerformDodge(dodgeDirection));
        }
        else
        {
            // Hareket inputu varsa, dodge yönünü kamera referanslı olarak hesapla
            dodgeDirection = mainCamera.transform.TransformDirection(movementInput);
            dodgeDirection.y = 0f;
            dodgeDirection.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(dodgeDirection);
            StartCoroutine(RotateThenRoll(targetRotation, dodgeDirection));
        }
    }

    private IEnumerator RotateThenRoll(Quaternion targetRotation, Vector3 dodgeDirection)
    {
        isDodging = true;
        Quaternion initialRotation = transform.rotation;
        float elapsedTime = 0f;

        // Belirtilen süre boyunca karakteri hedef rotasyona yumuşak döndür
        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;

        animator.SetTrigger("DodgeRoll");
        yield return StartCoroutine(PerformDodge(dodgeDirection));
    }

    private IEnumerator PerformDodge(Vector3 dodgeDirection)
    {
        float elapsedTime = 0f;
        while (elapsedTime < dodgeDuration)
        {
            rb.linearVelocity = dodgeDirection * dodgeSpeed;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.linearVelocity = Vector3.zero;
        isDodging = false;
    }

    public bool IsDodging()
    {
        return isDodging;
    }
}
