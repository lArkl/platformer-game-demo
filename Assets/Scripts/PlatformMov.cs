using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    public GameObject platformCollider, platRef;
    public float heightDifference, movespeed, returnspeed;
    public bool collide, reset, returning;
    Rigidbody rbd;
    Quaternion initialRotation;
    Vector3 initialPosition, returnVector;

    Transform refTran;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
        platRef = Instantiate(platformCollider, new Vector3(rbd.transform.position.x, rbd.transform.position.y - heightDifference,
            rbd.transform.position.z), Quaternion.identity);
        initialRotation = rbd.transform.rotation;
        initialPosition = rbd.transform.position;
        //Debug.Log(rbd.transform.eulerAngles);
        audioSource = gameObject.GetComponent<AudioSource>();
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
                returnVector = (initialPosition - rbd.transform.position).normalized;
            }

            if (refTran!=null && rbd.transform.position.y - refTran.position.y > 1)
            {
                returning = true;
                refTran = null;
                //posible bug con el movimiento del player :v!
            }

            if (returning)
            {
                rbd.transform.position += returnVector * returnspeed * Time.deltaTime;
                if((initialPosition - rbd.transform.position).sqrMagnitude < 0.25)
                    returning = false;
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

            audioSource.Play();
            //collision.transform.localScale = Vector3.one;
            collide = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            audioSource.Stop();
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
