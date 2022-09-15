using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    //Screens
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;


    public static bool isWin;
    [SerializeField] float timeValue;
    public TMP_Text timerText;
    public static bool timerOn = true;

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {

            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                loseScreen.SetActive(true);

            }
        }
        else
        {
            winScreen.SetActive(true);
        }

        DisplayTime(timeValue);


    }

    void DisplayTime(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

