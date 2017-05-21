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

    private int number;
    public List<PathRecorder> recorder = null;

    public Animator anim;

    private delegate void Action();
    private Action Move;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Move = TurnDown;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Move = TurnUp;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move = TurnLeft;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move = TurnRight;
        }

        Move();
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
}
