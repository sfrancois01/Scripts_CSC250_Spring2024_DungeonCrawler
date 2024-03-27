using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;
    // Start is called before the first frame update
    void Start()
    {
        
        this.hero_hp_TMP.text = "Player HP: ";
        if (seth.hp != 0 && rake.hp != 0 )
        {
            if(Random.Range(1,21)> seth.armor)
            {
                seth.armor = 0;
                seth.hp = seth.hp - Random.Range(1, 7);

            }
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
