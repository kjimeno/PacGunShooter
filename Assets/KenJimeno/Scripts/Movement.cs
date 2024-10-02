
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Movement : MonoBehaviour
{
    [Header("Properties:")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;

    //Cached components
    [SerializeField] private GameOver gameOver;
    [SerializeField] private AudioSource deathSource;
    private AudioSource jumpSource;
    private Rigidbody2D rigBody;

    //Private variables
    private bool isGrounded = true;

    private void Start() {
        jumpSource = GetComponent<AudioSource>();
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        transform.Translate(input * movementSpeed * Time.deltaTime);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.X) && isGrounded) {
            jumpSource.Play();
            rigBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" && rigBody.velocity.y <= 0) {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Ghost") || other.gameObject.CompareTag("GhostBullet")) {
            deathSource.Play();
            gameOver.enabled = true;
            gameOver.GameIsOver();
        }
    }
}
