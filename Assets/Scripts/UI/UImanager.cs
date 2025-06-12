using UnityEngine;
using Managers;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [Header("UI Panels")]
        public GameObject levelCompletePanel;
        public GameObject gameWonPanel;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ShowLevelComplete()
        {
            if (levelCompletePanel != null)
                levelCompletePanel.SetActive(true);
        }

        public void ShowGameWon()
        {
            if (gameWonPanel != null)
                gameWonPanel.SetActive(true);
        }

        public void OnNextLevelButton()
        {
            GameManager.Instance?.LoadNextLevel();
        }
    }
}
