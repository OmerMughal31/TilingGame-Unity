using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 100;
    public Vector3 rotator;
    public Material hitMaterial;

    private Material _originalMaterial;
    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        // to get the variations in the rotaions to enhace the animation effects
        transform.Rotate(rotator * (transform.position.x + transform.position.y)*0.1f);
        // to use the hit material- mesh and renderer has been configured
        _renderer = GetComponent<Renderer>();
        _originalMaterial = _renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        // to rotate the bricks to create an animation effect
        transform.Rotate(rotator * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        // Score points
        if (hits <= 0)
        {
            GameManager.Instance.Score += points;
            Destroy(gameObject);
        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("restoreOriginalMaterial", 0.05f);
    }

    // Method to restore the original material after hitting
    void restoreOriginalMaterial()
    {
        _renderer.sharedMaterial = _originalMaterial;
    }
}
