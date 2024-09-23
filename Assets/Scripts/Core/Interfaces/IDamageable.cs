public interface IDamageable
{
    int HealthMax { get; }
    int ShieldMax { get; }
    bool IsAlive { get; }

    float HealthPercentage { get; }
    void TakeDamage(int damage);
}