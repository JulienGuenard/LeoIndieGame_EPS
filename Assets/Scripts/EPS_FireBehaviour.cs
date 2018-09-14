using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPS_FireBehaviour : MonoBehaviour {

    SpriteRenderer spriteR;
    public float fireLenght;

    void Awake ()
    {
        spriteR = GetComponent<SpriteRenderer>();
       StartCoroutine(VanishOverTime());
	}
	
	IEnumerator VanishOverTime()
    {
        for (float i = 1; i > 0; i -= 1/fireLenght)
        {
            spriteR.color = new Color(i+0.5f, 1-i, spriteR.color.b, i);
            yield return new WaitForEndOfFrame();
        }
        DestroyImmediate(this.gameObject);
    }
}
