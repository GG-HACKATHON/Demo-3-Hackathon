using UnityEngine;

public class Detection : MonoBehaviour {

    public BasePlayerWeapon projectile;

    private BaseBody player;

	// Use this for initialization
	void Start () {
        player = transform.parent.GetComponent<BaseBody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            BasePlayerWeapon proj = Instantiate(projectile.gameObject,
                player.gameObject.transform.position,
                Quaternion.identity).GetComponent<BasePlayerWeapon>();

            proj.SetTargetPosition(target.transform.position);
        }
    }
}
