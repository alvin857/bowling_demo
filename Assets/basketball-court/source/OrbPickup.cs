using UnityEngine;
using TMPro;

public class OrbPickup : MonoBehaviour
{
    public Transform orb;               
    public GameObject youWinUI;          
    public TextMeshProUGUI scoreText;    
    public int pointsToWin = 5;
    public AudioSource pickupSound; 

    public int score = 0;

    void Start()
    {
        if (youWinUI != null)
            youWinUI.SetActive(false);

        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && orb != null)
        {
            PickUpOrb();
        }
    }

    void PickUpOrb()
    {
        score++;
        UpdateScoreText();

        pickupSound.Play();

        if (score >= pointsToWin && youWinUI != null)
        {
            youWinUI.SetActive(true);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}