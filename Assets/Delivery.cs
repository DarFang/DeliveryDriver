using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackagetColor = new Color32(1,1,1,1),
        noPackagetColor = new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _deliveryClip, _packageClip;
    //9CC88F
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("ouch");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage){
            Debug.Log("package pickup");
            hasPackage = true;
            spriteRenderer.color = hasPackagetColor;
             _audioSource.clip = _packageClip;
            _audioSource.Play();
            Destroy(other.gameObject, destroyDelay);
        }
        if(other.tag == "Customer" && hasPackage){
            Debug.Log("package delivery");
            spriteRenderer.color = noPackagetColor;
             _audioSource.clip = _deliveryClip;
            _audioSource.Play();
            hasPackage = false;
        }
    }
}
