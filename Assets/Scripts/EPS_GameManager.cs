using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPS_GameManager : MonoBehaviour {

    public static EPS_GameManager Instance;
    public GameObject enemy;
    Text countdownText;
    Image countdownBlackScreen;
    Image winScreen;
    Text winScreenText;
    Image loseScreen;
    Text loseScreenText;
    EPS_PlayerController playerController;

    public int countdownNumbers;
    public float countdownDelayBeforeStartCountdown;
    public float countdownDelayBetweenNumber;
    public float countdownDelayAfterCountdown;

    void Awake ()
    {
        Instance = this;
        countdownText = GameObject.Find("CountdownScreen/Text").GetComponent<Text>();
        countdownBlackScreen = GameObject.Find("CountdownScreen").GetComponent<Image>();
        winScreen = GameObject.Find("WinScreen").GetComponent<Image>();
        winScreenText = GameObject.Find("WinScreen/Text").GetComponent<Text>();
        loseScreen = GameObject.Find("LoseScreen").GetComponent<Image>();
        loseScreenText = GameObject.Find("LoseScreen/Text").GetComponent<Text>();
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

        yield return new WaitForSeconds(countdownDelayBeforeStartCountdown);

        for (int i = countdownNumbers; i > -1; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(countdownDelayBetweenNumber);
        }
        countdownText.text = "Go!";

        yield return new WaitForSeconds(countdownDelayAfterCountdown);

        countdownText.GetComponentInParent<Image>().gameObject.SetActive(false);
        playerController.enabled = true;
        GameObject newShooter = (GameObject)Instantiate(enemy, new Vector3(-0.1f, -2, 0), Quaternion.Euler(0, 0, 270));
    }

    public void Win()
    {
        winScreen.enabled = true;
        winScreenText.enabled = true;
        EndGame();
    }

    public void Lose()
    {
        loseScreen.enabled = true;
        loseScreenText.enabled = true;
        EndGame();
    }

    void EndGame()
    {
        Destroy(playerController.gameObject);
        foreach (EPS_EnemyBehaviour obj in GameObject.FindObjectsOfType<EPS_EnemyBehaviour>())
        {
            Destroy(obj.gameObject);
        }

        foreach (EPS_BallBehaviour obj in GameObject.FindObjectsOfType<EPS_BallBehaviour>())
        {
            Destroy(obj.gameObject);
        }
    }
}
