using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPS_GoalBehaviour : MonoBehaviour {

	void Awake ()
    {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            EPS_ScoreManager.Instance.AddScore();
        }
    }
}
