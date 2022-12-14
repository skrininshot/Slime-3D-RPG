using UnityEngine;
using UnityEngine.UI;

public class SkillArticleUI : MonoBehaviour
{
    [SerializeField] private Text skillName;
    [SerializeField] private Text points;
    [SerializeField] private Text level;
    [SerializeField] private Text cost;
    [SerializeField] private Image art;
    [SerializeField] private Skill skill;
    [SerializeField] private int pointsPerBuy;

    public delegate void UpgradeSkill();
    public static event UpgradeSkill OnUpgrade;

    private void Awake()
    {
        name = skill.name;
        UpdateInfo();
    }

    public void SkillLevelUp()
    {
        skill.level++;
        skill.points += pointsPerBuy;
        skill.cost = skill.level * pointsPerBuy;
        UpdateInfo();
        OnUpgrade();
    }

    private void UpdateInfo()
    {
        skillName.text = skill.name;
        points.text = skill.points.ToString();
        level.text = "Lv " + skill.level.ToString();
        cost.text = skill.cost.ToString() + "$";
        art.sprite = skill.art;
    }
}
