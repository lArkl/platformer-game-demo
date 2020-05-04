using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    Transform tran;

    // Start is called before the first frame update
    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        tran.Rotate(0,0, Time.deltaTime * 200);
    }

}
