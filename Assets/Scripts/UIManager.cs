using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI gameName;

    public static event Action OnGameStarted;

    private void OnEnable()
    {
        OnGameStarted += CloseStartGameUI;
    }

    private void OnDisable()
    {
        OnGameStarted -= CloseStartGameUI;
    }

    public void OnStartButtonPressed()
    {
        OnGameStarted?.Invoke();
    }

    private void CloseStartGameUI()
    {
        button.gameObject.SetActive(false);
        gameName.gameObject.SetActive(false);
    }
   
}
