using UnityEngine;

public class Treadmill : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed1 = 1;
    [SerializeField] private Renderer _renderer;

    private void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(0f, _scrollSpeed1 * Time.deltaTime);
    }
}
