namespace Assets.Code.Services
{
  public interface IRegisterService<T>
  {
    T Register(int key, T @object);
    void Unregister(int key, T @object);
    T Take(int key);
  }
}