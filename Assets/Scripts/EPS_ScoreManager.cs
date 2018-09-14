using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPS_ScoreManager : MonoBehaviour {

    public static EPS_ScoreManager Instance;

    Slider ballDodgeCounterSlider;
    Text ballDodgeCounterText;

    public int maxScoreToWin;

    void Awake ()
    {
        Instance = this;

        ballDodgeCounterSlider = GameObject.Find("BallDodgeCounter/Slider").GetComponent<Slider>();
        ballDodgeCounterText = GameObject.Find("BallDodgeCounter/Slider/Text").GetComponent<Text>();
    }

    void InitMaxScore()
    {
        ballDodgeCounterSlider.maxValue = maxScoreToWin;
    }
	
    void ChangeText()
    {
        ballDodgeCounterText.text = ballDodgeCounterSlider.value.ToString() + "/" + maxScoreToWin.ToString();
    }

	public void AddScore()
    {
        if (ballDodgeCounterSlider.value == maxScoreToWin)
            return;

            ballDodgeCounterSlider.value++;
        EPS_DifficultyManager.Instance.DifficultyGrow(ballDodgeCounterSlider.value);
        ChangeText();
        if (ballDodgeCounterSlider.value == maxScoreToWin)
            EPS_GameManager.Instance.Win();
    }
}
