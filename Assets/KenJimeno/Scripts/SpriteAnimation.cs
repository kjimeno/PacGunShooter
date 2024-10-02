using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] StartGame startGame;

    [Header("Properties:")]
    [SerializeField] private float animationSpeed;
    
    [Header("Universal Sprites:")]
    [SerializeField] private Sprite[] sprites;

    [Header("Pac-Man ONLY Sprites:")]
    [SerializeField] private Sprite shootSprite;

    //Variables
    private float timer = 0f;
    private int spriteIdx = 0;
    private SpriteRenderer charRenderer;

    public UnityEvent ghostHitEvent = new UnityEvent();

    private void Start() {
        //Cache the sprite renderer
        charRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChangeSprites();
        FlipSprite();
    }

    private void ChangeSprites()
    {
        timer += animationSpeed * Time.deltaTime;

        if (gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z) && startGame.gameStarted) {
            charRenderer.sprite = shootSprite;
            timer = 0f;
        } else if (timer >= 1f) {
            charRenderer.sprite = sprites[++spriteIdx % sprites.Length];
            timer = 0f;
        }
    }
    
    private void FlipSprite() {
        if (gameObject.tag == "Player" && startGame.gameStarted) {
            float xInput = Input.GetAxisRaw("Horizontal");

            if (xInput < 0)
                charRenderer.flipX = true;
            else if (xInput > 0)
                charRenderer.flipX = false;
        }
    }

    private void ResetTimer() {
        timer = 0f;
    }
}
