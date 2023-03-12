using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ScoreChangingActions { KilledWithGun, KilledWithRocket, KilledGroupWithRocket, KilledByBarrel, AttackingEnemy }

public class P_Score : MonoBehaviour
{
    [Header("Player score")]
    [SerializeField]
    int _score;
    [SerializeField]
    Slider multiplier;
    [SerializeField]
    TMP_Text multiplierLabel;
    float multiplierfill;
    Coroutine countDown;
    bool haltMLTdecrease;

   public  int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    public int scoreMultiplier;

    public float MultiplierBar
    {
        get
        {
            return multiplierfill;
        }
        set
        {
            multiplierfill = value;
            if (multiplierfill >= multiplier.maxValue && scoreMultiplier < 16)
            {
                multiplierfill %= multiplier.maxValue;
                scoreMultiplier *= 2;
                multiplierLabel.text = "x" + scoreMultiplier.ToString();
                haltMLTdecrease = true;
            }
            multiplier.value = multiplierfill;
        }
    }

    [Header("UI elements of score")]
    [SerializeField]
    TMP_Text comment;
    [SerializeField]
    CommentSet[] comments;
    [SerializeField]
    TextMeshProUGUI scoreText;

    [Header("Visual effect")]
    private int displayedScore;
    public int DisplayScore
    {
        get
        {
            return displayedScore;
        }
        set
        {
            displayedScore = value;
            scoreText.text = displayedScore.ToString();
        }
    }
    float delayTime;

    private void Awake()
    {
        scoreText.text = displayedScore.ToString();
        scoreMultiplier = 1;
        haltMLTdecrease = false;
    }

    private void FixedUpdate()
    {
        if (Score != displayedScore)
        {
            delayTime += Time.fixedDeltaTime;
            if (delayTime >= 0.075f)
            {
                DisplayScore++;
                delayTime = 0;
            } 
        }
    }
   
    public void GrantScore(ScoreChangingActions actions)
    {
        int oldMlt = scoreMultiplier;
        if (countDown != null) StopCoroutine(countDown);
        System.Random random = new System.Random();
        switch (actions)
        {
            case ScoreChangingActions.KilledWithGun:
                Score += (2 * scoreMultiplier);
                MultiplierBar += 0.15f;
                StartCoroutine(ShowComment((2 * scoreMultiplier), comments[0][random.Next(0, comments[0].comments.Length)]));
                break;
            case ScoreChangingActions.KilledWithRocket:
                Score += (10 * scoreMultiplier);
                MultiplierBar += 0.25f;
                StartCoroutine(ShowComment((10 * scoreMultiplier), comments[1][random.Next(0, comments[1].comments.Length)]));
                break;
            case ScoreChangingActions.KilledGroupWithRocket:
                Score += (25 * scoreMultiplier);
                MultiplierBar += 0.5f;
                StartCoroutine(ShowComment((25 * scoreMultiplier), comments[2][random.Next(0, comments[2].comments.Length)]));
                break;
            case ScoreChangingActions.KilledByBarrel:
                Score += (25 * scoreMultiplier);
                MultiplierBar += 0.5f;
                StartCoroutine(ShowComment((25 * scoreMultiplier), comments[3][random.Next(0, comments[3].comments.Length)]));
                break;
            case ScoreChangingActions.AttackingEnemy:
                MultiplierBar += 0.05f;
                break;
        }
        countDown = StartCoroutine(Countdown());
    }

    IEnumerator ShowComment(int delta, string text)
    {
        comment.text = "+" + delta.ToString() + " " + text;
        G_Controller.instatnce.UIController.combatUIAnimator.SetTrigger("Comment_Text_Anim");

        yield return new WaitForSeconds(1.5f);

        comment.text = "";
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.5f);

        for (; ; )
        {
            if (haltMLTdecrease)
            {
                yield return new WaitForSeconds(1.5f);
                haltMLTdecrease = false;
            }
            MultiplierBar -= Time.deltaTime * 0.1f;
            if (MultiplierBar <= 0)
            {
                scoreMultiplier = 1;
                multiplierLabel.text = "x" + scoreMultiplier.ToString();
                StopCoroutine(countDown);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void ResetScore()
    {
        Score = 0;
        DisplayScore = 0;
    }
}

[System.Serializable]
class CommentSet
{
    public string[] comments;
    public string this[int index]
    {
        get
        {
            return comments[index];
        }
    }
}