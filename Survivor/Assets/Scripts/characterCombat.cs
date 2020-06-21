using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterStats))]
public class characterCombat : MonoBehaviour {

    public float attackSpeed = 1f;
    public float attackCooldown = 0f;

    characterStats CharactersStats;

    void Start() {
        CharactersStats = GetComponent<characterStats>();
    }

    void Update() {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack (characterStats stats) {
        if (attackCooldown <= 0) {
            Debug.Log("Attacking" + transform.name);
            stats.TakeDamage(CharactersStats.damage.getValue());
            attackCooldown = 1f/attackSpeed;
        }
    }
}