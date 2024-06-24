using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public static class ExtensionMethods
    {
        /// <summary>
        ///  시리얼 포트를 ComboBox에 추가합니다. COMn...COMnn
        /// </summary>
        /// <param name="selectedText">선택할 텍스트</param>
        /// <returns></returns>
        public static T GetSerialPortNames<T>(this T @this, string selectedText = null) where T : ComboBox
        {
            @this.InvokeIfRequired(o =>
            {
                string[] ports = IO.Ports.SerialPort.GetPortNames();
                @this.Items.Clear();
                @this.Items.AddRange(ports);

                @this.SelectedItem = selectedText;

                if (@this.Items.Count == 1) @this.SelectedIndex = 0;
            });

            return @this;
        }
        /// <summary>
        /// 보드레이트를 ComboBox에 추가합니다.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selectedText"></param>
        /// <returns></returns>
        public static T GetSerialBPSs<T>(this T @this, string selectedText = null) where T : ComboBox
        {
            @this.InvokeIfRequired(o =>
            {
                string[] BaudRates = { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230000" };
                @this.Items.Clear();
                @this.Items.AddRange(BaudRates);

                foreach (var item in @this.Items)
                {
                    if (item.ToString() == selectedText)
                        @this.SelectedItem = item;
                }
                if (@this.Items.Count == 1) @this.SelectedIndex = 0;
            });

            return @this;
        }
        /// <summary>
        /// 콤보 박스 문자가 비어있으면 메시지 박스를 띄웁니다.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpaceToMessage(this ComboBox @this, string msg = null)
        {
            if (string.IsNullOrWhiteSpace(@this.Text))
            {
                MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                @this.Focus();
                return true;
            }
            else return false;
        }

        public static void AppendText<T>(this T @this, string str) where T : TextBoxBase
        {
            @this.InvokeIfRequired(o =>
            {
                @this.AppendText(str);
            });
        }
        public static void AppendText<T>(this T @this, string text, Color color) where T : RichTextBox
        {
            @this.InvokeIfRequired(o =>
            {
                @this.SelectionStart = @this.TextLength;
                @this.SelectionLength = 0;

                @this.SelectionColor = color;
                @this.AppendText(text);
                @this.SelectionColor = @this.ForeColor;
            });
        }

        public static void Text<T>(this T obj, string str) where T : Control
        {
            obj.InvokeIfRequired(o =>
            {
                obj.Text = str;
            });
        }

        /// <summary>
        /// 문자열이 Null이거나 비어있으면 기본값을 반환합니다.
        /// </summary>
        /// <typeparam name="T">컨트롤 형식</typeparam>
        /// <param name="this">컨트롤 객체</param>
        /// <param name="str">기본 텍스트</param>
        /// <returns></returns>
        public static T DefaultText<T>(this T @this, string str) where T : Control
        {
            if (string.IsNullOrEmpty(@this.Text)) @this.Text = str;
            return @this;
        }

        public static void Else<T>(this T @this, Action func) where T : IComparable
        {
            if ((bool)(object)@this != true)
            {
                func();
            }
        }

        #region Invoke
        public delegate void InvokeIfRequiredDelegate<T>(T obj) where T : ISynchronizeInvoke;
        public static void InvokeIfRequired<T>(this T @this, InvokeIfRequiredDelegate<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                try
                {
                    @this.Invoke(action, new object[] { @this });
                }
                catch
                {
                }
            }
            else
            {
                action(@this);
            }
        }
        /// <summary>
        /// UI Invoke 코드를 단순화합니다.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TOut InvokeIfRequired<TIn, TOut>(this TIn @this, Func<TIn, TOut> func)
            where TIn : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                try
                {
                    return (TOut)@this.Invoke(func, new object[] { @this });
                }
                catch
                {
                    return default;
                }
            }
            else
                return func(@this);
        }
        #endregion
    }
}