using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaAttack : BaseAttack {

    

    private float offset;

    private SpriteRenderer renderer;

    // Use this for initialization
	protected virtual void Start () {
        base.Start();

        player = transform.parent.gameObject.GetComponent<BaseBody>();
        if (player == null || !player.leader)
        {
            gameObject.SetActive(false);
        }

        offset = 0.4f;
        renderer = GetComponent<SpriteRenderer>();
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        CountDownTime();
        UpdatePosition();
	}

    public override void CountDownTime()
    {
        base.CountDownTime();
    }

    public override void Init()
    {
        base.Init();
    }
    
    void UpdatePosition()
    {
        Debug.Log(player.dir);
        switch(player.dir)
        {
            case Direction.DOWN:
                renderer.sortingOrder = 1;
                transform.position = player.gameObject.transform.position + new Vector3(0, -offset, 0);
                break;
            case Direction.UP:
                renderer.sortingOrder = 0;
                transform.position = player.gameObject.transform.position + new Vector3(0, offset, 0);
                break;
            case Direction.LEFT:
                renderer.sortingOrder = 1;
                this.transform.position = player.gameObject.transform.position + new Vector3(-offset - 0.2f, 0, 0);
                break;
            case Direction.RIGHT:
                renderer.sortingOrder = 1;
                this.transform.position = player.gameObject.transform.position + new Vector3(offset + 0.2f, 0, 0);
                break;
        }
    }

}
