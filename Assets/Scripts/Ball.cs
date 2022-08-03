using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    private bool isPressed = false;
    float maxDragDistance = 2f;
    public GameObject nextBall;

    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos-hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(release());
    }

    IEnumerator release()
    {
        yield return new WaitForSeconds(.15f);

        GetComponent<SpringJoint2D>().enabled = false;

        this.enabled = false;

        yield return new WaitForSeconds(3f);

        if (nextBall != null)
            nextBall.SetActive(true);
        else
        {
            enemy.isAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            

    }
}
