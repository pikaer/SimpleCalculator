using System;
using System.Windows.Forms;

/// <summary>
/// 简易计算器
/// </summary>
namespace SimpleCalculator
{
    public partial class MainForm : Form
    {
        //当前操作键
        CurrentOperation currentOperation;

        //第一次按下的值
        string firstNumTxt;

        //第二次按下的值
        string secondNumTxt;

        //第一次按下的值是否可清除
        bool canClearfirstNum ;

        /// <summary>
        /// 初始化值
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 计算
        /// </summary>
        public void Calculator()
        {

            if (currentOperation == CurrentOperation.Default|| secondNumTxt=="")
            {
                return;
            }

            string txtShowValue = "";
            double firstNum = Convert.ToDouble(firstNumTxt);
            double secondNum = Convert.ToDouble(secondNumTxt);

            switch (currentOperation)
            {
                case CurrentOperation.Jia:
                    txtShowValue = (firstNum + secondNum).ToString();
                    break;
                case CurrentOperation.Jian:
                    txtShowValue = (firstNum - secondNum).ToString();
                    break;
                case CurrentOperation.Cheng:
                    txtShowValue = (firstNum * secondNum).ToString();
                    break;
                case CurrentOperation.Chu:
                    if (secondNum != 0)
                    {
                        txtShowValue = (firstNum / secondNum).ToString();
                    }
                    else
                    {
                        MessageBox.Show("除数不能为0！");
                    }
                    break;
                default:
                    break;
            }

            txtShow.Text = txtShowValue;

            //操作键初始化
            firstNumTxt = txtShowValue;
            secondNumTxt = "";
            currentOperation = CurrentOperation.Default;
            canClearfirstNum = true;
        }
        
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            firstNumTxt = "";
            secondNumTxt = "";
            currentOperation = CurrentOperation.Default;
            txtShow.Text = "";
        }

        /// <summary>
        /// 按下数字按钮后追加到文本末尾
        /// </summary>
        /// <param name="num">数字键</param>
        public void SetNum(CurrentNum num)
        {
            string txt;

            //如果当前没有按加减乘除键，即是将数字追加到第一个值
            if (currentOperation == CurrentOperation.Default)
            {
                if(canClearfirstNum)
                {
                    firstNumTxt = "";
                    canClearfirstNum = false;
                }

                txt = SetNumValue(num, firstNumTxt.ToString());
                firstNumTxt = txt;
            }
            else
            {
                txt = SetNumValue(num, secondNumTxt.ToString());
                secondNumTxt = txt;
            }
            txtShow.Text = txt;
        }

        /// <summary>
        /// 追加到文本末尾
        /// </summary>
        /// <param name="num">数字键</param>
        /// <param name="txt">当前文本值</param>
        /// <returns></returns>
        public string SetNumValue(CurrentNum num, string txt)
        {
            if ((txt == "0" && num == CurrentNum.Num0) ||
                (txt == "" && num == CurrentNum.Point) ||
                (txt.Contains(".") && num == CurrentNum.Point))
            {
                return txt;
            }

            if (num == CurrentNum.Point)
            {
                txt += ".";
            }
            else
            {
                //将数字键对应的值追加到文本上
                txt += (int)num;
            }

            if (txt!= "0" && txt != "0." &&Convert.ToDouble(txt) >1)
            {
                txt= txt.TrimStart('0').ToString();
            }
            return txt;
        }

        #region 按钮点击事件

        #region 数字按钮单击事件
        private void btn0_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num0);
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num1);
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num2);
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num3);
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num4);
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num5);
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num6);
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num7);
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num8);
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Num9);
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            SetNum(CurrentNum.Point);
        }
        #endregion

        #region 操作按钮单机事件

        private void btnJia_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtShow.Text))
            {
                currentOperation = CurrentOperation.Jia;
            }
        }

        private void btnJian_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtShow.Text))
            {
                currentOperation = CurrentOperation.Jian;
            }
        }

        private void btnCheng_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtShow.Text))
            {
                currentOperation = CurrentOperation.Cheng;
            }
        }

        private void btnChu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtShow.Text))
            {
                currentOperation = CurrentOperation.Chu;
            }
        }

        /// <summary>
        /// 归零(初始化）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCE_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void btnDeng_Click(object sender, EventArgs e)
        {
            Calculator();
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// 当前操作枚举
    /// </summary>
    public enum CurrentOperation
    {
        /// <summary>
        /// 加(+)
        /// </summary>
        Jia=1,

        /// <summary>
        /// 减(-)
        /// </summary>
        Jian=2,

        /// <summary>
        /// 乘(*)
        /// </summary>
        Cheng=3,

        /// <summary>
        /// 除(/)
        /// </summary>
        Chu=4,
        
        /// <summary>
        /// 默认初始状态
        /// </summary>
        Default=5
    }

    /// <summary>
    /// 当前按下的数字键枚举
    /// </summary>
    public enum CurrentNum
    {
        /// <summary>
        /// 数字0
        /// </summary>
        Num0=0,

        /// <summary>
        /// 数字1
        /// </summary>
        Num1=1,

        /// <summary>
        /// 数字2
        /// </summary>
        Num2=2,

        /// <summary>
        /// 数字3
        /// </summary>
        Num3=3,

        /// <summary>
        /// 数字4
        /// </summary>
        Num4=4,

        /// <summary>
        /// 数字5
        /// </summary>
        Num5=5,

        /// <summary>
        /// 数字6
        /// </summary>
        Num6=6,

        /// <summary>
        /// 数字7
        /// </summary>
        Num7=7,

        /// <summary>
        /// 数字8
        /// </summary>
        Num8=8,

        /// <summary>
        /// 数字9
        /// </summary>
        Num9=9,

        /// <summary>
        /// 小数点
        /// </summary>
        Point=10,
    }
}
