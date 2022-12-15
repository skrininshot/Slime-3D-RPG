using System;
using UnityEngine;

public class MovingPanel : MonoBehaviour
{
    public static event Action OnPanelPassed;
    [SerializeField] private int panelSize = 20;
    public void Move(float speed)
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x + (panelSize * 0.5)  < - (panelSize * 0.5))
        {
            transform.position = new Vector3(transform.position.x + (panelSize * 2f), 0, 0);
            OnPanelPassed();
        } 
    }
}
