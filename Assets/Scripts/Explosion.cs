using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    [SerializeField] private SpawnerCubes _spawnCubes;

    [SerializeField] private int _chanceCrashe = 100;

    private void OnMouseUpAsButton()
    {
        TryCrash();
        Destroy(gameObject);
    }

    private void TryCrash()
    {
        int hundredPercent = 100;
        int degreeReduction = 2;

        int randomNumber = Random.Range(0, hundredPercent + 1);

        if (randomNumber >= _chanceCrashe)
        {
            Explode();
        }
        else
        {
            _chanceCrashe /= degreeReduction;   
            _spawnCubes.SpawnCube();
        }
    }

    private void Explode()
    {
        Instantiate(_effect, transform.position, transform.rotation);

        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            var explosionRadius = _explosionRadius / explodableObject.transform.localScale.x;
            var explosionForce = _explosionForce / explodableObject.transform.localScale.x;
            
            explodableObject.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
