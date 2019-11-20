using Assets.Code.Behaviours;
using Assets.Code.Infrastructure;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  [CustomEditor(typeof(SpriteFX))]
  public class SpriteFXEditor : UnityEditor.Editor
  {
    private Sprite _initialSprite;

    public override void OnInspectorGUI()
    {
      DrawDefaultInspector();

      var spriteFx = (SpriteFX)target;
      if (GUILayout.Button("Play"))
      {
        _initialSprite = spriteFx.SpriteRenderer.sprite;
        spriteFx.Play(() => RestoreInitialSprite(spriteFx));
      }

      if (GUILayout.Button("Play with children"))
      {
        _initialSprite = spriteFx.SpriteRenderer.sprite;
        spriteFx.PlayWithChildren(() => RestoreInitialSprite(spriteFx));
      }

      if (GUILayout.Button("Stop")) 
        spriteFx.StopLoopingWithChildren();
    }

    private void RestoreInitialSprite(SpriteFX spriteFx)
    {
      if (_initialSprite != null)
        spriteFx.SpriteRenderer.sprite = _initialSprite;
    }
  }
}