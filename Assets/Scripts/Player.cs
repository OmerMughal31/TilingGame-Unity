using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    //private Vector3 _mOffset;
    //private float _mZCoord;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x, -18, 0));
        //OnMouseDown();
        //OnMouseDrag();
        //_rigidbody.MovePosition(GetMouseWorldPos());
    }
    
    /*private void OnMouseDown()
    {
        _mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //_mXCoord = Camera.main.WorldToScreenPoint(_rigidbody.transform.position).x;
        // Store Offset = gameobjectPosWorld - mousePosWorld
        _mOffset = _rigidbody.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // pixel coordinate (x,y) 
        Vector3 mousePoint = Input.mousePosition;

        // x Coordinate of game object on screen
        mousePoint.x = _mZCoord;

        return Camera.main.ScreenToViewportPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _mOffset;

    }*/
}
