using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRecorder
{
    public Vector3 position;
    public Direction direction;

    public PathRecorder(Vector3 position, Direction direction)
    {
        this.position = position;
        this.direction = direction;
    }
}

public class LinePlayer : MonoBehaviour {

    public BaseBody head;
    public GameObject prefab;

    List<GameObject> bodies = new List<GameObject>();
    List<PathRecorder> recorder = new List<PathRecorder>();

    private void Update()
    {
        Record();

        if (Input.GetKey(KeyCode.DownArrow))
        {
            OnTurnDown();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            OnTurnUp();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnTurnLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            OnTurnRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AddBody(bodies.Count);
        }

    }

    public virtual void Init()
    { }

    public virtual void Move()
    { }

    public virtual void OnTurnLeft() 
    {
        head.Turn(Direction.LEFT);
    }

    public virtual void OnTurnRight()
    {
        head.Turn(Direction.RIGHT);
    }

    public virtual void OnTurnUp()
    {
        head.Turn(Direction.UP);
    }

    public virtual void OnTurnDown()
    {
        head.Turn(Direction.DOWN);
    }

    public virtual void CreatePlayer(List<int> bodys)
    { }

    public virtual void AddBody(int number)
    {
        GameObject body = (GameObject)Instantiate(prefab, transform);
        BaseBody baseBody = body.GetComponent<BaseBody>();
        baseBody.recorder = this.recorder;
        baseBody.SetNumber(number, 25);
        baseBody.Turn(Direction.FOLLOW);
    }

    public virtual void RemoveBody(BaseBody body)
    {
 
    }

    public virtual void OnDie()
    { }

    public void Record()
    {
        recorder.Add(new PathRecorder(head.transform.position, head.dir));
    }
}
