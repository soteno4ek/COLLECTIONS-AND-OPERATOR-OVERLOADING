using System;

internal class Circle
{
    private double _radius;

    public double Radius
    {
        get { return _radius; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Радиус не может быть < 0.");
            }
            _radius = value;
        }
    }

    public Circle()
    {
        _radius = 0;
    }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override string ToString()
    {
        return $"Circle(r={_radius})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Circle other)
        {
            return _radius == other._radius;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _radius.GetHashCode();
    }
}