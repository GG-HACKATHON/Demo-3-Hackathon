using System;
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
    public List<PathRecorder> recorder = new List<PathRecorder>();
    public int distance;

    public int count;

    private void Update()
    {
        Record();
        count = recorder.Count;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnTurnDown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnTurnUp();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnTurnLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnTurnRight();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (distance * (bodies.Count + 1) < recorder.Count)
                AddBody(bodies.Count + 1);
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
        Vector3 pos = new Vector3(100, 100);
        GameObject body = (GameObject)Instantiate(prefab, pos, Quaternion.identity, transform);
        BaseBody baseBody = body.GetComponent<BaseBody>();
        try {
            baseBody.line = this;
            baseBody.SetNumber(number, distance);
            baseBody.Turn(Direction.FOLLOW);
        }
        catch (Exception e)
        {
            Debug.Log("Error Create");
        }
        bodies.Add(body);
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
