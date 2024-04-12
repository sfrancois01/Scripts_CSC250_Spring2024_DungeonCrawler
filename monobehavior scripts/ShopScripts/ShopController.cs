using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public TextMeshPro playerTMP, itemTMP;
    // Start is called before the first frame update
    void Start()
    {
        this.playerTMP.text = "" + MySingleton.currentPellets;
        this.itemTMP.text = "" + ItemsSingleton.blasterItemCost;
    }

    private void updatePlayerTMP()
    {
        this.playerTMP.text = "Pellets: " + MySingleton.currentPellets + "(HP: " MySIngleton.thePlayer.getHP() + ")";

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyUp(KeyCode.Aplpha1))
        {
            if(MySingleton.currentPellets >= ItemsSingleton.blasterItemCost)
            {
                MySingleton.currentPellets -= ItemsSingleton.blasterItemCost;
                MySingleton.thePlayer.addHP(5);
                this.updatePlayerTMP();
            }
        }
    }
}
