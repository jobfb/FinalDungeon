using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //text fields
   public Text levelText,hitpointText,pesosText,upgradeCostText,xpText;


    //logic variables
    private int currentChatacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;


    //character selection
    public void OnArrowClick(bool right) 
    {
        if (right) 
        {
            currentChatacterSelection++;

            //if went to far
            if (currentChatacterSelection == GameManager.instance.playerSprites.Count)
            {
                currentChatacterSelection = 0;
            }
            OnSelectionChanged();
        }
        else
        {
            currentChatacterSelection--;

            //if went to far
            if (currentChatacterSelection <0)
            {
                currentChatacterSelection = GameManager.instance.playerSprites.Count-1 ;
            }
            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged() 
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentChatacterSelection];
    }
   
    //Weapon Upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }

    }

    // Update character information
    public void UpdateMenu()
    {
        //weapon
        weaponSprite.sprite = GameManager.instance.weapon[GameManager.instance.Weapon.weaponLevel];
        upgradeCostText.text = "NOT IMPLEMENTED YET"; // GameManager.instance.weaponUpgradeCost.ToString();
        //meta
        levelText.text = "NOT IMPLEMENTED YET"; // GameManager.instance.player.level.ToString();
        hitpointText.text = GameManager.instance.player.hitPoints.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();

        //xp Bar
        xpText.text = "NOT IMPLEMENTED YET"; // GameManager.instance.player.experience.ToString() + "/" + GameManager.instance.player.experienceToNextLevel.ToString();
        xpBar.localScale = new Vector3(0.5f,0,0);
    }
}

