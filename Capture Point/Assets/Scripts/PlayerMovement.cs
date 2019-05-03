using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RotateSpeed = 5f;
    public static bool OnPoint = false;
    public static bool AttackingTeam;
    public bool LocalAttackTeam;
    public float DistToGround = 2f;
    public bool LocalOnPoint = false;

    public void RayCasting()
    {
        OnPoint = Physics.Raycast(transform.position, Vector3.down, DistToGround, 1 << LayerMask.NameToLayer("Objective"));
  
    }

    void Start()
    {
        AttackingTeam = LocalAttackTeam;
    }

    
    void Update()
    {
        LocalOnPoint = OnPoint;
        RayCasting();

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * MoveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * MoveSpeed);
        }

        transform.Rotate(0, RotateSpeed * Input.GetAxis("Horizontal"), 0);

    }
}
