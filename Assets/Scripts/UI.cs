using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    //need this to know how many explosives the player has
    [SerializeField]
    private DropBomb explosivesList;        

    //references for the text to change on the UI
    #region TMPText
    [SerializeField]
    private TMP_Text landmineUpgradeText;
    [SerializeField]
    private TMP_Text grenadeUpgradeText;
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private TMP_Text coinText;
    #endregion     


    private float landmineCount = 0;
    private float grenadeCount = 0;

    //counts how many special explosives the player has
    private float listTotal = 0;

    //timer at the top of the screen, showing how long the player is taking.
    private float timer;                   

   

   

    private void Start()
    {
        //makes the list total equal to the players inventory upon start up
        listTotal = explosivesList.explosiveUpgrade.Count;                
    }

    // Update is called once per frame
    void Update()
    {
        //starts timer
        timer += 1 * Time.deltaTime;

        //updates coin count
        coinText.text = "Coins: " + player.coins;

        //will change the upgrade text if the amount of explosives in the players inventory has changed
        if (listTotal != explosivesList.explosiveUpgrade.Count)   
        {
            updateUpgrades();
        }

        //change explosive text
        landmineUpgradeText.text = "Upgraded landmines: " + landmineCount;      
        grenadeUpgradeText.text = "Upgraded grenades: " + grenadeCount;         

        //change timer text
        timerText.text = timer.ToString("0");       
    }

    public void updateUpgrades()
    {
        //resets the explosive text
        landmineCount = 0;
        grenadeCount = 0;
        
        //calculates how many of each special the player has
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
        //resets the lis total
        listTotal = explosivesList.explosiveUpgrade.Count;

        
    }
  
}
