using System;

[Serializable]
public struct Rifle
{
    public RifleType type;
    public RifleData data;
    public void SetRifleData(RifleData Data)
    {
        data = Data;
    }
}

[Serializable]
public struct RifleData
{
    public int ammo;
    public RifleMode rifleMode;
    public float fireRate;
}

[Serializable]
public enum RifleType
{
    M4
}
[Serializable]
public enum RifleMode
{
    Auto,
    SemiAuto
}
