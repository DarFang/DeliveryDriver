using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 20f,
                        _turnSpeed = 150f,
                        _slowSpeed = 15f,
                        _boostSpeed = 30f;
                        
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _speedUpClip, _slowDownClip;
    void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SpeedUp"){
            _moveSpeed = _boostSpeed;
            _audioSource.clip = _speedUpClip;
            _audioSource.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        _moveSpeed = _slowSpeed;
        _audioSource.clip = _slowDownClip;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal")*_turnSpeed*Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")*_moveSpeed*Time.deltaTime;
        transform.Rotate(0,0,-turnAmount);
        transform.Translate(0,moveAmount,0);
    }
}
