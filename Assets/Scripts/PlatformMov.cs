using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    public GameObject platformCollider, platRef;
    public float heightDifference, movespeed;
    public bool collide, reset;
    Rigidbody rbd;
    Quaternion initialRotation;
    Vector3 prevPosition;

    Transform refTran;
    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
        platRef = Instantiate(platformCollider, new Vector3(rbd.transform.position.x, rbd.transform.position.y - heightDifference,
            rbd.transform.position.z), Quaternion.identity);
        initialRotation = rbd.transform.rotation;
        prevPosition = rbd.transform.position;
        //Debug.Log(rbd.transform.eulerAngles);

        refTran = null;
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!collide)
        {
            if (reset)
            {
                reset = false;
                rbd.angularVelocity = Vector3.zero;
                rbd.transform.rotation = initialRotation;
                rbd.velocity = Vector3.zero;
                prevPosition = rbd.transform.position;

            }

        }
        else
        {
            platRef.transform.position = new Vector3(rbd.transform.position.x, rbd.transform.position.y - heightDifference,
            rbd.transform.position.z);
            UpdateMovement(Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            refTran = collision.transform;
            collision.transform.localScale = Vector3.one;
            collide = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            refTran = null;
            collide = false;
            reset = true;
        }
    }

    private void UpdateMovement(float delta)
    {
        float x = transform.rotation.eulerAngles.x,
            z = transform.rotation.eulerAngles.z;
        float dx = x > 180 ? x - 360 : x;
        float dz = z > 180 ? 360 - z : - z;

        Vector3 move = new Vector3(dz, 0, dx) * delta * movespeed / 10;

        transform.position += move;

        if (refTran != null)
        {
            refTran.position = refTran.position + move;
        }
    }
}
