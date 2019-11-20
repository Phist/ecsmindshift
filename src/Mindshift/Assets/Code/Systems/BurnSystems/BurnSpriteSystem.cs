using System.Collections.Generic;
using Assets.Code.Extensions;
using Entitas;
using UnityEngine;

namespace Assets.Code.Systems.Gameplay
{
  public class BurnSpriteSystem : ReactiveSystem<GameEntity>
  {
    private const string BurnParticlesPrefabPath = "fx/fire/burnContainer";
    private const float SmallObjectSize = 8.5f;
    private const float AdditionalFlamesYAdjustment = 0.25f;
    public static readonly Color BurnColor = new Color32(255, 110, 50, 255);

    private readonly GameObject _burnParticlesPref;

    public BurnSpriteSystem(GameContext game) : base(game)
    {
      _burnParticlesPref = Resources.Load<GameObject>(BurnParticlesPrefabPath);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Burning.Added());

    protected override bool Filter(GameEntity entity) => entity.isBurning && entity.hasSpriteRenderer && entity.hasPolygonCollider2D;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity entity in entities)
      {
        entity.SpriteRenderer.color = BurnColor;

        SpawnBurnParticles(entity.PolygonCollider2D.transform, at: Vector3.zero);

        if (entity.PolygonCollider2D.bounds.size.sqrMagnitude > SmallObjectSize && entity.hasPolygonCollider2D) 
          SpawnAdditionalFlames(entity.PolygonCollider2D);
      }
    }

    private void SpawnAdditionalFlames(PolygonCollider2D polygonCollider)
    {
      float spawnsCount = polygonCollider.bounds.size.sqrMagnitude / SmallObjectSize + 1;
      for (int i = 0; i < spawnsCount; i++)
        SpawnBurnParticles(polygonCollider.transform, at: polygonCollider.points.PickRandom(), AdditionalFlamesYAdjustment);
    }

    private void SpawnBurnParticles(Transform parent, Vector3 at, float yAdjustment = 0) =>
      Object
        .Instantiate(_burnParticlesPref, parent)
        .With(x => x.transform.localPosition = at.AddY(yAdjustment));
  }
}