using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;

    private void Start()
    {
        // Display the final score on the end game UI
        finalScoreText.text = "Final Score: " + AllControl.GameManager.Instance.final;
    }
}
