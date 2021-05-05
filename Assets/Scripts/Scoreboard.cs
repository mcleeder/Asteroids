using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

    public TMP_Text scoreboard;
    private static int score;

    public static int BigAsteroidScoreValue = 100;
    public static int SmallAsteroidScoreValue = 33;

    private static int SmallAsteroidDestructionCount;
    private static int BigAsteroidDestructionCount;

    void Start()
    {
        score = 0;
        SmallAsteroidDestructionCount = 0;
        BigAsteroidDestructionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = string.Format("Score: " + score);
    }

    public static void ScoreBigAsteroid()
    {
        score += Mathf.RoundToInt(BigAsteroidScoreValue + BigAsteroidDestructionCount);
        BigAsteroidDestructionCount++;
    }

    public static void ScoreSmallAsteroid()
    {
        score += Mathf.RoundToInt(SmallAsteroidScoreValue + SmallAsteroidDestructionCount);
        SmallAsteroidDestructionCount += 2;
    }
}
