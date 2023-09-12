using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineAnimation : MonoBehaviour
{
    [SerializeField]
    private float moveUnits;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float waitTime;

    private bool moved = false;

    //When the player collides with the boundary, it will make it move upwards
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(!moved)
            {
                StartCoroutine(MoveObject());
                moved = true;
            }
        }
    }
    
    private IEnumerator MoveObject()
    {
        yield return new WaitForSeconds(waitTime);
        float totalTime = 0;
        float originalY = transform.position.y;
        while(totalTime < moveTime)
        {
            float y = Mathf.Lerp(0, moveUnits, totalTime/moveTime);
            transform.position = new Vector3(transform.position.x, originalY+y, transform.position.z);
            totalTime = totalTime + Time.deltaTime;
            yield return null;
        }
    }
}
