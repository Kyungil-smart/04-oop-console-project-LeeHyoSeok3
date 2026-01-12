public class UIModel
{
    public int Score { get; set; }
    public int Level  { get; private set; }
    public int ClearCount  { get; set; }
    public int Limit { get; private set; } = 1;


    public void SumScore(int value)
    {
        ClearCount += value;
        Score += 100 * (value * value);
    }

    public void LevelScaling(ref double fallInterval)
    {
        if (ClearCount >= Limit)
        {
            Level++;
            Limit += Limit;
            
            fallInterval = Math.Clamp(fallInterval -= 0.1d, 0.1d, 1d);
        }
    }
}