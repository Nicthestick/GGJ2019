using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{

    [SyncVar (hook = "HealthChange")    ] private int health = 100;
    private bool knockback = false;

    public delegate void knockDelegate();
    public event knockDelegate EventKnock;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkCondition();

    }

    void checkCondition()
    {
        if(!knockback)
        {
            knockback = true;
        }

        if (knockback)
        {
            if(EventKnock!=null)
            {
                EventKnock();
            }
            knockback = false;
        }
    }

    public void DeductHealth(int dmg)
    {
        health -= dmg;
    }
    void HealthChange(int hlth)
    {
        health = hlth;
    }
}
