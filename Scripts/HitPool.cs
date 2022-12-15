using UnityEngine;

public class HitPool : MonoBehaviour
{
    public static HitPool Instance { get; private set; }
    [SerializeField] private HitInfo hitPrefab;
    private PoolMono<HitInfo> hitPool;

    private void Awake()
    {
        Instance = this;
        hitPool = new PoolMono<HitInfo>(hitPrefab, 5, transform);
        hitPool.AutoExpand = true;
    }

    public void CreateHit(Vector3 point, int info)
    {
        HitInfo newHit = hitPool.GetFreeElement();
        newHit.transform.position = point;
        newHit.Info = info.ToString();
    }
}
