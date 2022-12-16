using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Skill")]
public class SkillInfo : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private int startCost;
    [SerializeField] private int startPoints;
    [SerializeField] private Sprite art;
    [SerializeField] private float pointsPerBuy;

    public int StartCost => startCost;
    public float StartPoints => startPoints;
    public int Points => startPoints;
    public int Level => level;
    public Sprite Art => art;
    public float PointsPerBuy => pointsPerBuy;
}
