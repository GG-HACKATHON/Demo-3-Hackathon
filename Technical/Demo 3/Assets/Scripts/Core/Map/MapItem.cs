using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MAPTYPE
{
    BORDER = -1,
    NONE = 0,
    WOOD = 1,
    BLOCK = 2,
    TREE = 3,
    B_TOP = 4,
    B_LEFT = 5,
    B_DOWN = 6,
    B_RIGHT = 7,
    B_TOP_LEFT = 8,
    B_TOP_RIGHT = 9,
    B_DOWN_LEFT = 10,
    B_DOWN_RIGHT = 11,
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
    {
        //Debug.LogError("Da va cham voi cac vat can");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //moi lam demo thoi
        //sau nay kiem tra int cua Type neu > 10 thi moi thuc hien
        if (this.type == MAPTYPE.BLOCK || this.type == MAPTYPE.TREE || this.type == MAPTYPE.WOOD || this.type == MAPTYPE.BORDER)
        {
            if (other.tag == "Player")
            {
                this.OnCollision();
            }
            if(other.tag == "Enemy")
            {
                EnemyLine enemy = other.transform.parent.gameObject.GetComponent<EnemyLine>();
                if(enemy != null)
                {
                    enemy.TurnRandom();
                }
            }
        }
    }
}
