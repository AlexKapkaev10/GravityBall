using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data", order = 51)]
public class LevelsData : ScriptableObject
{
    [SerializeField] private float startPlatformsCount;

    [SerializeField] private float minDistansPlatform;

    [SerializeField] private float maxDistansPlatform;

    [SerializeField] private float platformSpeed;

    [SerializeField] private float minPlatformSize;

    [SerializeField] private float maxPlatformSize;

    [SerializeField] private GameObject finishPrefab;

    public float StartPlatformsCount
    {
        get
        {
            return startPlatformsCount;
        }
    }

    public float MinDistansPlatform
    {
        get
        {
            return minDistansPlatform;
        }
    }

    public float MaxDistansPlatform
    {
        get
        {
            return maxDistansPlatform;
        }
    }

    public float PlatformSpeed
    {
        get
        {
            return platformSpeed;
        }
    }

    public float MinPlatformSize
    {
        get
        {
            return minPlatformSize;
        }
    }

    public float MaxPlatformSize
    {
        get
        {
            return maxPlatformSize;
        }
    }

    public GameObject Finish
    {
        get
        {
            return finishPrefab;
        }
    }
}
