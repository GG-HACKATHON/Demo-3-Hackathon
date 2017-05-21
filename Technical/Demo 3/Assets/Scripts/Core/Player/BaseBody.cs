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
    public float speed;
    public float range;
    public Direction dir;

    private Animator anim;

    public virtual void Init()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void TurnLeft()
    {
        this.dir = Direction.LEFT;
        transform.position += Vector3.left * speed * Time.deltaTime;
        anim.SetBool("isLeft", true);
        anim.SetBool("isRight", false);
        anim.SetBool("isUp", false);
        anim.SetBool("isDown", false);
    }

    public virtual void TurnRight()
    {
        this.dir = Direction.RIGHT;
        transform.position += Vector3.right * speed * Time.deltaTime;
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", true);
        anim.SetBool("isUp", false);
        anim.SetBool("isDown", false);
    }

    public virtual void TurnUp()
    {
        this.dir = Direction.UP;
        transform.position += Vector3.up * speed * Time.deltaTime;
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isUp", true);
        anim.SetBool("isDown", false);
    }

    public virtual void TurnDown()
    {
        this.dir = Direction.DOWN;
        transform.position += Vector3.down * speed * Time.deltaTime;
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isUp", false);
        anim.SetBool("isDown", true);
    }

    public virtual void OnHit(float damge)
    { }

    public virtual void OnDie()
    { }

    public virtual void OnAttack()
    { }
}
