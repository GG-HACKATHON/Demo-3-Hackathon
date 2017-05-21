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

    List<GameObject> bodies;
    List<PathRecorder> recorder = new List<PathRecorder>();

    private void Update()
    {
        Record();

        if (Input.GetKey(KeyCode.A))
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
        head.TurnLeft();
    }

    public virtual void OnTurnRight()
    {
        head.TurnRight();
    }

    public virtual void OnTurnUp()
    {
        head.TurnUp();
    }

    public virtual void OnTurnDown()
    {
        head.TurnDown();
    }

    public virtual void CreatePlayer(List<int> bodys)
    { }

    public virtual void AddBody(int number)
    {
        GameObject body = (GameObject)Instantiate(prefab, transform);
        body.GetComponent<BaseBody>().SetNumber(number, 50);
    }

    public virtual void RemoveBody(BaseBody body)
    {
 
    }

    public virtual void OnDie()
    { }

    public void Record()
    {
        recorder.Add(new PathRecorder(transform.position, head.dir));
    }
}
