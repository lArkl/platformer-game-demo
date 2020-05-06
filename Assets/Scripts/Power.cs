using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    Transform tran;
    Vector3 initialPosition;

    public float timeLimit, rate;
    float time;
    int changeDir;

    // Start is called before the first frame update
    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        initialPosition = tran.position;

        time = 0;
        changeDir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeLimit / 2)
        {
            time = -timeLimit / 2;
            changeDir *= -1;
        }
        tran.position = initialPosition + new Vector3(0, time * changeDir * rate, 0);
    }
}