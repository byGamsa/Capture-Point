using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCapture : MonoBehaviour
{
    public float CaptureAmmont = 0f;
    public float MaxCaptureAmmont = 1000;
    private float DecayCoolDown = 3f;
    public float DecayCoolDownMax = 3f;
    public int CaptureVar = 10;
    public float Limit = 0f;

    void Start()
    {
        DecayCoolDown = DecayCoolDownMax;
    }

    void Update()
    {
        if(CaptureAmmont >= 250f)
        {
            Limit = 250f;
        }
        if (CaptureAmmont >= 500f)
        {
            Limit = 500f;
        }
        if (CaptureAmmont >= 750f)
        {
            Limit = 750f;
        }
        if (CaptureAmmont > 1000)
        {
            CaptureAmmont = 1000;
        }

        if(PlayerMovement.OnPoint == true && CaptureAmmont < MaxCaptureAmmont )
        {
            if(EnemyMovement.Contesting == false)
            {
                CaptureAmmont = CaptureAmmont + Time.deltaTime * CaptureVar;
            }
            DecayCoolDown = DecayCoolDownMax;
        }
        if(PlayerMovement.OnPoint == false && CaptureAmmont > Limit )
        {
            if(DecayCoolDown <= 0)
            {
                CaptureAmmont = CaptureAmmont - Time.deltaTime * CaptureVar;
            }
            DecayCoolDown = DecayCoolDown - Time.deltaTime;
            
        }
        if(CaptureAmmont < Limit)
        {
            CaptureAmmont = Limit;
        }
    }
}
