using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject hp;

    private BaseBody player;

    private float ratio;


	// Use this for initialization
	void Start () {
        player = transform.parent.parent.GetComponent<BaseBody>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void UpdateHp(float d)
    {
        player.hpCurrent -= d;
        float scale = player.hpCurrent / player.hp;
        if (player.hpCurrent <= 0)
        {

            //this.OnDead();
        }
        this.hp.transform.localScale = new Vector3(scale, 1, 1);

    }
}
