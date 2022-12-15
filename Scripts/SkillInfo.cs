using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Skill")]
public class SkillInfo : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private int startCost;
    [SerializeField] private int startPoints;
    [SerializeField] private Sprite art;
    [SerializeField] private int pointsPerBuy;

    public int StartCost => startCost;
    public int StartPoints => startPoints;
    public int Points => startPoints;
    public int Level => level;
    public Sprite Art => art;
    public int PointsPerBuy => pointsPerBuy;
}
