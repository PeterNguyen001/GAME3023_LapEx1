using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public bool playerTurn;
    public  TextMeshProUGUI textMeshProUGUI;
    private int turn = 1;

    private Character player;
    public Character enemy;



    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        textMeshProUGUI.text = textMeshProUGUI.text + turn.ToString();
        player = FindObjectOfType<PlayableCharacter>();
        enemy = FindObjectOfType<NonPlayableCharacter>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessTurn(SkillData skill)
    {
        StartCoroutine(PlayerUseSkillOrAttack(skill));
        //StartCoroutine(EnemyUseSkillOrAttack(skill));

    }
    public IEnumerator PlayerUseSkillOrAttack(SkillData skill)
    {
        if (playerTurn)
        {
            if (player.GetMana() >= skill.cost)
            {
                Debug.Log("PLAYER Move!!");
                UseSkillOn(skill, enemy);
                playerTurn = false;
                yield return new WaitForSeconds(1);
                player.ReduceMana(skill.cost);
            }
            else
            {
                Debug.Log("NOT ENOUGH MANA");
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(1);
        }

    }

    public IEnumerator EnemyUseSkillOrAttack(SkillData skill)
    {
        yield return new WaitForSeconds(1);
        if (!playerTurn)
        {
            Debug.Log("AI Move!!");
            UseSkillOn(skill, player);
            playerTurn = true;       
            player.AddMana(10);
            enemy.AddMana(10);
            turn++;
            textMeshProUGUI.text = "Turn " + turn.ToString();
        }

    }

    public void UseSkillOn(SkillData skill, Character target)
    {
        target.EffectedWith(skill);
    }
    public bool GetPlayerTurn()
    { return playerTurn; }
}
