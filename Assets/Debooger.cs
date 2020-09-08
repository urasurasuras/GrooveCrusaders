namespace Debooger
{
    public class Debooger
    {
        public void Deboog(string key, object value)
        {
            if (!DebugManager.Instance) return;
            DebugManager.Instance.Deboog(key, value);
        }
    }
}