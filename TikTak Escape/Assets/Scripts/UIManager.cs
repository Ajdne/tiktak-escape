using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI movesLeftText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        movesLeftText.text = "MOVES left: " + GameManager.Instance.numberOfMoves.ToString();
    }

    // Update is called once per frame
    public void UpdateMovesUI()
    {
        movesLeftText.text = "MOVES left: " + GameManager.Instance.numberOfMoves.ToString();
    }
}
