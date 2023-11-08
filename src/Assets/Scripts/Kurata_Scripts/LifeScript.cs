using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeScript : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Image[] healthImages;
    public GameObject gameOverUI;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            ShowGameOverScreen();
        }
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].enabled = true; // 体力がある場合、Imageを表示
            }
            else
            {
                healthImages[i].enabled = false; // 体力がない場合、Imageを非表示
            }
        }
    }

    void ShowGameOverScreen()
    {
        gameOverUI.SetActive(true); // ゲームオーバーUIを表示

        StartCoroutine(ReloadSceneAfterDelay(3.0f)); // 3秒待ってからシーンをリロード
    }

    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // シーンを再読み込む
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}