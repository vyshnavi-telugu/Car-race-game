using UnityEngine;
using UnityEngine.SceneManagement;
using Game;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameState currentGameState = GameState.START_MENU;
        public int currentLevel = 1;
        public int maxLevel = 10;

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

        private void Update()
        {
            if (currentGameState == GameState.PLAYING && PlayerCrossedFinishLine())
            {
                LevelComplete();
            }
        }

        private bool PlayerCrossedFinishLine()
        {
            // TODO: Replace with actual finish line detection
            return false;
        }

        public void StartGame()
        {
            currentLevel = 1;
            currentGameState = GameState.PLAYING;
            SceneManager.LoadScene("Level" + currentLevel);
        }

        public void LevelComplete()
        {
            currentGameState = GameState.LEVEL_COMPLETE;
            UIManager.Instance?.ShowLevelComplete();
        }

        public void LoadNextLevel()
        {
            currentLevel++;

            if (currentLevel > maxLevel)
            {
                currentGameState = GameState.GAME_WON;
                UIManager.Instance?.ShowGameWon();
            }
            else
            {
                SceneManager.LoadScene("Level" + currentLevel);
                currentGameState = GameState.PLAYING;
            }
        }
    }
}
