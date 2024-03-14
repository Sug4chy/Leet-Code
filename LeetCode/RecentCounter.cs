namespace LeetCode;

//933
public class RecentCounter
{
    private readonly Queue<int> _requests;
    
    public RecentCounter()
    {
        _requests = new Queue<int>();
    }

    public int Ping(int t)
    {
        _requests.Enqueue(t);
        while (_requests.Peek() < t - 3000)
        {
            _requests.Dequeue();
        }

        return _requests.Count;
    }
}