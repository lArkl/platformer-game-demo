using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject messagePanel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            messagePanel.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        transform.forward = other.transform.position - transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
            messagePanel.SetActive(false);
        }

    }
}
