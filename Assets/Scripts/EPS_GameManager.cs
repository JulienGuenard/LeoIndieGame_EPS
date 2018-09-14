using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPS_GameManager : MonoBehaviour {

    public static EPS_GameManager Instance;
    public GameObject enemy;
    Text countdownText;
    Image countdownBlackScreen;
    EPS_PlayerController playerController;

    void Awake ()
    {
        Instance = this;
        countdownText = GameObject.Find("CountdownScreen/Text").GetComponent<Text>();
        countdownBlackScreen = GameObject.Find("CountdownScreen").GetComponent<Image>();
        playerController = GameObject.Find("Player").GetComponent<EPS_PlayerController>();
        StartGame();
    }
	
public void StartGame()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdownText.enabled = true;
        countdownBlackScreen.enabled = true;
        playerController.enabled = false;

        yield return new WaitForSeconds(1f);

        for (int i = 5; i > -1; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(0.6f);
        }
        countdownText.text = "Go!";

        yield return new WaitForSeconds(0.6f);

        countdownText.GetComponentInParent<Image>().gameObject.SetActive(false);
        playerController.enabled = true;
        GameObject newShooter = (GameObject)Instantiate(enemy, new Vector3(-0.1f, -2, 0), Quaternion.Euler(0, 0, 270));
    }

    public void Win()
    {

    }

    public void Lose()
    {

    }
}
