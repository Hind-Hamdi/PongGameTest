using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB 
{
    static public bool IsOverLap(Vector3 aMin, Vector3 aMax, Vector3 bMin, Vector3 bMax)
    {
        if (aMax.x < bMin.x)
            return false; // A to the left of B
        if (bMax.x < aMin.x)
            return false; // A to the right of B
        if (aMax.y < bMin.y)
            return false; // A below B
        if (bMax.y < aMin.y)
            return false; // A above B
        return true; // A intersects B
    }


}
