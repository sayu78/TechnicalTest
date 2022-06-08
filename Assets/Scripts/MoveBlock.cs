using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField]
    private Transform Cube;

    [SerializeField]
    private Transform LandingPlane;

    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private bool Jumped;
    [SerializeField]
    private float Speed;
    private float StartTime;
    
    private void Start()
    {
       
        StartPosition = Cube.position;
        EndPosition = LandingPlane.position;

    }

    private void Update()
    {
        if (Jumped)
        {
            gameObject.transform.position = Vector3.Slerp(StartPosition, EndPosition, StartTime / Speed);
            StartTime += Time.deltaTime;
        }
        else if (!Jumped)
        {
            gameObject.transform.position = Vector3.Slerp(EndPosition, StartPosition, StartTime / Speed);
            StartTime += Time.deltaTime;
        }
        if (Jumped && Input.GetKeyDown(KeyCode.Space) && StartTime > 2)
        {
            StartTime = 0;
            Jumped = false;
        }
        else if (!Jumped && Input.GetKeyDown(KeyCode.Space) && StartTime > 2)
        {
            StartTime = 0;
            Jumped = true;
        }
    }



    // Implement logic here to move cube in an arc
    //from each starting position to the center of
    //the plane when press space bar, or back if it
    //is already there.
}
