using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    UP = 1,
    DOWN = 2,
    LEFT = 3,
    RIGHT = 4
}
//cac item cua player se ke thua lop nay
public class BaseBody : MonoBehaviour {
    public float hp;
    public float range;
    public Direction dir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Init()
    { }
    public virtual void Move()
    { }
    public virtual void Turn(DIRECTION dir)
    {
        this.dir = dir;
    }
    public virtual void TurnLeft()
    { }
    public virtual void TurnRight()
    { }
    public virtual void TurnTop()
    { }
    public virtual void TurnDown()
    { }
    public virtual void OnHit(float damge)
    { }
    public virtual void OnDie()
    { }
    public virtual void OnAttack()
    { }
}
