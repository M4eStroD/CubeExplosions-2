using UnityEngine;

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private Exploder _explodeCube;
    [SerializeField] private Renderer _renderer;

    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 5;

    private Cube _cube;

    public void Initialize(Cube cube)
    {
        _cube = cube;
        SpawnCube();
    }

    private void SpawnCube()
    {
        int randomCount = Random.Range(_minCubes, _maxCubes + 1);

        for (int i = 0; i < randomCount; i++)
        {
            GenerateCube();
        }
    }

    private void GenerateCube()
    {
        int degreeReduction = 2;
        
        float offsetMin = -0.5f;
        float offsetMax = 1.5f;

        int degreeScale = 2;

        Vector3 position = new Vector3(
            Random.Range(offsetMin, offsetMax),
            Random.Range(offsetMin, offsetMax),
            Random.Range(offsetMin, offsetMax));

        position = transform.TransformPoint(transform.position);

        Cube cube = Instantiate(_cube, position, transform.rotation);

        cube.Initialize(_cube.CrashChance/degreeReduction);
        cube.transform.localScale = transform.localScale / degreeScale;
    }
}
