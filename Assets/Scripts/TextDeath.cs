using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDeath : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreKeeper.deaths > 0)
        {
            text.text = ScoreKeeper.deaths + " Deaths";
        }
    }
}
