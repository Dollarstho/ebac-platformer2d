using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particle;
    public float timeToHide;
    public GameObject graphicItem;

    [Header ("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
       if (particle != null) particle.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        OnCollect();
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);

    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() 
    {
        if (particle != null) particle.Play();
        Debug.Log("Coletou!");

        if (audioSource != null && audioSource.clip != null)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        }
    }


}
