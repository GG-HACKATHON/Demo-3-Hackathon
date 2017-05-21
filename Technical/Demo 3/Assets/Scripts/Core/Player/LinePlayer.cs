using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cac control se ke thua thang nay
public class LinePlayer : MonoBehaviour {

    public BaseBody head;
    public List<BaseBody> bodys;
    
    public virtual void Init()
    { }
    public virtual void Move()
    { }
    public virtual void OnTurnLeft() 
    { }
    public virtual void OnTurnRught()
    { }
    public virtual void OnTurnTop()
    { }
    public virtual void OnTurnDown()
    { }
    //tao cac ham theo 1 list co san
    //dung de khoi tao cac enemy ban dau
    public virtual void CreatePlayer(List<int> bodys)
    { }
    public virtual void AddBody(BaseBody body)
    { }
    public virtual void RemoveBody(BaseBody body)
    { }
    public virtual void OnDie()
    { }
}
