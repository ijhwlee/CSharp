namespace AIConvergence.Shared;

public struct DisplacementVector
{
  public int x;
  public int y;
  public DisplacementVector(int x, int y)
  {
    this.x = x;
    this.y = y;
  }
  public static DisplacementVector operator +(
    DisplacementVector v1, DisplacementVector v2)
  {
    return new(
      v1.x + v2.x,
      v1.y + v2.y);
  }
}