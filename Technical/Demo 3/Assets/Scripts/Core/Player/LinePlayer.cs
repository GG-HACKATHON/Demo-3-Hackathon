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

    [HideInInspector]
    public BaseBody head;
    public ComradeType leaderType;
    [HideInInspector]
    public List<PathRecorder> recorder;
    public float speed;
    public float waitTime;
    public int distance;
    public float startDistance;
    public List<ComradeType> follower;
    [HideInInspector]
    public List<GameObject> bodies = new List<GameObject>();

    public float passedTime = 0f;

    // ------------------------------------------------------------------------------------------

    protected virtual void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        GameObject go = (GameObject)Instantiate(ComradeManager.Instance.GetObjectByType(leaderType), transform);
        head = go.GetComponent<BaseBody>();

        if (head) {
            head.leader = true;
            head.recorder = new List<PathRecorder>();
            recorder = head.recorder;
            head.speed = speed;
            head.linePlayer = this;
        }
      
        bodies.Add(go);

        Vector3 pos = head.transform.position;
        pos.y += startDistance * follower.Count * distance;

        for (int i = 0; i <= follower.Count * distance; i++)
        {
            recorder.Add(new PathRecorder(pos, head.dir));
            pos.y -= startDistance;
        }

        for (int i = 0; i < follower.Count; i++)
        {
            AddBody(follower[i], bodies.Count);
        }
    }

    protected virtual void Update()
    {
        passedTime += Time.deltaTime;
        if (passedTime >= waitTime)
        {
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
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (distance * (bodies.Count) < recorder.Count)
                AddBody(ComradeType.HIPPO, bodies.Count);
        }
    }

    public virtual void OnTurnLeft() 
    {
        if (head.Turn(Direction.LEFT))
        {
            passedTime = 0f;
        }
    }

    public virtual void OnTurnRight()
    {
        if (head.Turn(Direction.RIGHT))
        {
            passedTime = 0f;
        }
    }

    public virtual void OnTurnUp()
    {
        if (head.Turn(Direction.UP))
        {
            passedTime = 0f;
        }
    }

    public virtual void OnTurnDown()
    {
        if (head.Turn(Direction.DOWN))
        {
            passedTime = 0f;
        }
    }

    public virtual void CreatePlayer(List<int> bodys)
    { }

    public virtual void AddBody(ComradeType type, int number)
    {
        Vector3 pos = new Vector3(100, 100);
        GameObject body = (GameObject)Instantiate(ComradeManager.Instance.GetObjectByType(type), pos, Quaternion.identity, transform);
        BaseBody baseBody = body.GetComponent<BaseBody>();
        try {
            baseBody.recorder = bodies[0].GetComponent<BaseBody>().recorder;
            baseBody.SetNumber(number, distance);
            baseBody.speed = speed;
            baseBody.linePlayer = this;
            baseBody.Turn(Direction.FOLLOW);
        }
        catch (Exception e)
        {
            Debug.Log("Error Create");
        }
        bodies.Add(body);
    }

    public virtual void RemoveBody(int index)
    {
        for (int i = index; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }

        bodies.RemoveRange(index, bodies.Count - index);
    }

    public virtual void OnDie()
    { }

    public virtual void OnHitLine(int index)
    {
        RemoveBody(index);
    }

    public void Record()
    {
        if (head != null)
        {
            recorder.Add(new PathRecorder(head.transform.position, head.dir));
        }
    }
}
