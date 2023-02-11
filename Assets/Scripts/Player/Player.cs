using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action<Player> onPlayerDeath;
    public int health = 5;

    void collidedWithEnemy(Enemy enemy) {
        enemy.Attack(this);
        if(health <= 0) {
            if(onPlayerDeath != null) {
                onPlayerDeath(this);
            }
        }
    }

    void OnCollisionEnter (Collision col) {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if(enemy) {
            collidedWithEnemy(enemy);
        }
    }
}
