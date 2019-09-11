using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    bool isMoving = false;
    bool isCatching = false;
    int catchState = 0;
    Vector3 zeroPoint = new Vector3(-4, 4, -4);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        KeyControl();
	}
    private void KeyControl()
    {
        if (isCatching)
        {
            CatchDoll();
            return;
        }
        if (Input.anyKey)
        {
            if(Input.GetKey(KeyCode.F))
            {
                isCatching = true;
                return;
            }
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime);
            }
        }
    }
    private void CatchDoll()
    {
        if (catchState == 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            if (transform.localPosition.y <= 0.6)
            {
                catchState = 1;
            }
        }
        else if (catchState == 1)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
            if (transform.localPosition.y >= 4)
            {
                catchState = 2;
            }
        }
        else if (catchState == 2)
        {
            transform.localPosition=Vector3.MoveTowards(transform.localPosition, zeroPoint, Time.deltaTime);
            if (transform.localPosition == zeroPoint)
            {
                catchState = 0;
                isCatching = false;
            }
        }
    }
}
