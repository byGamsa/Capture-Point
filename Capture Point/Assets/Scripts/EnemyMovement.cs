using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RotateSpeed = 5f;
    public static bool Contesting = false;
    public float DistToGround = 2f;

    void RayCasting() 
    {
        Contesting = Physics.Raycast(transform.position, Vector3.down, DistToGround, 1 << LayerMask.NameToLayer("Objective"));
    }

    void Update()
    {
        RayCasting();
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * MoveSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * MoveSpeed);
        }

    }
}
