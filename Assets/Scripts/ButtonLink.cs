using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLink : MonoBehaviour
{
    public string acecomUrl, githubUrl;

    public void VisitAcecom()
    {
        Application.OpenURL(acecomUrl);
    }

    public void VisitGithub()
    {
        Application.OpenURL(githubUrl);
    }


}
