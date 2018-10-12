using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Sprite[] images;
    public Image liveImageDisplay;
    public Text scoreText;
    public Image mainMenu;
    public int score = 0;
    [SerializeField]
    Image titleScreen;
    [SerializeField]
    Text gameover;
    [SerializeField]
    Text yourScore;


    public void UpdateLives (int livesLeft) {
        liveImageDisplay.sprite = images[livesLeft];

    }

    public void UpdateScore () {

        score += 10;
        scoreText.text = "Score: " + score;

    }

    public void HideTitleScreen () {
        titleScreen.enabled = false;
    }

    public void ShowTitleScreen () {
        titleScreen.enabled = true;
    }

    public void ShowGameOverScreen () {
        Debug.Log ("Game over screen function runs.");
        titleScreen.enabled = false;
        yourScore.text = "Your Score: " + score;
        yourScore.enabled = true;
        gameover.enabled = true;
    }
}
