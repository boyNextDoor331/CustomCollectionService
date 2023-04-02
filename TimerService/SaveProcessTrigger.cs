using TimerService;

public class SaveProcessTrigger
{
    private DateTime _startTime;
    private DateTime _nextTime;
    private UnitOfMeasure _unitOfMeasure;
    private int _interval;

    public DateTime NextIterationTime => _nextTime;

    public SaveProcessTrigger()
    {
        _startTime = DateTime.Now;
        _unitOfMeasure = UnitOfMeasure.MINUTES;
        _interval = 10;
        CalculateNextTime();
    }

    public void CalculateNextTime()
    {
        _nextTime = DateTime.Now;
        if(_unitOfMeasure == UnitOfMeasure.SECONDS)
        {
            _nextTime = _startTime.AddSeconds(_interval);
        }
        else
        {
            _nextTime = _startTime.AddMinutes(_interval);
        }
    }
}