using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CarController : MonoBehaviour
    {
        public float acceleration = 10f;
        public float steering = 2f;
        public float maxSpeed = 20f;
        public float friction = 0.98f;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float moveInput = Input.GetAxis("Vertical");
            float turnInput = Input.GetAxis("Horizontal");

            rb.velocity += (Vector2)transform.up * moveInput * acceleration * Time.fixedDeltaTime;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
            rb.velocity *= friction;

            transform.Rotate(0f, 0f, -turnInput * steering);
        }
    }
}
