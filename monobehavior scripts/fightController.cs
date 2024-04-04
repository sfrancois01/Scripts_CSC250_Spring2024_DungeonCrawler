using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Monster theMonster;
    private bool shouldAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Rake");
        this.monster_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();
        this.hero_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();
        int num = Random.Range(0, 2);
        if (num == 0 )
        {
            this.currentAttacker = hero_GO;
        }
        else
        {
            this.currentAttacker = monster_GO;
        }

        StartCoroutine(fight());
    
    }

    private void tryAttack(Inhabitant attack, Inhabitant defender)
    {
        int attackRoll = Random.Range(0, 20) + 1;
        if (attackRoll >= defender.getAC()) 
        {
            int damageRoll = Random.Range(0, 4) + 2;
            defender.takeDamage(damageRoll);
            print(attack + " Attack Hit!!!");
        }
        else
        {
            print(attack + "Attack Missed!!!");
        }
    }

   IEnumerator fight()
    {
        yield return new WaitForSeconds(2);
        if (this.shouldAttack == true)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            this.theCurrentAnimator.SetTrigger("attack");
            if (this.currentAttacker == this.hero_GO)
            {
                this.currentAttacker = this.monster_GO;
                this.tryAttack(MySingleton.thePlayer, this.theMonster);
                this.monster_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();
                //check if dead
                if (this.theMonster.getHP() <= 0)
                {
                    print("Hero Wins!!!");
                    this.shouldAttack = false;
                    this.currentAttacker = this.monster_GO;
                    this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
                    this.theCurrentAnimator.SetBool("death", true);

                }
                else
                {
                    StartCoroutine(fight());
                }
            }
            else
            {
                this.currentAttacker = this.hero_GO;
                this.tryAttack(this.theMonster, MySingleton.thePlayer);
                this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();
                //check if dead
                this.tryAttack(MySingleton.thePlayer, this.theMonster);
                if (MySingleton.thePlayer.getHP() <= 0)
                {
                    print("Monster Wins!!!");
                    this.shouldAttack = false;
                    this.currentAttacker = this.hero_GO;
                    this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
                    this.theCurrentAnimator.SetBool("death", true);

                }
                else
                {
                    StartCoroutine(fight());
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
