using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public GameObject ExplosionPrefab;
    public GameObject LaserbeamPrefab;
    public GameObject Ground;
    public Text ScoreText;
    public Text DamageText;
    public Scene Win;
    public Scene Lose;

    private int Score;
    private int Damage;
    private Rigidbody rb;
    private Rigidbody rigid;
    private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position; // where the enemy starts at in the game
        rigid = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        Score = 0; // the score at the start of the game
        SetScoreText();

        Damage = 100; // The player's health
        SetDamageText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Laserbeam") //Kills the Flying Saucer when it is hit by laser
        {
            Die();
            transform.position = startPos;
            rigid.velocity = Vector3.zero;
            Score = Score + 1; // Increases score when player shoots enemy
            SetScoreText();
        }

        if (col.tag == "Ground")
        {
            transform.position = startPos;
            rigid.velocity = Vector3.zero;
            Damage = Damage - 1; // Decreases health when enemy reaches goal
            SetDamageText();
        }
    }
    void Die() // start Explosion sequence
    {
        PlayExplosion();
    }
    void PlayExplosion() // Creates explosion prefab when Flying saucer dies
    {
        GameObject clone = Instantiate(ExplosionPrefab);
        clone.transform.position = transform.position;
        ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
        explosion.Play();
    }
    void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
        if (Score >= 20)
        {
            SceneManager.LoadScene("Win"); // You win scene
            
        }
    }
    void SetDamageText()
    {
        DamageText.text = "Health: " + Damage.ToString();
        if (Damage <= 0)
        {
            SceneManager.LoadScene("Lose"); // Game over scene
        }
    }
}
