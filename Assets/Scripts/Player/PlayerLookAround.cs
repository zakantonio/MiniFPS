using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{

    float rotationAxisX;
    float rotationAxisY;
    float sensitivity = 1f;

    Camera mainCamera;

    void Awake()
    {
        mainCamera = gameObject.GetComponentInChildren<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleLookAround(Vector2 input)
    {
        // conversione degli input
        float mouseX = input.x;
        float mouseY = input.y;

        // rotazione per frame
        rotationAxisX += mouseY * sensitivity * Time.deltaTime;
        rotationAxisY = mouseX * sensitivity * Time.deltaTime;

        // limitazione della visualte dall'alto in basso
        rotationAxisX = Mathf.Clamp(rotationAxisX, -30, 30);

        mainCamera.transform.localRotation = Quaternion.Euler(rotationAxisX, 0f, 0f);

        transform.Rotate(Vector3.up, rotationAxisY);
    }
}
