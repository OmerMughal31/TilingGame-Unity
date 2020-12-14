using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Defining the desired variables

    // Variable for speed
    private float _speed = 20f;
    // Rigid body for ball
    private Rigidbody _rigidbody;
    // To handle the vilocity define Vector3
    private Vector3 _velocity;

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        // Defining the rigidbody that we have assigned to our ball in unity engine
        _rigidbody = GetComponent<Rigidbody>();

        _renderer = GetComponent<Renderer>();

        // Assigning the spped to ball (rigidbody) so that it falls
        _rigidbody.velocity = Vector3.down * _speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;

        if (!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    // Add a method to tell the game pipeline what to do when the ball collides with paddle
    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}
