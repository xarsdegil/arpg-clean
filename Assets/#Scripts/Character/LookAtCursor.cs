using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    public static LookAtCursor Instance { get; private set; }

    private Camera mainCamera;

    [SerializeField]
    private float rotationSpeed = 10f;

    private bool lookLocked = false;
    private Vector3 lockedPos;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(DodgeRollController.Instance.IsDodging()) return;

        Vector3 targetDirection = lookLocked ? GetLockedLookDirection() : GetMouseLookDirection();

        if (targetDirection != Vector3.zero)
        {
            RotateTowards(targetDirection);
        }
    }

    private Vector3 GetLockedLookDirection()
    {
        Vector3 direction = lockedPos - transform.position;
        direction.y = 0f;
        return direction.normalized;
    }

    private Vector3 GetMouseLookDirection()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast(ray, out float rayDistance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(rayDistance);
            Vector3 direction = mouseWorldPosition - transform.position;
            direction.y = 0f;
            return direction.normalized;
        }
        return Vector3.zero;
    }

    private void RotateTowards(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void SetLookLock(bool isLocked, Vector3 position)
    {
        lookLocked = isLocked;
        lockedPos = position;
    }

    public void SetLookLock(bool isLocked)
    {
        lookLocked = isLocked;
    }
}
