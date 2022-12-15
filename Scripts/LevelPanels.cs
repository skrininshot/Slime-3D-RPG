using UnityEngine;

public class LevelPanels : MonoBehaviour
{
    public static LevelPanels Instance;
    [SerializeField] private MovingPanel[] panels;

    private void Awake()
    {
        Instance = this;
    }

    public void Move(float speed)
    {
        foreach (MovingPanel panel in panels)
        {
            panel.Move(speed);
        }
    }
}
