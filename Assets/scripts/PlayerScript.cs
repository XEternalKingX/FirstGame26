using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D body;
    private Animator anim;

    void Start()
    {
        GameSettings.Load();
        speed = GameSettings.PlayerSpeed;

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Walking animation
        if (anim != null)
        {
            bool isWalking = Mathf.Abs(horizontalInput) > 0.01f;
            anim.SetBool("isWalking", isWalking);
        }

        // Flip player
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);

        if (Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
    }
}