using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction
{
    public static Direction UP = new Direction(1);
    public static Direction DOWN = new Direction(2);
    public static Direction LEFT = new Direction(3);
    public static Direction RIGHT = new Direction(4);
    private int v;
    private int baseDistance = 1;

    public Direction(int v)
    {
        this.v = v;
    }

    public Vector2 ConvertToVector2(Vector2 initialPosition)
    {
        switch (v)
        {
            case 1:
                return new Vector2(initialPosition.x, initialPosition.y + baseDistance);
            case 2:
                return new Vector2(initialPosition.x, initialPosition.y - baseDistance);
            case 3:
                return new Vector2(initialPosition.x - baseDistance, initialPosition.y);
            case 4:
                return new Vector2(initialPosition.x + baseDistance, initialPosition.y);


        }

        return initialPosition;
    }
}


