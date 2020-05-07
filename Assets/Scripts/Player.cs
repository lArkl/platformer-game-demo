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
    public int onGround;
    
    Vector3 initialSize;
    Vector3 planningSize;
    Vector3 initialGravity;

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
        initialSize = rbd.transform.localScale;

        float planningSide = Mathf.Sqrt(1 / planningHeight);
        planningSize = new Vector3(planningSide, planningHeight, planningSide);

        initialGravity = Physics.gravity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rbd.velocity = new Vector3(movespeed * h * speedfactor, rbd.velocity.y, movespeed * v * speedfactor);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround > 0)
            {
                jumpCount = 0;
            }
            jumpCount++;
            if (jumpCount <= maxJumps)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
                if (jumpCount > 1)
                {
                    jumpCount--;
                    maxJumps--;
                    ScoreKeeper.extraJumps = maxJumps - 1;
                }
            }

        }

        //Habilitamos el planeo
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (rbd.velocity.y < 0) {
                rbd.transform.localScale = planningSize;
                Physics.gravity = initialGravity * 0.15f;
            }
        }
        if (Input.GetKeyUp(KeyCode.G) || onGround > 0)
        {
            rbd.transform.localScale = initialSize;
            Physics.gravity = initialGravity;
        }

        //Reinicio
        if(rbd.position.y < -20)
        {
            ScoreKeeper.OnDeath();
            SceneManager.LoadScene("SampleScene");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            onGround ++;
        }
        if (collision.collider.CompareTag("SlipPlatform")) { 
            onGround ++;
            speedfactor *= 2;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
            onGround --;
        if (collision.collider.CompareTag("SlipPlatform"))
        {
            onGround --;
            speedfactor /= 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            ScoreKeeper.coins++;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Power")) {
            other.gameObject.SetActive(false);
            maxJumps++;
            ScoreKeeper.extraJumps = maxJumps - 1;
        }
    }


}
