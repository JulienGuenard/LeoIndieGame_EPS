using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPS_PlayerController : MonoBehaviour {

    Rigidbody2D rigidbody;
    public float speed;

	void Awake ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Move();
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball" || col.tag == "Fire")
        {
            EPS_GameManager.Instance.Lose();
        }
    }

    void Move()
    {
        rigidbody.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"),0);
    }
}
