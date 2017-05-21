using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : BaseEffect
{

    public float timeBlink;

    private float timeBlinkNext;

    private SpriteRenderer spriteTarget;

    protected override void Start()
    {
        base.Start();

        timeBlinkNext = timeLife - timeBlink;
        spriteTarget = target.GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        if(timer <= timeBlinkNext)
        {
            spriteTarget.enabled = !spriteTarget.enabled;
            timeBlinkNext -= timeBlink;
        }


        base.Update();
    }

    protected override void End()
    {
        spriteTarget.enabled = true;

        base.End();
    }

}
