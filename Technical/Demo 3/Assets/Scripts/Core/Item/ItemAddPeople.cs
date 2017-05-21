using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddPeople : BaseItem
{

    protected override void GivePlayer()
    {
        PlayerController.Instance.mainPlayer.AddBody((ComradeType)Random.Range(0, 2),1);
    }

    protected override void OnEat()
    {
        // do nothing
    }
}
