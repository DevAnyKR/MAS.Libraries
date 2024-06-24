namespace System
{
	public static class Extension
    {
		/// <summary>
		/// Data Map
		/// </summary>
		/// <remarks>Arduino 의 Map 명령과 동일 합니다</remarks>
		/// <returns>Double</returns>
		public static double Map(this double x, int in_min, int in_max, int out_min, int out_max)
		{
			return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
		}

	}
}
