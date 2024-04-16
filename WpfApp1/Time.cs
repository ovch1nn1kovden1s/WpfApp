class Time
{
    // ����
    private byte hours;
    private byte minutes;
    public byte Hours { get { return hours; } }
    public byte Minutes { get { return minutes; } }

    // ����������� ������
    public Time(byte hours, byte minutes)
    {
        // �������� �������� ������ 
        if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
        {
            // ������ ����������
            throw new ArgumentException("������������ �����.");
        }

        this.hours = hours;
        this.minutes = minutes;
    }

    // ��������� ������� Time �� �������
    public Time SubTime(Time otherTime)
    {
        // �������������� � ������
        int minValue1 = hours * 60 + minutes;
        int minValue2 = otherTime.hours * 60 + otherTime.minutes;

        // ������� ����� ���������
        int difference = minValue1 - minValue2;

        // �������� ������ �� �� ���������� ����
        if (difference < 0)
        {
            difference += 24 * 60;
        }

        // ���������� ����� � �����
        byte resualtHours = (byte)(difference / 60);
        byte resualtMinutes = (byte)(difference % 60);

        // ���������� ���������
        return new Time(resualtHours, resualtMinutes);
    }

    // ���������� ��������� ++
    public static Time operator ++(Time time)
    {
        time.AddMinute(1);
        return time;
    }

    private Time AddMinute(int value)
    {
        // ������� � ������
        int totalMin = hours * 60 + minutes + value;

        if (totalMin >= 1440)
        {
            totalMin = totalMin - 1440;
        }
        // ��������� �������
        hours = (byte)(totalMin / 60);
        minutes = (byte)(totalMin % 60);

        return this;
    }

    // ��������� ��������� --
    public static Time operator --(Time time)
    {
        time.SubMinute(1);
        return time;
    }

    private Time SubMinute(int value)
    {
        // ������� � ������
        int totalMin = hours * 60 + minutes - value;
        if (totalMin < 0)
        {
            totalMin = totalMin + 1440;
        }
        // ��������� �������
        hours = (byte)(totalMin / 60);
        minutes = (byte)(totalMin % 60);

        return this;
    }

    // ���������� ��������� int (implicit - �������)
    public static implicit operator int(Time time)
    {
        return time.hours * 60 + time.minutes;
    }

    // ���������� ��������� bool (explicit - �����)
    public static explicit operator bool(Time time)
    {
        return time.minutes != 0 & time.hours != 0;
    }

    // ���������� ��������� <
    public static bool operator <(Time time1, Time time2)
    {
        return time1.ToMin() < time2.ToMin();
    }

    // ���������� ��������� >
    public static bool operator >(Time time1, Time time2)
    {
        return time1.ToMin() > time2.ToMin();
    }

    private int ToMin()
    {
        return hours * 60 + minutes;
    }

    // ���������� ToString()
    public override string ToString()
    {
        return $"����: {hours}, ������: {minutes}";
    }
}