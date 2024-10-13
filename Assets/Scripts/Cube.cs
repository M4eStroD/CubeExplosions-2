using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(SpawnerCubes))]
public class Cube : MonoBehaviour, ICrashable, IExplodable
{
    private int _chanceCrash = 100;
    
    private SpawnerCubes _spawnCubes;
    private Exploder _exploder;

    public int ChanceCrash => _chanceCrash;

    private void Start()
    {
        _spawnCubes = GetComponent<SpawnerCubes>();
        _exploder = GetComponent<Exploder>();
    }

    public void Initialize(int chanceCrash)
    {
        _chanceCrash = chanceCrash;
    }

    private void OnMouseUpAsButton()
    {
        TryCrash();
        Destroy(gameObject);
    }

    private void TryCrash()
    {
        int hundredPercent = 100;

        int randomNumber = Random.Range(0, hundredPercent + 1);

        if (randomNumber >= _chanceCrash)
            Explode();
        else
            Crash();
    }

    private void Crash()
    {
        _spawnCubes.Initialize(this);
    }

    private void Explode()
    {
        _exploder.Explode(transform);
    }
}