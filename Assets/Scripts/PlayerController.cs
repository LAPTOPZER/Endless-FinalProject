using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSfx;
    public AudioClip crashSfx;

    private Rigidbody rb;
    private InputAction jumpAction;
    private bool isOnGround = true;

    private Animator playerAnim;
    private AudioSource playerAudio;

    public bool gameOver = false;

    private int jumpCount = 0;
    private int maxJumps = 2;

    private InputAction sprintAction;
    public static bool isSprinting = false;

    [SerializeField] private int maxHP = 3;
    private int currentHP;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb.AddForce(1000 * Vector3.up);
        Physics.gravity *= gravityModifier;

        jumpAction = InputSystem.actions.FindAction("Jump");
        sprintAction = InputSystem.actions.FindAction("Sprint");

        gameOver = false;
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //if (jumpAction.triggered && isOnGround && !gameOver)
        if (jumpAction.triggered && jumpCount < maxJumps && !gameOver)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            //isOnGround = false;
            jumpCount++;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSfx);
        }

        isSprinting = sprintAction.IsPressed();
        //Debug.Log(isSprinting);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isOnGround = true;
            jumpCount = 0;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1);
            explosionParticle.Play(); 
            Destroy(collision.gameObject);

            //Debug.Log("Game Over!");
            //gameOver = true;
            //playerAnim.SetBool("Death_b", true);
            //playerAnim.SetInteger("DeathType_int", 1);
            //explosionParticle.Play();
            //dirtParticle.Stop();
            //playerAudio.PlayOneShot(crashSfx);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("Game Over!");
        gameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        explosionParticle.Play();
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSfx);
    }
}