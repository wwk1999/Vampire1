using System;
using UnityEngine;

public class TwoNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    public ParticleSystem ps;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;

    private void Update()
    {
        rg.velocity = MoveDirection * MoveSpeed;
    }

   
}
