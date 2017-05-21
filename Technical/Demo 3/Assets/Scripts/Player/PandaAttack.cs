using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaAttack : BaseAttack {

	// Use this for initialization
	void Start () {
        Init(5);
	}
	
	// Update is called once per frame
	void Update () {
        DoAttack();
	}

    public override void Init(float timeAttackDelay)
    {
        base.Init(timeAttackDelay);
    }

    public override void DoAttack()
    {
        base.DoAttack();
    }
}
