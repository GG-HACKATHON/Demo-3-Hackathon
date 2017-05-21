using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : BasePlayerWeapon {

	void Start () {
        Init(PlayerWeaponType.Dart);
	}

    void Update()
    {
        FlyToPosition();
    }

    public override void Init(PlayerWeaponType type)
    {
        base.Init(type);
    }

    public override void SetTargetPosition(Vector3 pos)
    {
        base.SetTargetPosition(pos);
    }

    public override void FlyToPosition()
    {
        base.FlyToPosition();
    }
}
