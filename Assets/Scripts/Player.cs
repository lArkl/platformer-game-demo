using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rbd;
    int jumpCount;
    public int maxJumps;
    public float jumpForce, movespeed;
    public bool onGround;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                jumpCount = 0;
            }
            jumpCount++;
            if (jumpCount <= maxJumps)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);

            }

        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rbd.velocity = new Vector3(movespeed * h, rbd.velocity.y, movespeed * v); //* Time.fixedDeltaTime;

    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Platform"))
            onGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
            onGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            points += 1;
            other.gameObject.SetActive(false);
        }
    }

}
