using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Horizontal;
    [Range(0, 10)]
    [SerializeField] float Speed;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject Bullet;
    float NextAttackTime;
    [SerializeField] float AttackRate;
    [SerializeField] float Second;

    public bool DidFlip = true;

    
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");

        if(Horizontal != 0)
        {
             transform.position += new Vector3(Horizontal * Speed, 0, 0) * Time.deltaTime;
        }


        if (Input.GetMouseButton(0))
        {
            if (Time.time >= NextAttackTime)
            {
                Instantiate(Bullet, FirePoint.position, FirePoint.rotation);

                NextAttackTime = Time.time + Second / AttackRate;
            }
        }
  
        if(Horizontal > 0 && !DidFlip)
        {
            Turn();
        }
        if(Horizontal < 0 && DidFlip)
        {
            Turn();      
        }
    }

    void Turn()
    {
        transform.Rotate(0f, 180f, 0f);
        DidFlip = !DidFlip;
    }
}