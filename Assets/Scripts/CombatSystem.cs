using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public bool playerTurn;
    public  TextMeshProUGUI textMeshProUGUI;
    private int turn = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        textMeshProUGUI.text = textMeshProUGUI.text + turn.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!playerTurn)
        {
            //AI attacks
            EnemyUseSkillOrAttack();
        }
    }

    public IEnumerator PlayerUseSkillOrAttack()
    {
        if (playerTurn)
        {
            Debug.Log("PlAYER ATTACKS!!");
            yield return new WaitForSeconds(1.0f);
            playerTurn = false;
           
        }

    }

    public void EnemyUseSkillOrAttack()
    {
        Debug.Log("AI ATTACKS!!");
        playerTurn = true;
        turn++;
        textMeshProUGUI.text = "Turn " + turn.ToString();


    }

    public void OnPressSkillOrAttack()
    {
        StartCoroutine(PlayerUseSkillOrAttack());
        
    }
}
