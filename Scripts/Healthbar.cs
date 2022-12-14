using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image line;

    public void Set(float value, float maxValue)
    {
        if (value <= 0 || maxValue <= 0)
        {
            line.fillAmount = 0;
            return;
        }
        line.fillAmount = value / maxValue;
    }
}
