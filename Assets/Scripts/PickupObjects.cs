using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    //Click and hold the mouse to move objects around
    private void OnMouseDown() 
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Store offset = gameobject world pose - mouse pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        //Pixel coordinates of mouse(x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinates of game object on screen
        mousePoint.z = mZCoord;

        //convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
