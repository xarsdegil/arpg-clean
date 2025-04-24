using UnityEngine;

public class LookAtCursorSpellOrigins : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private float rotationSpeed = 10f;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 targetDirection = GetMouseLookDirection();

        if (targetDirection != Vector3.zero)
        {
            RotateTowards(targetDirection);
        }
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
}
