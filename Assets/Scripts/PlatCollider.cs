using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCollider : MonoBehaviour
{
    public GameObject platform;
    Transform tran;
    public float heightDifference;
    // Start is called before the first frame update
    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        tran.localPosition = new Vector3(platform.transform.position.x, platform.transform.position.y - heightDifference, platform.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
