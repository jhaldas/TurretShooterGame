using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinHud : MonoBehaviour
{
    public PlayerController player;

    private TextMeshProUGUI coinDisplay;

    private int coinAmount = 0;

    private void Start()
    {
        coinDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinAmount = player.coins;
        coinDisplay.text = coinAmount.ToString();
    }
}
