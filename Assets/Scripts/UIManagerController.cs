using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManagerController : MonoBehaviour
{
    [SerializeField] private TMP_Text textLife;
    [SerializeField] private TMP_Text textPoints;
    [SerializeField] private GameObject defeatScreen;
    [SerializeField] private PlayerController player;

    private void OnDisable()
    {
        player.lifeChanged -= UpdateUILife;
        player.isDied -= ShowDefeatScreen;
    }

    public void UpdateUILife(int actualLife)
    {
        textLife.text = "Lifes: " + actualLife;
    }

    public void UpdateUIPoints(int currentPoints)
    {
        textPoints.text = "Score: " + currentPoints;
    }

    public void ShowDefeatScreen()
    {
        defeatScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
    }
}