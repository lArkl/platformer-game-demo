using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rbd;
    public int maxJumps;
    int jumpCount;

    public float planningHeight;

    public float jumpForce, movespeed, speedfactor;
    float initSpeedFactor;
    public int onGround;
    public bool jumpDown, jumpUp, planningPressed, planningEnabled;

    Vector3 movement, prevMovement;

    Vector3 initialGravity;

    Animator anim;
    AudioSource audioSource;

    public AudioClip jumpClip, planningClip;

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
        /*
        initialSize = rbd.transform.localScale;
        float planningSide = Mathf.Sqrt(1 / planningHeight);
        planningSize = new Vector3(planningSide, planningHeight, planningSide);
        */
        initialGravity = Physics.gravity;
        initSpeedFactor = speedfactor;
        anim = gameObject.GetComponent<Animator>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbd.velocity = movement;

        if (movement.x != 0 || movement.z != 0)
        {
            int spd = Mathf.CeilToInt(speedfactor / initSpeedFactor);
            anim.SetInteger("Speed", spd);
            //Vector3 rot = Quaternion.LookRotation(movement).eulerAngles;
            //rot.x = 0;
            //rot.z = 0;
            //rbd.transform.eulerAngles = rot;
            rbd.transform.forward = new Vector3(movement.x, 0, movement.z);
        }
        else anim.SetInteger("Speed", 0);

        if (jumpDown)
        {
            Jump();
            jumpDown = !jumpDown;
        }

        if (planningPressed && !planningEnabled)
        {
            if (rbd.velocity.y < 0)
            {
                //rbd.transform.localScale = planningSize;
                Physics.gravity = initialGravity * 0.15f;
                rbd.velocity /= 2;
                anim.SetBool("Planning", true);

                audioSource.PlayOneShot(planningClip);
                planningEnabled = true;

            }
        }
        if(!planningPressed && planningEnabled)
        {
            anim.SetBool("Planning", false);
            //rbd.transform.localScale = initialSize;
            Physics.gravity = initialGravity;
            planningEnabled = false;
        }

    }

    private void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement = new Vector3(movespeed * h * speedfactor, rbd.velocity.y, movespeed * v * speedfactor);


        jumpDown |= Input.GetKeyDown(KeyCode.Space);

        //Habilitamos el planeo
        if (Input.GetKeyDown(KeyCode.G))
        {
            planningPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.G) || onGround > 0)
        {
            planningPressed = false;
        }

        //Reinicio
        if (rbd.position.y < -20)
        {
            Physics.gravity = initialGravity;
            ScoreKeeper.OnDeath();
            SceneManager.LoadScene("FirstLevel");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            //anim.SetBool("Jumping", false);
            onGround++;
            anim.SetBool("Ground", true);
        }
        if (collision.collider.CompareTag("SlipPlatform"))
        {
            //anim.SetBool("Jumping", false);
            onGround++;
            speedfactor *= 2;
            anim.SetBool("Ground", true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            anim.SetBool("Ground", false);
            onGround--;
        }
        if (collision.collider.CompareTag("SlipPlatform"))
        {
            onGround--;
            speedfactor /= 2;
            anim.SetBool("Ground", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            ScoreKeeper.coins++;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Power"))
        {
            other.gameObject.SetActive(false);
            ScoreKeeper.extraJumps++;
            maxJumps++;
        }
    }

    private void Jump()
    {
        if (onGround > 0)
        {
            jumpCount = 0;
            maxJumps = ScoreKeeper.extraJumps + 1;
        }
        if (jumpCount < maxJumps)
        {
            anim.SetTrigger("Jump");
            audioSource.PlayOneShot(jumpClip);
            //anim.SetBool("Jumping", true);
            rbd.AddForce(new Vector3(0, 1, 0) * jumpForce);
            jumpCount++;
            if (jumpCount > 1)
            {
                ScoreKeeper.extraJumps--;
            }
        }

    }
}
