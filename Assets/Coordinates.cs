using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coordinates
{
    private int x;
    private int y;

    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }



    public override int GetHashCode()
    {
        int tmp = 23;
        tmp = tmp * 31 + x;
        return tmp * 31 + y;
    }

    public override bool Equals(object obj)
    {
        Coordinates coords = (Coordinates)obj;
        return (this.x == coords.x && this.y == coords.y);
    }

}
