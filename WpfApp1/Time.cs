class Time
{
    // поля
    private byte hours;
    private byte minutes;
    public byte Hours { get { return hours; } }
    public byte Minutes { get { return minutes; } }

    // конструктор класса
    public Time(byte hours, byte minutes)
    {
        // проверка введеных данных 
        if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
        {
            // выброс исключения
            throw new ArgumentException("Некорректное время.");
        }

        this.hours = hours;
        this.minutes = minutes;
    }

    // вычитание объекта Time из другого
    public Time SubTime(Time otherTime)
    {
        // преобразование в минуты
        int minValue1 = hours * 60 + minutes;
        int minValue2 = otherTime.hours * 60 + otherTime.minutes;

        // разница между миинутами
        int difference = minValue1 - minValue2;

        // проверка уходит ли на предыдущий день
        if (difference < 0)
        {
            difference += 24 * 60;
        }

        // вычесление часов и минут
        byte resualtHours = (byte)(difference / 60);
        byte resualtMinutes = (byte)(difference % 60);

        // возвращаем результат
        return new Time(resualtHours, resualtMinutes);
    }

    // перегрузка оператора ++
    public static Time operator ++(Time time)
    {
        time.AddMinute(1);
        return time;
    }

    private Time AddMinute(int value)
    {
        // перевод в минуты
        int totalMin = hours * 60 + minutes + value;

        if (totalMin >= 1440)
        {
            totalMin = totalMin - 1440;
        }
        // переводим обратно
        hours = (byte)(totalMin / 60);
        minutes = (byte)(totalMin % 60);

        return this;
    }

    // прегрузка оператора --
    public static Time operator --(Time time)
    {
        time.SubMinute(1);
        return time;
    }

    private Time SubMinute(int value)
    {
        // перевод в минуты
        int totalMin = hours * 60 + minutes - value;
        if (totalMin < 0)
        {
            totalMin = totalMin + 1440;
        }
        // переводим обратно
        hours = (byte)(totalMin / 60);
        minutes = (byte)(totalMin % 60);

        return this;
    }

    // перегрузка оператора int (implicit - неявное)
    public static implicit operator int(Time time)
    {
        return time.hours * 60 + time.minutes;
    }

    // перегрузка оператора bool (explicit - явное)
    public static explicit operator bool(Time time)
    {
        return time.minutes != 0 & time.hours != 0;
    }

    // перегрузка оператора <
    public static bool operator <(Time time1, Time time2)
    {
        return time1.ToMin() < time2.ToMin();
    }

    // перегрузка оператора >
    public static bool operator >(Time time1, Time time2)
    {
        return time1.ToMin() > time2.ToMin();
    }

    private int ToMin()
    {
        return hours * 60 + minutes;
    }

    // перегрузка ToString()
    public override string ToString()
    {
        return $"Часы: {hours}, Минуты: {minutes}";
    }
}