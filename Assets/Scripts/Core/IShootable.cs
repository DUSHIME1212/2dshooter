// Defines the interface for objects that can fire projectiles and reload, enabling consistent shooting behavior for weapons and entities.

public interface IShootable
{
    void Fire();
    void Reload();
}