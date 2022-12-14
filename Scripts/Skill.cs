using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject
{
    [SerializeField] public int points;
    [SerializeField] public int level;
    [SerializeField] public int cost;
    [SerializeField] public Sprite art;
}
