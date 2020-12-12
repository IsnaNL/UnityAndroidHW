using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphereUsingJoyStick : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform toDrag;
    public FixedJoystick joystick;
    private float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(joystick.input.normalized);
        toDrag.Translate(joystick.input.normalized.x * joystick.input.magnitude * Time.deltaTime * speed, 0f, joystick.input.normalized.y * joystick.input.magnitude * Time.deltaTime * speed);
    }
}
