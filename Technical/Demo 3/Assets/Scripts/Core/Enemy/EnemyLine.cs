using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLine : LinePlayer {

    public float randomTime;
    private float elapsedTime = 0;

    public override void Init()
    {
        GameObject go = (GameObject)Instantiate(ComradeManager.Instance.GetObjectByType(leaderType), transform);
        head = go.GetComponent<BaseBody>();

        if (head)
        {
            head.leader = true;
            head.recorder = new List<PathRecorder>();
            recorder = head.recorder;
        }

        bodies.Add(go);


        Vector3 pos = head.transform.position;
        pos.y += Time.fixedDeltaTime * follower.Count * distance;  

        for (int i = 0; i <= follower.Count * distance; i++)
        {
            recorder.Add(new PathRecorder(pos, head.dir));
            pos.y -= Time.fixedDeltaTime;
        }

        for (int i = 0; i < follower.Count; i++)
        {
            AddBody(follower[i], bodies.Count);
        }
    }

    protected virtual void Update()
    {
        TurnRandom();
    }

    public virtual void TurnRandom() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= randomTime)
        {
            int random = Random.Range(0, 4);
            switch (random)
            {
                case 0: OnTurnLeft(); break;
                case 1: OnTurnRight(); break;
                case 2: OnTurnUp(); break;
                case 3: OnTurnUp(); break;
            }

            elapsedTime = 0f;
        }
    }
}
