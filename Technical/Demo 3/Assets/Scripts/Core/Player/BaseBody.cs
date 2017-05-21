using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    FOLLOW = 0,
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

    private int number;
    public List<PathRecorder> recorder = null;

    protected Animator anim;

    private delegate void Action();
    private Action Move;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Move();
        SetAnimation(this.dir);
    }

    public virtual void Init()
    {
        Move = TurnDown;
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Break();
        }
    }

    public virtual void Turn(Direction direction)
    {
        switch (direction)
        {
            case Direction.LEFT:
                Move = TurnLeft;
                break;
            case Direction.RIGHT:
                Move = TurnRight;
                break;
            case Direction.UP:
                Move = TurnUp;
                break;
            case Direction.DOWN:
                Move = TurnDown;
                break;
            case Direction.FOLLOW:
                Move = Follow;
                break;
        }
    }

    public virtual void TurnLeft()
    {
        this.dir = Direction.LEFT;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public virtual void TurnRight()
    {
        this.dir = Direction.RIGHT;
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public virtual void TurnUp()
    {
        this.dir = Direction.UP;
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public virtual void TurnDown()
    {
        this.dir = Direction.DOWN;
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public virtual void Follow()
    {
        transform.position = recorder[number].position;
        dir = recorder[number].direction;
        number++;
    }

    public virtual void OnHit(float damge)
    { }

    public virtual void OnDie()
    { }

    public virtual void OnAttack()
    { }

    public virtual void SetNumber(int no, int space)
    {
        number = no * space;
    }

    public virtual void SetAnimation(Direction direction)
    {
        switch (direction)
        {
            case Direction.LEFT:
                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;

            case Direction.RIGHT:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;

            case Direction.UP:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", true);
                anim.SetBool("isDown", false);
                break;

            case Direction.DOWN:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", true);
                break;
        }
    }
}
