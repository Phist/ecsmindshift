using UnityEngine;

namespace Assets.Code.Infrastructure
{
  public class OffsetTextureOverTime : MonoBehaviour
  {
    public SpriteRenderer Renderer;
    public float Speed = 0.5f;

    private const string MainTexStringParam = "_MainTex";
    private readonly int _mainTexParam = Shader.PropertyToID(MainTexStringParam);

    private void Update()
    {
      float offset = Time.time * Speed / 10;
      Renderer.material.SetTextureOffset(_mainTexParam, new Vector2(offset, 0));
    }
  }
}
