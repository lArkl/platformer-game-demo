using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    Rigidbody rbd;
    Vector3 initialPosition, initialAngVel;
    Quaternion initialRotation;
    Vector3 angleRot;
    public bool collide;
    public bool rotating;
    public float maxAngle;

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
        initialPosition = rbd.transform.position;
        initialRotation = rbd.transform.rotation;
        initialAngVel = rbd.angularVelocity;
    }

    private void FixedUpdate()
    {
        //if (rotating)
        //{
        //    prevRotation = rbd.rotation;
        //    LimitRotation();
        //    if (!collide)
        //    {
        //        float ang = Quaternion.Angle(initialRotation, rbd.rotation);
        //        if ( ang < 1)
        //        {
        //            rbd.angularVelocity = Vector3.zero;
        //            rbd.transform.eulerAngles = Vector3.zero;
        //            rotating = false;
        //        }

        //    }

        //}

    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rotating = true;
            collide = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            angleRot = rbd.angularVelocity;
            rbd.angularVelocity = -angleRot;
            collide = false;
        }
    }

    private void LimitRotation()
    {
        float angle = Quaternion.Angle(rbd.rotation, initialRotation);
        if (angle > maxAngle || angle < -maxAngle)
        {
            Debug.Log(angle);
            //rbd.rotation = prevRotation;
            //rbd.angularVelocity = initialAngVel;
        }
    }
}
