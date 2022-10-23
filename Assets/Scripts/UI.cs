using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerController player;

    public DropBomb explosivesList;

    private float landmineCount = 0;

    private float grenadeCount = 0;

    private float listTotal = 0;

    public TMP_Text coinText;

    public TMP_Text landmineUpgradeText;

    public TMP_Text grenadeUpgradeText;

    private void Start()
    {
        listTotal = explosivesList.explosiveUpgrade.Count;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + player.coins;
        
        if (listTotal != explosivesList.explosiveUpgrade.Count)
        {
            updateUpgrades();
        }

        landmineUpgradeText.text = "Upgraded landmines: " + landmineCount;

        grenadeUpgradeText.text = "Upgraded grenades: " + landmineCount;

       
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
