using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    public GameObject platformCollider;
    public float heightDifference;
    public bool collide, reset;
    Rigidbody rbd;
    Quaternion initialRotation;
    public float angleTolerance;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(platformCollider, new Vector3(transform.position.x, transform.position.y - heightDifference, 
            transform.position.z), Quaternion.identity);
        rbd = gameObject.GetComponent<Rigidbody>();
        initialRotation = rbd.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (!collide && reset)
        {
            float angle = Quaternion.Angle(initialRotation, rbd.transform.rotation);
            Debug.Log(angle);
            if (angle < 360-angleTolerance && angle > angleTolerance)
            {
                rbd.transform.rotation = Quaternion.Lerp(rbd.transform.rotation, initialRotation, Time.fixedDeltaTime * 5);
            }
            else
            {
                reset = false;
                rbd.angularVelocity = Vector3.zero;
                rbd.transform.rotation = initialRotation;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collide = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collide = false;
            reset = true;
        }
    }
}
