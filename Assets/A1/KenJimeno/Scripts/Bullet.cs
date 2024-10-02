using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [HideInInspector] public int xDirection = 1;

    [SerializeField] private UnityEvent ghostHitEvent = new UnityEvent();

    private void Update() {
        Vector3 xIncrement = new Vector3(xDirection * bulletSpeed * Time.deltaTime, 0, 0);

        transform.Translate(xIncrement);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ghost") {
            SpriteAnimation ghostAnimation = other.gameObject.GetComponent<SpriteAnimation>();
            ghostAnimation.ghostHitEvent.Invoke();
            
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("CamHandler")) {
            Destroy(gameObject);
        }
    }
}
