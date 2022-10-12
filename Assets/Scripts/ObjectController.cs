using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] int Health = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
