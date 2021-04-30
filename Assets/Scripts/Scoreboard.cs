using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

    public TMP_Text scoreboard;
    private static int score;
    private static float scoreMultiplier = 1;

    public static int BigAsteroidScoreValue = 100;
    public static int SmallAsteroidScoreValue = 33;

    private static int SmallAsteroidDestructionCount = 0;
    private static int BigAsteroidDestructionCount = 0;

    // Update is called once per frame
    void Update()
    {
        scoreMultiplier += Time.deltaTime;
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
