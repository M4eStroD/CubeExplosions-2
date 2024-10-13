using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(SpawnerCube))]
public class Cube : MonoBehaviour, ICrashable, IExplodable
{
    private int _crashChance = 100;

    private SpawnerCube _spawnCube;
    private Exploder _exploder;

    public int CrashChance => _crashChance;

    private void Start()
    {
        _spawnCube = GetComponent<SpawnerCube>();
        _exploder = GetComponent<Exploder>();
    }

    public void Initialize(int chanceCrash)
    {
        _crashChance = chanceCrash;
    }

    private void OnMouseUpAsButton()
    {
        Crash();
        Destroy(gameObject);
    }
    
    private void Crash()
    {
        int hundredPercent = 100;

        int randomNumber = Random.Range(0, hundredPercent + 1);

        if (randomNumber >= _crashChance)
            Explode();
        else
            _spawnCube.Initialize(this);
    }

    private void Explode()
    {
        _exploder.Explode(transform);
    }
}