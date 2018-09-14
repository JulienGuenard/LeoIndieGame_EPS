using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPS_EnemyBehaviour : MonoBehaviour {

    Rigidbody2D rigidbody;
    public GameObject ball;
    public float ballApparitionDelay;
    public float ballShotDelay;

	void Awake ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(ballApparitionDelay);
        NewBall();
        yield return new WaitForSeconds(ballShotDelay);
        rigidbody.velocity = new Vector2(0, 2);
        yield return new WaitForSeconds(0.1f);
        rigidbody.velocity = new Vector2(0, -1);
        yield return new WaitForSeconds(0.2f);
        rigidbody.velocity = new Vector2(0, 0);
        StartCoroutine(Shot());

    }

    void NewBall()
    {
        GameObject obj = (GameObject)Instantiate(ball, transform.position + new Vector3(0, 0.25f,0), Quaternion.identity);
    }
}
