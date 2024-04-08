using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;


public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Monster theMonster;
    private bool shouldAttack = true;
    private AudioSource attackSound;
    public TextMeshPro fightCommentaryTMP;
    // Start is called before the first frame update
    void Start()
    {
        this.fightCommentaryTMP.text = "";
        this.theMonster = new Monster("Rake");
        this.monster_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();
        this.hero_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();
        int num = Random.Range(0, 2);
        if (num == 0)
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
        this.fightCommentaryTMP.text = "";
        int attackRoll = Random.Range(0, 20) + 1;
        if (attackRoll >= defender.getAC())
        {
            int damageRoll = Random.Range(0, 4) + 2;
            this.fightCommentaryTMP.color = Color.red;
            this.fightCommentaryTMP.text = "Attack Hits for " + damageRoll;
            defender.takeDamage(damageRoll);
        }
        else
        {
            this.fightCommentaryTMP.color = Color.blue;
            this.fightCommentaryTMP.text = "Attack Misses!";
        }
    }

    IEnumerator fight()
    {
        yield return new WaitForSeconds(1);
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
                    this.fightCommentaryTMP.text = "Hero Wins!!!";
                    this.shouldAttack = false;
                    this.currentAttacker = this.monster_GO;
                    this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
                    this.theCurrentAnimator.SetBool("death", true);
                    EditorSceneManager.LoadScene("DungeonS1");

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
                    this.fightCommentaryTMP.text = "Monster Wins!!!";
                    this.shouldAttack = false;
                    this.currentAttacker = this.hero_GO;
                    this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
                    this.theCurrentAnimator.SetBool("death", true);
                  
                    EditorSceneManager.LoadScene("DungeonS1");

                }
                else
                {
                    StartCoroutine(fight());
                }

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
