using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    private Character player;
    private CombatSystem combatSystem;
    private Character self;
    void Start()
    {
        player = FindObjectOfType<PlayableCharacter>(); 
        combatSystem = FindObjectOfType<CombatSystem>();
        self = gameObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!combatSystem.GetPlayerTurn())
        {
            MakeDecision();
        }
    }

    private void MakeDecision()
    {
        // Calculate the probability of using a health skill based on health and mana.
        float healthProbability = Mathf.Pow(self.GetHealth() / (float)self.GetMaxHealth(), 2f);


        // Generate random values between 0 and 1 for health and mana.
        float randomHealthValue = Random.Range(0f, 1f);
        float randomManaValue = Random.Range(0f, 1f);

        // Introduce randomness into the decision process.
        if (randomHealthValue < healthProbability && self.GetHealth() < self.GetMaxHealth() * 0.5)
        {
            // If health probability is met but mana probability is not met, use a health skill.
            UseHealthSkill();
        }
        else
        {
            // Otherwise, attack.
            Attack();
        }
    }

    private void UseHealthSkill()
    {
        if (self.GetMana() >= self.skillList[1].cost)
        {
            // Deduct the mana cost.
            StartCoroutine(combatSystem.EnemyUseSkillOrAttack(self.skillList[1]));
            // Implement the logic to use a health skill here.
            Debug.Log("Healing");
        }
        else
        {
            Attack();
            // If there's not enough mana, consider an alternative action or handle mana shortage.
            Debug.Log("Not enough mana for healing skill.");
            // Implement an alternative action or handle mana shortage.
        }
    }

    private void Attack()
    {
        // Implement the logic to perform an attack here.
        if (self.GetMana() < 15)
        {
            StartCoroutine(combatSystem.EnemyUseSkillOrAttack(self.skillList[0]));
        }
        else
        { StartCoroutine(combatSystem.EnemyUseSkillOrAttack(self.skillList[2])); }
        Debug.Log("Attacking");
    }
}
