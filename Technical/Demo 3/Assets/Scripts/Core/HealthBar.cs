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
        ratio = (float) player.hp / (float) player.health;
        Vector3 scaleRatio = new Vector3(ratio, 1.0f, 1.0f);
        hp.transform.localScale = scaleRatio;

        Debug.Log(player.hp + "   " +(float) player.health);
	}
}
