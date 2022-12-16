using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static Money Instance { get; private set; }
    [SerializeField] private Text text;
    [SerializeField] private SkillArticleUI rewardSkill;
    [SerializeField] private float animationSpeed = 0.5f;
    public float MoneyCount { get; private set; }

    private void Awake()
    {
        Instance = this;
        MoneyCount = rewardSkill.Points;
        text.text = $"{MoneyCount}$";
    }

    public void GetReward()
    {
        AddMoney((int)rewardSkill.Points);
    }

    public void AddMoney(int count)
    {
        if (count < 0) return;
        StopAllCoroutines();
        StartCoroutine(ChangeBalanceAnimation(MoneyCount, (int)MoneyCount + count));
    }

    public bool SpendMoney(int count)
    {
        if (count < 0 || (count > MoneyCount)) return false;
        StopAllCoroutines();
        StartCoroutine(ChangeBalanceAnimation(MoneyCount, (int)MoneyCount - count));
        return true;
    }

    private IEnumerator ChangeBalanceAnimation(float currentBalance, int expectingBalance)
    {
        MoneyCount = expectingBalance;
        float difference = expectingBalance - currentBalance;
        float secondsPart = animationSpeed / difference;
        WaitForSeconds wait = new (Mathf.Abs(secondsPart));
        while (Mathf.Abs(currentBalance - expectingBalance) > 1)
        {
            currentBalance += Mathf.Sign(difference);
            text.text = $"{(int)currentBalance}$";
            yield return wait;
        }
        text.text = $"{MoneyCount}$";
    }

    private void OnEnable()
    {
        Enemy.OnDie += GetReward;
    }

    private void OnDisable()
    {
        Enemy.OnDie -= GetReward;
    }
}
