using UnityEngine;
using UnityEngine.UI;

public class SkillArticleUI : MonoBehaviour
{
    [SerializeField] private Text skillName;
    [SerializeField] private Text points;
    [SerializeField] private Text level;
    [SerializeField] private Text cost;
    [SerializeField] private Image art;
    [SerializeField] private SkillInfo skill;

    public delegate void UpgradeSkill();
    public static event UpgradeSkill OnUpgrade;

    private void Awake()
    {
        name = skill.name;
        UpdateInfo();
    }

    public void SkillLevelUp()
    {
        if (!Money.Instance.SpendMoney(skill.CurrectCost)) return;
        skill.Level++;
        UpdateInfo();
        OnUpgrade();
    }

    private void UpdateInfo()
    {
        skillName.text = skill.name;
        points.text = skill.Points.ToString();
        level.text = "Lv " + skill.Level.ToString();
        cost.text = skill.CurrectCost.ToString() + "$";
        art.sprite = skill.Art;
    }
}
