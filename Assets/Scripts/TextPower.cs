using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPower : MonoBehaviour
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
        if (ScoreKeeper.extraJumps > 0)
            text.text = ScoreKeeper.extraJumps + " Extra Jump";
        else
            text.text = "";
    }
}
