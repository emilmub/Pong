using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 direction = new Vector3(1, 1, 0)/Mathf.Sqrt(2);
    [SerializeField] private float speed = 5;

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    public AudioSource collisionSound;
    public AudioSource scoreAudio;

    private int p1Score = 0;
    private int p2Score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.position += speed * direction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            direction.y *= -1;
        }

        if (collision.gameObject.tag == "Paddle")
        {
            direction.x *= -1;
        }
        collisionSound.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "P1 Goal")
        {
            // Add one to P2 score
            p2Score += 1;
            p2ScoreText.text = "" + p2Score;

            // Reset ball
            transform.position = Vector3.zero;
        }

        else if (collision.gameObject.name == "P2 Goal")
        {
            // Add one to P2 score
            p1Score += 1;
            p1ScoreText.text = "" + p1Score;

            // Reset ball
            transform.position = Vector3.zero;
        }

        scoreAudio.Play();
    }
}
