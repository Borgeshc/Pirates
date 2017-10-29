using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    float horizontal;
    float vertical;

    GameObject cameraPivot;
    GameObject characterPivot;

    Vector3 movement;
    Rigidbody rb;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        cameraPivot = transform.Find("CameraPivot").gameObject;
        characterPivot = transform.Find("CharacterPivot").gameObject;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);

        movement = new Vector3(horizontal, 0, vertical);
        movement *= speed * Time.deltaTime;
        movement = cameraPivot.transform.TransformDirection(movement);
        movement.y = 0f;

        if(movement != Vector3.zero)
            characterPivot.transform.rotation = Quaternion.Lerp(characterPivot.transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);

        rb.velocity = movement;
    }
}
