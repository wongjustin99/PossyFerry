using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class ShotFactory
{
    public static Shot basicShot(float x, float y, float speedX, float speedY)
    {
        return new Shot(x, y, speedX, speedY);        
    }
    // other types such as red, blue, etc. 
}
