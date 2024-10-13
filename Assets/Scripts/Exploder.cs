using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Transform positionExplode)
    {
        Instantiate(_effect, positionExplode.position, positionExplode.rotation);

        foreach (Rigidbody explodableObject in GetExplodableObjects(positionExplode.position))
        {
            var explosionRadius = _explosionRadius / explodableObject.transform.localScale.x;
            var explosionForce = _explosionForce / explodableObject.transform.localScale.x;
            
            explodableObject.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
