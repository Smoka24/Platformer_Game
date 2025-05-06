using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed = 5f;    //Speed of movement
    public float distance = 5f;     //How far on the right and left from starting point will it move
    public Vector3 startingPosition;
    public bool changeDirection = true;     //Does it go left or right
    public bool centreCrossed = true;       //Did it cross the centre on it's way back
    public Vector3 actualPosition;
    public float detectCentre = 0.1f;       //How close to the centre centreCrossed will change

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        centreCrossed = true;
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = transform.position;
        if(Mathf.Abs(actualPosition.x - startingPosition.x) <= detectCentre) //I couldn't make actual position just == starting position, because it was hardly ever exactly the same due to this calculation being done once a frame
        {
            centreCrossed = true;
        }

        if (changeDirection == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (changeDirection == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);        
        }

        if (Vector3.Distance(startingPosition, actualPosition) >= distance && centreCrossed == true)
        {
            changeDirection = !changeDirection;
            centreCrossed = false;
        }

    }
}
