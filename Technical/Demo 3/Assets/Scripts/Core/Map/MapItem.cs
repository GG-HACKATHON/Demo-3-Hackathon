using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MAPTYPE
{

}
public class MapItem : MonoBehaviour {

    public SpriteRenderer sprte;
    public int col;
    public int row;
    public MAPTYPE type;
    public void Parse(int col, int row, MAPTYPE type)
    {
        this.col = col;
        this.row = row;
        this.type = type;
        //tao cac position o day
    }
    public void OnCollision()
    { }
}
