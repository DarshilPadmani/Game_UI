using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TurrentState 
{
    protected Turrent parent;

    public virtual void Enter(Turrent parent)
    {
        this.parent = parent;
    }

    public virtual void Update()
    {

    }
    public virtual void Exit() 
    { 
        
    }

    private Transform target;

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {

    }
}
