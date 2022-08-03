using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemy : MonoBehaviour
{
    public float health = 4f;
    public GameObject deathEffect;
    public static float isAlive = 0f;

    private void Start()
    {
        isAlive++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive--;

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        if (isAlive <= 0)
        {
            isAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            

    }

}
