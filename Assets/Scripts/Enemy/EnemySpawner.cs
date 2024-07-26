using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private BulletSpawner bulletSpawner;
    private int enemiesDestroyedCount = 0;
    private List<EnemyController> enemies;
    private List<Transform> pointsAlreadySpawned;
    private List<Transform> spawnPoints;

    private Transform playerTransform;
    [SerializeField] private EnemyScriptableObjectList enemyTankList;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Canvas enemyUICanvas;
    [SerializeField] private Transform SpawnPointParent;
    [SerializeField] private int enemyCount = 3;
    [SerializeField] TankSpawner tankSpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<EnemyController>();
        spawnPoints = new List<Transform>();
        pointsAlreadySpawned = new List<Transform>();
        foreach (Transform item in SpawnPointParent)
            spawnPoints.Add(item);
        StartCoroutine(SpawnEnemyTanks(enemyCount));
        playerTransform = tankSpawner.GetPlayerTransform();
    }

    
    IEnumerator SpawnEnemyTanks(int count)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < count; i++)
        {
            Vector3 newPosition = GetRandomSpawnPoint();
            EnemyType enemyType = GetRandomEnemyType();

            if (newPosition == Vector3.zero)
                break;

            EnemyController enemyController = CreateEnemyTank(enemyType, newPosition);
            enemies.Add(enemyController);

           // yield return new WaitForSeconds(0.1f);
            

        }
       
    }
    public Vector3 GetRandomSpawnPoint()
    {
        if (spawnPoints.Count == 0)
            return Vector3.zero;

        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        Transform newSpawnPoint = spawnPoints[spawnPointIndex];

        pointsAlreadySpawned.Add(newSpawnPoint);
        spawnPoints.RemoveAt(spawnPointIndex);

        return newSpawnPoint.position;
    }
    public void ShootBullet(BulletType bulletType, Transform gunTransform)
    {
        bulletSpawner.SpawnBullet(bulletType, gunTransform, TankType.EnemyBlack);
    }
    public void DestoryEnemy(EnemyController _enemyController, EnemyType _enemyType)
    {
        Vector3 pos = _enemyController.GetPosition();
        _enemyController.DisableEnemyTank();

        switch (_enemyType)
        {
            case EnemyType.Brown:
                Debug.Log("Brown");
                break;
            case EnemyType.Purple:
                Debug.Log("Purple");
                break;
            case EnemyType.Black:
                Debug.Log("Black");
                break;
        }

        enemies.Remove(_enemyController);
        //StartCoroutine(TankExplosion(pos));

        if (playerTransform != null)
        {
            EventService.Instance.InvokeEnemyDestroy(++enemiesDestroyedCount);
            StartCoroutine(SpawnEnemyTank());
        }
    }
    /*public IEnumerator TankExplosion(Vector3 tankPos)
    {
        ParticleSystem newTankExplosion = tankExplosionPoolService.GetExplosion(tankExplosion);
        newTankExplosion.transform.position = tankPos;
        newTankExplosion.gameObject.SetActive(true);
        newTankExplosion.Play();

        yield return new WaitForSeconds(2f);

        newTankExplosion.gameObject.SetActive(false);
    }*/
    IEnumerator SpawnEnemyTank()
    {
        yield return new WaitForSeconds(2f);

        Vector3 newPosition = GetExistingSpawnPoint();
        EnemyType enemyType = GetRandomEnemyType();

        if (newPosition == Vector3.zero)
            yield break;

        EnemyController enemyController = CreateEnemyTank(enemyType, newPosition);
        enemies.Add(enemyController);
    }
    public Vector3 GetExistingSpawnPoint()
    {
        if (pointsAlreadySpawned.Count == 0)
            return Vector3.zero;

        int spawnPointIndex;
        Transform newSpawnPoint;

        if (!playerTransform)
            return Vector3.zero;

        do
        {
            spawnPointIndex = UnityEngine.Random.Range(0, pointsAlreadySpawned.Count);
            newSpawnPoint = pointsAlreadySpawned[spawnPointIndex];
        }
        while (Vector3.Distance(newSpawnPoint.position, playerTransform.position) < 10f);

        return newSpawnPoint.position;
    }
    public EnemyController CreateEnemyTank(EnemyType enemyType, Vector3 newPosition)
    {
        EnemyScriptableObject enemyData = enemyTankList.enemies[(int)enemyType];

        EnemyController enemyController = null;

        switch (enemyType)
        {
            case EnemyType.Brown:
                enemyController = new EnemyController(enemyData,this, enemyType, playerCamera, enemyUICanvas);
                break;
            case EnemyType.Purple:
                enemyController = new EnemyController(enemyData,this, enemyType, playerCamera, enemyUICanvas);
                break;
            case EnemyType.Black:
                enemyController = new EnemyController(enemyData, this, enemyType, playerCamera, enemyUICanvas);
                break;
            default: break;
        }

        enemyController.EnableEnemyTank(playerTransform, newPosition);

        return enemyController;
    }
    public EnemyType GetRandomEnemyType()
    {
        return (EnemyType)UnityEngine.Random.Range(0, enemyTankList.enemies.Length);
    }

}
