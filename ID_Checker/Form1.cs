using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ID_Checker
{
    public partial class ID_Checker : Form
    {
        public ID_Checker()
        {
            InitializeComponent();
        }
        private void btncheck_Click(object sender, EventArgs e)
        {
            string Message = "";

            if (!IFVaild(txtID.Text, out Message))
            {
                MessageBox.Show(Message);
            }
            else 
            {
                MessageBox.Show("此為有效身分證");
            }
        }
        private void btnRandomAdd_Click(object sender, EventArgs e)
        {
            string ID = CreateID();
            while (ID == "")
            {
                ID = CreateID();
            }

            txtID.Text = ID;
        }
        public bool IFVaild(string ID,out string Message)
        {
            Message = "";
            if (ID.Length<10)
            {
                Message = "格式錯誤，請確認應為10碼" + "\n" + "Error,Please check Length in  your input";
                return false;
            }
            char[] CharArray = ID.ToCharArray();
            //比對第一字元必須為英文
            if (!string.IsNullOrEmpty(ID))
            {
                if (Regex.IsMatch(CharArray[0].ToString(), "^[A-Z]"))
                {
                    bool IfAllNumber = true;
                    List<int> NumList = new List<int>(new int[10]);
                    for (int i = 1; i < CharArray.Count(); i++)
                    {
                        int CharToNumResult = 0;
                        IfAllNumber = IfAllNumber && int.TryParse(CharArray[i].ToString(), out CharToNumResult);
                        NumList[i] = CharToNumResult;
                        if (IfAllNumber == false)
                        {
                            Message = "格式錯誤，除第一碼外，皆為數字";
                            return false;
                        }
                    }

                    //第一個英文轉數字
                    int FirstEngToNum = 0;
                    Dictionary<int, string[]> DicEngToNum = lst_EngToNum();
                    for (int i = 0; i < DicEngToNum.Count(); i++)
                    {
                        if (DicEngToNum.ElementAt(i).Value.Any(x => x.Contains(CharArray[0].ToString())))
                        {
                            FirstEngToNum = DicEngToNum.ElementAt(i).Key;
                            NumList[0] = FirstEngToNum;
                        }
                    }

                    //驗證
                    //公式 [0]*1+[1]*8+[2]*7+[3]*6+[4]*5+[5]*4+[6]*3+[7]*2+[8]*1+[9]*1
                    bool IfVaildID = false;
                    int Total = 0;//計算總和
                    Total += NumList[0] * 1;
                    Total += NumList[1] * 8;
                    Total += NumList[2] * 7;
                    Total += NumList[3] * 6;
                    Total += NumList[4] * 5;
                    Total += NumList[5] * 4;
                    Total += NumList[6] * 3;
                    Total += NumList[7] * 2;
                    Total += NumList[8] * 1;
                    Total += NumList[9] * 1;
                    if (Total%10==0)
                    {
                        IfVaildID = true;
                        return true;
                    }
                    else
                    {
                        Message = "此身分證不正確";
                        return false;
                    }
                }
                else 
                {
                    Message = "格式錯誤，第一碼為大寫英文";
                    return false;
                }
            }
            else 
            {
                Message = "請輸入身分證或產生隨機身分證";
                return false;
            }

        }
        public string CreateID()
        {
            Random rnd = new Random();
            double RanDouble = rnd.NextDouble();
            double MaxNumber = 9999999999;
            double Result = 1 + (RanDouble * (MaxNumber));
            List<int> NumList = new List<int>(new int[10]);
            char[] Resultstring = new char[10];
            if (Result.ToString().IndexOf(".") > -1)
            {
                Resultstring = Result.ToString().Split('.')[0].ToCharArray();
            }
            else 
            {
                Resultstring = Result.ToString().ToCharArray();
            }
            
            for (int i = 0; i < Resultstring.Count(); i++)
            {
                NumList[i] = int.Parse(Resultstring.ElementAt(i).ToString());
            }

            //驗證
            //公式 [0]*1+[1]*8+[2]*7+[3]*6+[4]*5+[5]*4+[6]*3+[7]*2+[8]*1+[9]*1
            bool IfVaildID = false;
            int Total = 0;//計算總和
            Total += NumList[0] * 1;
            Total += NumList[1] * 8;
            Total += NumList[2] * 7;
            Total += NumList[3] * 6;
            Total += NumList[4] * 5;
            Total += NumList[5] * 4;
            Total += NumList[6] * 3;
            Total += NumList[7] * 2;
            Total += NumList[8] * 1;
            Total += NumList[9] * 1;
            if (Total % 10 == 0)
            {
                IfVaildID = true;
                Dictionary<int, string[]> DicEngToNum = lst_EngToNum();

                var KeyPairNumToEng = DicEngToNum.Where(x => x.Key == NumList[0]).FirstOrDefault();
                //取得數字量
                int EngCount = KeyPairNumToEng.Value.Count();

                //隨機取一個數字轉換為英文
                Random rdm = new Random();
                int rdmNum = rdm.Next(1, EngCount);
                string FirstEng = KeyPairNumToEng.Value.ElementAt(rdmNum - 1);
                //取代第一個char
                string TargetString = Result.ToString().Split('.')[0];
                StringBuilder sb = new StringBuilder(TargetString);
                sb[0] = FirstEng.ToCharArray()[0];
                TargetString = sb.ToString();
                return TargetString;
            }
            else 
            {
                return "";
            }
        }

        /// <summary>
        /// 英文第一碼對照數字
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string[]> lst_EngToNum()
        {
            Dictionary<int, string[]> Result = new Dictionary<int, string[]>()
            {
                {0,new string[] {"B","N","Z"} },
                {1,new string[] {"A","M","W"} },
                {2,new string[] {"K","L","Y"} },
                {3,new string[] {"J","V","X"} },
                {4,new string[] {"H","U"} },
                {5,new string[] {"G","T"} },
                {6,new string[] {"F","S"} },
                {7,new string[] {"E","R"} },
                {8,new string[] {"D","O","Q"} },
                {9,new string[] {"C","I","P"} },
            };


            return Result;
        }
    }
}
