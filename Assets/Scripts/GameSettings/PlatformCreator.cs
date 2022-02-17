using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] private GameObject platform;

    private Transform spawnPoint;

    List<Transform> platforms = new List<Transform>();

    public enum Type
    {
        defaultCreate,
        finishCreate
    }

    public Type creatingType;

    void Start()
    {
        StartSettings();

        Creation();
    }

    private void StartSettings()
    {
        spawnPoint = gameObject.transform;
    }

    private void Creation()
    {
        for (int i = 0; i < GameController.instance.levelsData.StartPlatformsCount; i++)
        {
            GameObject platformClone = Instantiate(platform, spawnPoint.position, Quaternion.identity);
            platforms.Add(platformClone.transform);
        }

        for (int a = 1; a < platforms.Count; a++)
        {
            float randomDistance = Random.Range(GameController.instance.levelsData.MinDistansPlatform,
                                                GameController.instance.levelsData.MaxDistansPlatform);

            platforms[a].transform.localScale = new Vector3(Random.Range(GameController.instance.levelsData.MinPlatformSize,
                                                                         GameController.instance.levelsData.MaxPlatformSize), 1, 1);

            platforms[a].transform.position = new Vector3
                (
                    platforms[a - 1].transform.position.x + ((platforms[a - 1].transform.localScale.x + platforms[a].transform.localScale.x)/2)  + randomDistance,
                    spawnPoint.position.y,
                    spawnPoint.position.z
                );
        }

        if(creatingType == Type.finishCreate)
        {
            GameObject finishClone = Instantiate(GameController.instance.levelsData.Finish,
                                                    new Vector2( platforms[platforms.Count - 2].transform.position.x, 0), Quaternion.identity);

            GameController.instance.AllLevelsPlatform(true, finishClone.GetComponent<PlatformMover>());
        }

        foreach (var platform in platforms)
        {
            PlatformMover platformMover = platform.GetComponent<PlatformMover>();

            GameController.instance.AllLevelsPlatform(true, platformMover);
        }
    }
}
