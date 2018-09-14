using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPS_BallBehaviour : MonoBehaviour {

    Rigidbody2D rigidbody;
    public float speed;

	void Awake ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Move();
        }
    }



    IEnumerator TurnOnHimself()
    {
        yield return new WaitForEndOfFrame();
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + speed * 10);
        StartCoroutine(TurnOnHimself());
    }
	
	void Move ()
    {
        StartCoroutine(TurnOnHimself());
        rigidbody.velocity = new Vector2(Random.Range(-0.2f,0.2f)                                                       , speed);
    }
}
