using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotator : MonoBehaviour
{
    public GameObject objectToRotate;
    public float rotationSpeed;
    private Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        rotationVector = new Vector3(0, rotationSpeed, 0);
        objectToRotate.transform.Rotate(rotationVector*Time.deltaTime);
    }
}
