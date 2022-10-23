using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerController player;

    public DropBomb explosivesList;

    public TMP_Text landmineUpgradeText;

    public TMP_Text grenadeUpgradeText;

    public TMP_Text timerText;

    private float landmineCount = 0;

    private float grenadeCount = 0;

    private float listTotal = 0;

    private float timer;

    public TMP_Text coinText;

   

    private void Start()
    {
        listTotal = explosivesList.explosiveUpgrade.Count;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;

        coinText.text = "Coins: " + player.coins;
        
        if (listTotal != explosivesList.explosiveUpgrade.Count)
        {
            updateUpgrades();
        }

        landmineUpgradeText.text = "Upgraded landmines: " + landmineCount;

        grenadeUpgradeText.text = "Upgraded grenades: " + grenadeCount;

        timerText.text = timer.ToString("0");
    }

    public void updateUpgrades()
    {
        landmineCount = 0;
        grenadeCount = 0;

      foreach (GameObject explosive in explosivesList.explosiveUpgrade)
      {
        if (explosive == explosivesList.upgradedLandMine)
        {
            landmineCount += 1;
        }

        else if (explosive == explosivesList.upgradedGrenade)
        {
            grenadeCount += 1;
        }
      }
        listTotal = explosivesList.explosiveUpgrade.Count;

        
    }
  
}
