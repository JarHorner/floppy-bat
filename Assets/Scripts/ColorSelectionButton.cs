using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorSelectionButton : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private Animator animator;
    [SerializeField] private RuntimeAnimatorController playerAnim;
    [SerializeField] private bool isLocked;
    [SerializeField] private GameObject requirements;
    [SerializeField] TextMeshProUGUI requiredTotalScore;
    [SerializeField] private TextMeshProUGUI totalScore;
    
    public void SelectBat()
    {
       animator.SetBool("Selected", true);
    }

    void Start() 
    {
        if (PlayerPrefs.GetInt($"Bat{number}") == 1)
        {
            requirements.SetActive(false);
            isLocked = false;
        }
        else
        {
            PlayerPrefs.SetInt($"Bat{number}", 0);
        }
    }

    public Animator Animator
    {
       get { return animator; }
       set { animator = value; }
    }

    public RuntimeAnimatorController PlayerAnim
    {
        get { return playerAnim; }
    }

    public bool IsLocked
    {
        get { return isLocked; }
    }

    public void Unlock()
    {
        if (PlayerPrefs.GetInt("TotalScore") >= int.Parse(requiredTotalScore.text) && isLocked)
        {
            isLocked = false;
            PlayerPrefs.SetInt($"Bat{number}", 1);
            int newCurrentScore = PlayerPrefs.GetInt("TotalScore") - int.Parse(requiredTotalScore.text);
            PlayerPrefs.SetInt("TotalScore", newCurrentScore);
            totalScore.text = PlayerPrefs.GetInt("TotalScore").ToString();
            requirements.SetActive(false);
        }
    }
}

