using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ke thua tat ca cac ham cua BaseBody
public class EnemyBody : BaseBody {
    
    public override void Init()
    {
        base.Init();
    }

    //override cac ham o day

    //xu ly va cham voi player
    //goi den ham finish cua game
    public virtual void OnCollision()
    { }


}
