namespace System.Drawing
{
	public static partial class Extension
	{
		/// <summary>
		/// 문자출력
		/// </summary>
		/// <remarks>GDI 그래픽의 String 출력명령에  정렬기능을 추가함</remarks>
		static void DrawString(Graphics g,
					Font font,
					Color fColor,
					string data,
					Rectangle rect,
					StringAlignment salign = StringAlignment.Center,
					StringAlignment lAlign = StringAlignment.Center)
		{
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = salign;
			stringFormat.LineAlignment = lAlign;
			g.DrawString(data, font, new SolidBrush(fColor), rect, stringFormat);
		}
	}
}

