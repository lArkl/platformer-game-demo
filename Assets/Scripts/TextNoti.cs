using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNoti : MonoBehaviour
{
    public float timeLimit;
    float localTime;
    Text text;
    string[] hints;
    bool hintOn;
    // Start is called before the first frame update
    void Start()
    {
        localTime = 0;

        text = gameObject.GetComponent<Text>();
        text.text = "";

        hints = new string[]{ "Move with arrows or AWSD", 
        "Jump with spacebar", 
        "While falling, press G to slow downfall",
        "Obtain green boxes to get an extra jump",
        "Pink platforms can move depending on its inclination",
        "You can move faster on blue platforms"};

        hintOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        localTime += Time.deltaTime;
        if (localTime > timeLimit)
        {
            if (hintOn) {
                text.text = hints[Random.Range(0, hints.Length)];
            }
            else
            {
                text.text = "";
            }
            hintOn = !hintOn;
            localTime = 0;
        }
    }
}
