// // --
// // Author: Josh van den Heever
// // Date: 17/07/2018 @ 12:02 a.m.
// // --
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameScreen : MonoBehaviour
{
    public Button playAgainButton;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(() => RestartGame());
    }

    protected virtual void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
