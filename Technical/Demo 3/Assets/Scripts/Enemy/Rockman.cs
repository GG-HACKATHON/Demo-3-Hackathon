using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockman : EnemyBody {

    public override void Init()
    {
        base.Init();
    }
    public override void OnAttack()
    {
        base.OnAttack();
    }

    public override void UpdateHp(float d)
    {
        base.UpdateHp(d);
    }

    [ContextMenu("on Hit")]
    public override void OnHit()
    {
        base.OnHit();
    }
}
