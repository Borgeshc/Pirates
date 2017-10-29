using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public float speed;

    Camera cam;
    GameObject camPivot;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        cam = transform.Find("CharacterCamera").GetComponent<Camera>();
        camPivot = transform.parent.gameObject;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate ()
    {
        camPivot.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")* speed * Time.deltaTime,0));
        cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * speed * Time.deltaTime, 0,0));
    }
}
