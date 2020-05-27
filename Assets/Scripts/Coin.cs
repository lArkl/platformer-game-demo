using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    Transform tran;
    float init;
    // Start is called before the first frame update
    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        init = tran.position.z/10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tran.Rotate(0,0, init + Time.fixedDeltaTime * 200);
    }

}
