namespace FindObjectQuest
{
    public class BallObject : DefaultObjectFind
    {
        public void PickUp()
        {
            _playerQuest.PickUp<BallObject>();
            Destroy(gameObject);
        }
    }
}