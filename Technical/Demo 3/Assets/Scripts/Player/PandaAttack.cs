using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaAttack : BaseAttack {

    private BaseBody player;

    private float offset;

    // Use this for initialization
	void Start () {
        offset = 0.4f;
        player = transform.parent.GetComponent<BaseBody>();
        Init(5);
	}
	
	// Update is called once per frame
	void Update () {
        DoAttack();
        UpdatePosition();
	}

    public override void Init(float timeAttackDelay)
    {
        base.Init(timeAttackDelay);
    }

    public override void DoAttack()
    {
        base.DoAttack();
    }

    void UpdatePosition()
    {
        switch(player.dir)
        {
            case Direction.DOWN:
                transform.position = player.gameObject.transform.position + new Vector3(0, -offset, 0);
                break;
            case Direction.UP:
                transform.position = player.gameObject.transform.position + new Vector3(0, offset, 0);
                break;
            case Direction.LEFT:
                this.transform.position = player.gameObject.transform.position + new Vector3(-offset, 0, 0);
                break;
            case Direction.RIGHT:
                this.transform.position = player.gameObject.transform.position + new Vector3(offset, 0, 0);
                break;
        }
    }
}
