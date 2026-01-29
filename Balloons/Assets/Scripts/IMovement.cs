using System.Collections;

public interface IMovement
{
    public void Start();
    public IEnumerator GoToTarget();
}
