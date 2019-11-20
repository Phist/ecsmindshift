using TMPro;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
  public class Fade : MonoBehaviour
  {
    public AnimationCurve Alpha;
    public TextMeshProUGUI Text;
    public CanvasGroup CanvasGroup;

    private float _awakeTime;

    private void Awake()
    {
      if (Text == null && CanvasGroup == null)
        Debug.LogError($"Text or CanvasGroup are not set {gameObject.name}");

      _awakeTime = Time.time;
    }

    public void Update()
    {
      var alpha = Alpha.Evaluate(Time.time - _awakeTime);
      
      if (Text != null)
        Text.alpha = alpha;
      if (CanvasGroup != null)
        CanvasGroup.alpha = alpha;
    }
  }
}