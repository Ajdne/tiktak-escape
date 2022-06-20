using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI candiesLeftText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameManager.Instance.numberOfCandies = GameManager.Instance.numberOfBasicCandies + GameManager.Instance.numberOfBouncyCandies
                                            + GameManager.Instance.numberOfStickyCandies;

        candiesLeftText.text = "Candies left: " + GameManager.Instance.numberOfCandies.ToString();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        candiesLeftText.text = "Candies left: " + GameManager.Instance.numberOfCandies.ToString();
    }
}
