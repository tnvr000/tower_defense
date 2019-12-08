using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed = 30f;
    public float startHealth = 100;
    private float health = 100;
    public int worth = 30;
    public GameObject EnemyDeathEffect;
    [Header("Unity Attributes")]
    public Image healthBar;
    private bool isDead = false;
    void Start() {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float DamageAmount) {
        health -= DamageAmount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead) {
            Die();
        }
    }
    public void Slow(float slowAmount) {
        speed = startSpeed * (1 - slowAmount);
    }
    void Die() {
        if(isDead) {
            return;
        }
        PlayerStats.Money += worth;
        GameObject enemyDeathEffect = (GameObject)Instantiate(EnemyDeathEffect, transform.position, Quaternion.identity);
        WaveSpawner.enemiesAlive--;
        Destroy(enemyDeathEffect, 3f);
        Destroy(gameObject);
        return;
    }
    
}
