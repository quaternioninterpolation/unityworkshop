// // --
// // Author: Josh van den Heever
// // Date: 16/07/2018 @ 6:50 p.m.
// // --
using UnityEngine;
using System.Collections;

public static class ExensionMethods
{
    public static Vector2 ToVector2(this Vector3 input)
    {
        return new Vector2(input.x, input.y);
    }

    public static Vector3 ToVector3(this Vector2 input)
    {
        return new Vector3(input.x, input.y, 0f);
    }
}
