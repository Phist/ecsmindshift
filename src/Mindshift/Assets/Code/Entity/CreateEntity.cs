using System.Linq;
using Assets.Code.Extensions;
using Entitas;
using UnityEngine;

namespace Assets.Code.Entity
{
  public static class CreateEntity
  {
    public static GameEntity Empty() =>
      Contexts.sharedInstance.game.CreateEntity();

    public static TEntity Duplicate<TEntity>(this TEntity entity) where TEntity : class, IEntity
    {
      TEntity duplicate = entity.Context().CreateEntity();
      entity.CopyTo(duplicate);

      return duplicate;
    }

    public static IContext<TEntity> Context<TEntity>(this TEntity entity) where TEntity : class, IEntity =>
      Contexts.sharedInstance.allContexts
      .FirstOrDefault(c => entity.contextInfo.name == c.contextInfo.name) as IContext<TEntity>;
  }
}
