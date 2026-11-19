using System;

internal class Time
{
    private const int MinutesInHour = 60;
    private const int HoursInDay = 24;
    private const int MaxHour = 23;
    private const int MaxMinute = 59;
    private const int MinutesInDay =
        MinutesInHour * HoursInDay;

    private byte _hours;
    private byte _minutes;

    public byte Hours
    {
        get { return _hours; }
        set
        {
            if (value > MaxHour)
            {
                throw new ArgumentException(
                    "Часы от 0 до 23.");
            }
            _hours = value;
        }
    }

    public byte Minutes
    {
        get { return _minutes; }
        set
        {
            if (value > MaxMinute)
            {
                throw new ArgumentException(
                    "Минуты от 0 до 59.");
            }
            _minutes = value;
        }
    }

    public Time()
    {
        _hours = 0;
        _minutes = 0;
    }

    public Time(byte hours, byte minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public override string ToString()
    {
        return $"{_hours:D2}:{_minutes:D2}";
    }

    public Time SubtractTime(Time other)
    {
        int thisTotal = _hours * MinutesInHour
            + _minutes;
        int otherTotal = other._hours * MinutesInHour
            + other._minutes;
        int diff = thisTotal - otherTotal;

        if (diff < 0)
        {
            diff = MinutesInDay
                + (diff % MinutesInDay);
        }

        byte h = (byte)(
            (diff / MinutesInHour) % HoursInDay);
        byte m = (byte)(diff % MinutesInHour);
        return new Time(h, m);
    }

    public static Time operator --(Time t)
    {
        int total = t._hours * MinutesInHour
            + t._minutes - 1;

        if (total < 0)
        {
            total = MinutesInDay - 1;
        }

        byte h = (byte)(
            (total / MinutesInHour) % HoursInDay);
        byte m = (byte)(total % MinutesInHour);
        return new Time(h, m);
    }

    public static explicit operator byte(Time t)
    {
        return t._hours;
    }

    public static implicit operator bool(Time t)
    {
        return t._hours != 0 || t._minutes != 0;
    }

    public static Time operator +(
        Time t, uint minutes)
    {
        int total = t._hours * MinutesInHour
            + t._minutes + (int)minutes;
        int norm = total % MinutesInDay;

        byte h = (byte)(norm / MinutesInHour);
        byte m = (byte)(norm % MinutesInHour);
        return new Time(h, m);
    }

    public static Time operator +(
        uint minutes, Time t)
    {
        return t + minutes;
    }

    public static Time operator +(
        Time t1, Time t2)
    {
        int total = t1._hours * MinutesInHour
            + t1._minutes
            + t2._hours * MinutesInHour
            + t2._minutes;
        int norm = total % MinutesInDay;

        byte h = (byte)(norm / MinutesInHour);
        byte m = (byte)(norm % MinutesInHour);
        return new Time(h, m);
    }
}