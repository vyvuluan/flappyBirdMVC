using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : MonoBehaviour, IBird
{
    public Action getBullet;
    public void Initialized(Action getBullet)
    {
        this.getBullet = getBullet;
    }    
    public void skill()
    {
        Debug.Log("ban dan ");
        getBullet.Invoke();

    }

   
}
