using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    Vector3 offset, o;
    Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        o = player.transform.forward;
        rot = player.transform.rotation;
        offset = transform.position - player.transform.position;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = offset + player.transform.position;
    }
}
