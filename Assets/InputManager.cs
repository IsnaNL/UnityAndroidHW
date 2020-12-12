using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
 
 


    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    public Transform toDrag;
    public float Speed = 2f;


    void Update()
    {
        Vector3 CalcPos;

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
            {
                Debug.Log("Here");
                toDrag = hit.transform;
                dist = hit.transform.position.z - Camera.main.transform.position.z;
                CalcPos = new Vector3(pos.x, pos.y, dist);
                CalcPos = Camera.main.ScreenToWorldPoint(CalcPos);
                offset = toDrag.position - CalcPos;
                dragging = true;
            }
        }
        if (dragging && touch.phase == TouchPhase.Moved)
        {
            CalcPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            CalcPos = Camera.main.ScreenToWorldPoint(CalcPos);
            toDrag.position = CalcPos + offset;
        }
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
        }
    }
}

