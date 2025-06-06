using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rigidBody {get; private set;}
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(inputUp)){
            SetDirection(Vector2.up, spriteRendererUp);
        }else if(Input.GetKey(inputDown)){
            SetDirection(Vector2.down, spriteRendererDown);
        }else if(Input.GetKey(inputLeft)){
            SetDirection(Vector2.left, spriteRendererLeft);
        }else if(Input.GetKey(inputRight)){
            SetDirection(Vector2.right, spriteRendererRight);
        }else{
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = rigidBody.position;    
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        rigidBody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer){
        direction = newDirection;
        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Explosion")) {
            // Debug.Log("Bumf");
            DeathSequence();
        }
    }

    private void DeathSequence(){
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded(){
        gameObject.SetActive(false);
        FindFirstObjectByType<GameManager>().CheckWinState();
    }
}
