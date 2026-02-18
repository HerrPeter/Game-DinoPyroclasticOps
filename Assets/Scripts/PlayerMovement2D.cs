using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 8f;

    [SerializeField]
    private float screenPadding = 0.5f;

    [SerializeField]
    private bool allowVerticalMovement = false;

    private Rigidbody2D rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void Update()
    {
        float x = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                x -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                x += 1f;
        }

        input = new Vector2(x, 0f).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }

    void LateUpdate()
    {
        var cam = Camera.main;
        if (cam == null || !cam.orthographic)
            return;

        Vector3 pos = transform.position;

        float vertExtent = cam.orthographicSize;
        float horizExtent = vertExtent * cam.aspect;

        float minX = cam.transform.position.x - horizExtent + screenPadding;
        float maxX = cam.transform.position.x + horizExtent - screenPadding;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;
    }
}
