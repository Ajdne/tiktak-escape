using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI candiesLeftText;
    [SerializeField] GameObject tapToPlayCanvas;
    [SerializeField] GameObject endOfLevelCanvas;
    [SerializeField] GameObject timerCanvas;
    [SerializeField] GameObject looseCanvas;
    [SerializeField] TextMeshProUGUI timeLeft;
    [SerializeField] GameObject confettiObj;
    // [SerializeField] float setTime;
    [SerializeField] float currentTimeLeft;

    private void Awake()
    {
        Instance = this;

        tapToPlayCanvas.SetActive(true);
        endOfLevelCanvas.SetActive(false);
        timerCanvas.SetActive(false);
        looseCanvas.SetActive(false);

        // prevent confetti from popping
        confettiObj.SetActive(false);

        // prevent the time from flying by
        Time.timeScale = 0;         
    }

    void Start()
    {
        GameManager.Instance.numberOfCandies = GameManager.Instance.numberOfBasicCandies
                                            + GameManager.Instance.numberOfBouncyCandies
                                            + GameManager.Instance.numberOfStickyCandies;

        candiesLeftText.text = "Candies left: " + GameManager.Instance.numberOfCandies.ToString();
        
        StartCoroutine(StartCountdown());
    }

    public void UpdateUI()
    {
        candiesLeftText.text = "Candies left: " + GameManager.Instance.numberOfCandies.ToString();
    }

    public void UpdateTimeLeft()
    {
        timeLeft.text = currentTimeLeft.ToString();
    }

    public void TapToPlay()
    {
        // deactivate tap-to-play canvas
        tapToPlayCanvas.SetActive(false);
    
        // start the passing of time
        Time.timeScale = 1;

        timerCanvas.SetActive(true);
    }

    public void ActivateEndOfLevelCanvas()
    {
        // activate confetti
        timerCanvas.SetActive(false);

        confettiObj.SetActive(true);

        endOfLevelCanvas.SetActive(true);

        StopAllCoroutines();
    }

    public void Continue()
    {
        GameManager.Instance.ChangeLevel();
    }

    public void ActivateLooseCanvas()
    {
        looseCanvas.SetActive(true);

        Time.timeScale = 0; 
    }

    public IEnumerator StartCountdown()
    {       
        while (currentTimeLeft >= 0)
        {
            UpdateTimeLeft();

            yield return new WaitForSeconds(1.0f);
            currentTimeLeft--;

            if (currentTimeLeft <= 0)
            {
                ActivateLooseCanvas();
            }
        }
    }
}
