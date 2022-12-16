using UnityEngine;
using UnityEngine.UI;

public class SkillArticleUI : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text costText;
    [SerializeField] private Image artImage;
    [SerializeField] private SkillInfo skillInfo;

    private int level;
    private int startCost;
    private float startPoints;
    private Sprite art;
    private float pointsPerBuy;

    public float Points => startPoints + (level > 1 ? (pointsPerBuy * (level - 1)) : 0);
    public int Level
    {
        get => level;
        set
        {
            if (value > 0) level = value;
        }
    }
    public int CurrectCost => level * startCost;
    public Sprite Art => art;
    public float PointsPerBuy => pointsPerBuy;

    public delegate void UpgradeSkill();
    public static event UpgradeSkill OnUpgrade;

    private void Awake()
    { 
        level = skillInfo.Level;
        startCost = skillInfo.StartCost;
        startPoints = skillInfo.StartPoints;
        art = skillInfo.Art;
        pointsPerBuy = skillInfo.PointsPerBuy;

        nameText.text = skillInfo.name;
        artImage.sprite = Art;

        UpdateInfo();
    }

    public void SkillLevelUp()
    {
        if (!Money.Instance.SpendMoney(CurrectCost)) return;
        level++;
        UpdateInfo();
        OnUpgrade();
    }

    private void UpdateInfo()
    {
        pointsText.text = Points.ToString();
        levelText.text = "Lv " + Level.ToString();
        costText.text = CurrectCost.ToString() + "$";
    }
}
