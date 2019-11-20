using System.Collections.Generic;

namespace Assets.Code.Services
{
  public class GameIdentifierService : IIdentifierService
  {
    private readonly Dictionary<Identity, int> _identifiers = new Dictionary<Identity, int>();

    public int Next(Identity identity)
    {
      int last = _identifiers.ContainsKey(identity) ? _identifiers[identity] : 1;
      int next = ++last;

      _identifiers[identity] = next;

      return next;
    }
  }
}