namespace ANKU.Combats.Abstracts
{
    public interface IHealth
    {
        void TakeDamage(float damage);
        bool IsDead { get; }
    }
}
