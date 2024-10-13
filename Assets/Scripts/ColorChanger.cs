using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private void Start()
    {
        if (_renderer == false)
            return;
        
        _renderer.material.color = Random.ColorHSV();
    }
}
