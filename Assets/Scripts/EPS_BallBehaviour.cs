using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPS_BallBehaviour : MonoBehaviour {

    Rigidbody2D rigidbody;

    public float fireLenght;

    public float biggerScale;

    public GameObject fire;

	void Awake ()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        if (Random.Range(1,101) < EPS_DifficultyManager.Instance.biggerChance)
            Bigger();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Move();
            if (Random.Range(1, 101) < EPS_DifficultyManager.Instance.fireChance)
                StartCoroutine(Burn());
        }
    }

    IEnumerator TurnOnHimself()
    {
        yield return new WaitForEndOfFrame();
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rigidbody.velocity.y * 10);
        StartCoroutine(TurnOnHimself());
    }
	
	void Move ()
    {
        StartCoroutine(TurnOnHimself());
        rigidbody.velocity = new Vector2(Random.Range(-0.2f,0.2f), EPS_DifficultyManager.Instance.ballSpeed);
    }

    IEnumerator Burn()
    {
        yield return new WaitForEndOfFrame();
        GameObject obj = (GameObject)Instantiate(fire, transform.position, Quaternion.identity);
        obj.GetComponent<EPS_FireBehaviour>().fireLenght = fireLenght;
        obj.transform.localScale = transform.localScale;
        StartCoroutine(Burn());
    }

    void Bigger()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + biggerScale/2, transform.position.z);
        transform.localScale = new Vector3(biggerScale, biggerScale, biggerScale);
    }
}
