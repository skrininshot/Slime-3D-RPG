using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class SkillInfo : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private int startCost;
    [SerializeField] private int startPoints;
    [SerializeField] private Sprite art;
    [SerializeField] private int pointsPerBuy;

    public int Points =>  startPoints + (level > 1 ? (pointsPerBuy * level) : 0);
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
    public int PointsPerBuy => pointsPerBuy;
}
