using UnityEngine;
using UnityEngine.UI;

public class HitInfo : MonoBehaviour
{
    [SerializeField] private Text infoText;

    public string Info
    {
        get => infoText.text;
        set
        {
            infoText.text = value;
        }
    }

    private void OnEnable()
    {
        GetComponent<Animator>().Play(0);   
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("AnimationEnded"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        
    }
}
