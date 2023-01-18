using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EIManager eimanager;
    public AdManager admanager;

    public void Start()
    {
        CoinCalculator(100000);
        Debug.Log(PlayerPrefs.GetInt("moneyy"));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))    
        {
            Debug.Log("Oyun bitti");
            admanager.RequestInterstitial();
            admanager.RequestRewardedAd();
            CoinCalculator(100);
            eimanager.CoinTextUpdate();
            eimanager.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex") + 1);
        }
    }

    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("money"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
        }
        else
            PlayerPrefs.SetInt("money", 100000);
    }
}
