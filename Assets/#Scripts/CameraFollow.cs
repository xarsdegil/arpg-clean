using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Kamera Ayarları")]
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -10f);
    [Tooltip("SmoothDamp için süre değeri")]
    public float smoothTime = 0.3f;

    // SmoothDamp için hızı takip edecek vektör
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        // SmoothDamp ile yumuşak geçiş
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.position = smoothedPosition;
    }
}
