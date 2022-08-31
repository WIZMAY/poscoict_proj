using System;
using System.Data;
using System.Drawing;
using System.Xml;
using System.IO;
using ZXing;
using CoreScanner;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Net.Sockets;
using MySql.Data.MySqlClient;

namespace real_poscoict
{
    public partial class BarcodeHmi : Form
    {
        CCoreScannerClass m_pCoreScanner;   // 바코드 스캐너 클래스

        // table 객체 생성
        System.Data.DataTable table1_1 = new System.Data.DataTable(),
                                          table1_2 = new System.Data.DataTable(),
                                          table3_1 = new System.Data.DataTable(),
                                          table4_1 = new System.Data.DataTable();
        List<string> table1_1_col = new List<string>(),
                         table1_2_col = new List<string>(),
                         table3_1_col = new List<string>(),
                         table4_1_col = new List<string>();
        // tcpip
        StreamReader streamReader1;
        StreamWriter streamWriter1;
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=poscoictproj;Uid=root;Pwd=sjsj1411;Charset=utf8");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string sql = "";
        public BarcodeHmi()
        {
            InitializeComponent();
            ComponentSetting();
            MySQLSetting();
            try
            {
                connection.Open();
                sql = "TRUNCATE ins_order_list_c;" + "TRUNCATE ins_order_c;" + "TRUNCATE scanned_list;"+
                        "INSERT INTO ins_order_list_c (SELECT * FROM ins_order_list);"+"INSERT INTO ins_order_c (SELECT * FROM ins_order);";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            try
            {                
                setTable1_1();
                string insNum = getInsNum();
                setTable1_2(insNum);
                setTable3_1(insNum);
                setTable4_1(insNum);
            }
            catch (Exception)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 바코드 스캐너 정보 로드
            #region
            try
            {
                m_pCoreScanner = new CoreScanner.CCoreScannerClass();

                // Call Open API
                short[] scannerTypes = new short[1];//scannertypes you selected
                scannerTypes[0] = 1;
                short numberOfScannerType = 1;
                int status;
                m_pCoreScanner.Open(0, scannerTypes, numberOfScannerType, out status);
                m_pCoreScanner.BarcodeEvent += new CoreScanner._ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);
                // Subscribe for events
                int opcode = 1001; //subscribe events method
                string outXML;
                string inXML = "<inArgs>" +
                                    "<cmdArgs>" +
                                     "<arg-int>1</arg-int>" +
                                     "<arg-int>1</arg-int>" +
                                    "</cmdArgs>" +
                                    "</inArgs>";
                m_pCoreScanner.ExecCommand(opcode, ref inXML, out outXML, out status);

            }
            catch (Exception ex)
            {

            }
            #endregion
        }
        /// *************** 설정 함수
        private void MySQLSetting()
        {
            table1_1_col.Add("작업지시");
            table1_1_col.Add("진행상태");

            table1_2_col.Add("자재코드");
            table1_2_col.Add( "자재명");
            table1_2_col.Add( "지시중량");
            table1_2_col.Add( "투입중량");
            table1_2_col.Add( "진행상태"); 

            table3_1_col.Add("LOT NO.");
            table3_1_col.Add("자재코드");
            table3_1_col.Add("자재명");
            table3_1_col.Add("포장중량");
            table3_1_col.Add("가용중량");

            table4_1_col = table3_1_col;    // scanned_list와 조회 페이지가 같으므로..
        }
        private void ComponentSetting()// 각 컴포넌트의 세팅
        {
            foreach (Control all in tabControl1.Controls)
            {
                if (all is TabPage)
                {
                    TabPage tc = (TabPage)all;
                    foreach (Control cc in tc.Controls)
                    {
                        if (cc is System.Windows.Forms.GroupBox)
                        {
                            System.Windows.Forms.GroupBox gb = (System.Windows.Forms.GroupBox)cc;
                            foreach (Control control in gb.Controls)
                            {
                                if (control is DataGridView)
                                {
                                    DataGridView dgview = (DataGridView)control;

                                    dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                    dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                    dgview.AllowUserToAddRows = false;
                                    dgview.RowHeadersVisible = false;
                                    dgview.ReadOnly = true;
                                    dgview.AllowUserToAddRows = false;
                                    dgview.AllowUserToDeleteRows = false;
                                    dgview.AllowUserToOrderColumns = true;
                                    dgview.AllowUserToResizeColumns = false;
                                    dgview.AllowUserToResizeRows = false;
                                }
                            }
                        }
                    }
                }
            }
            foreach (Control control in groupBox2.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pic = (PictureBox)control;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            group2LotnotextBox.ReadOnly = true;
        }
        /// *************** 기능 함수
        private string getInsNum()//현재 선택된 작업지시번호 get
        {
            try
            {
                if (group1datagrid1.CurrentCell == null)
                {
                    group1datagrid1.CurrentCell = group1datagrid1.Rows[0].Cells[0];
                }
            }
            catch
            {
            }
            string insNum = Convert.ToString(group1datagrid1.Rows[group1datagrid1.CurrentCell.RowIndex].Cells[0].Value);
            return insNum;
        }
        private void setTable1_1()//db의 작업지시목록을 table1_1에 불러온다
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                table1_1 = new System.Data.DataTable();
                sql = "SELECT * FROM ins_order_list_c;";
                cmd = new MySqlCommand(sql, connection);
                da = new MySqlDataAdapter(cmd);
                da.Fill(table1_1);

                for (int i = 0; i < table1_1_col.Count; i++)
                {
                    table1_1.Columns[i].ColumnName = table1_1_col[i];
                }
                group1datagrid1.DataSource = table1_1;
                connection.Close();
            }
            catch
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void setTable1_2(string insNum)//db의 투입해야할 자재목록을 table1_2에 불러온다
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                table1_2 = new System.Data.DataTable();
                sql = "SELECT mat_code, mat_name, insert_wgt, avl_wgt, state FROM ins_order_c WHERE ins_num='" + insNum + "';";
                cmd = new MySqlCommand(sql, connection);
                da = new MySqlDataAdapter(cmd);
                da.Fill(table1_2);

                for (int i = 0; i < table1_2_col.Count; i++)
                {
                    table1_2.Columns[i].ColumnName = table1_2_col[i];
                }
                group1datagrid2.DataSource = table1_2;
                connection.Close();

                for (int i = 0; i < group1datagrid2.Rows.Count; i++)
                {
                    if (Convert.ToString(group1datagrid2.Rows[i].Cells[0].Value) == mat_code_textBox.Text)
                    {
                        group1datagrid2.CurrentCell = group1datagrid2.Rows[i].Cells[0];
                    }
                }
            }
            catch
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void setTable3_1(string insNum)//db의 투입한 자재 목록을 table3_1에 불러온다
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                table3_1 = new System.Data.DataTable();
                sql = "SELECT lot_no, mat_code, mat_name, input_wgt, avl_wgt FROM scanned_list WHERE ins_num='" + insNum + "';";
                cmd = new MySqlCommand(sql, connection);  // ins_num을 제외한 나머지 스키마 selcet
                da = new MySqlDataAdapter(cmd);
                da.Fill(table3_1);

                for (int i = 0; i < table3_1_col.Count; i++)
                {
                    table3_1.Columns[i].ColumnName = table3_1_col[i];
                }
                group3datagrid1.DataSource = table3_1;
                connection.Close();

                if (group3datagrid1.Rows.Count > 0)
                {
                    group3datagrid1.CurrentCell = group3datagrid1.Rows[group3datagrid1.RowCount - 1].Cells[0];
                }
            }
            catch
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void setTable4_1(string insNum)//입력한 작업지시번호에 따른 투입한 자재 목록을 table4_1에 불러온다
        {
            try
            {

                if (connection != null && connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                table4_1 = new System.Data.DataTable();
                sql = "SELECT lot_no, mat_code, mat_name, input_wgt, avl_wgt FROM scanned_list WHERE ins_num='" + insNum + "';";
                cmd = new MySqlCommand(sql, connection);
                da = new MySqlDataAdapter(cmd);
                da.Fill(table4_1);

                for (int i = 0; i < table4_1_col.Count; i++)
                {
                    table4_1.Columns[i].ColumnName = table4_1_col[i];
                }
                group4datagrid1.DataSource = table4_1;
                connection.Close();
            }
            catch
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private string GetBarcodeLotNo(XmlDocument xmlDoc, string pscanData)// 읽어들인 바코드에서 바코드 번호(Lot no)를 추출
        {
            string strData = String.Empty;
            string barcode = xmlDoc.DocumentElement.GetElementsByTagName("datalabel").Item(0).InnerText;
            string symbology = xmlDoc.DocumentElement.GetElementsByTagName("datatype").Item(0).InnerText;

            string[] numbers = barcode.Split(' ');

            foreach (string number in numbers)
            {
                if (String.IsNullOrEmpty(number))
                {
                    break;
                }
                strData += ((char)Convert.ToInt32(number, 16)).ToString();
            }
            string lot_no = string.Format("{0}", strData);

            return lot_no;
        }
        private Bitmap GenerateBarcode(string _data)//읽어들인 바코드로 바코드 이미지 생성
        {
            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 200,
                    Width = 600,
                    PureBarcode = false,
                    Margin = 10,
                },
            };
            var bitmap = writer.Write(_data);
            return bitmap;
        }
        private void connect()//tcp 연결
        {

             // tcp client 객체 생성
           // IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(ipTextBox.Text), int.Parse(portTextBox.Text));

            try
            {
                TcpClient tcpClient1 = new TcpClient("localhost", 5000);
                writeRichTextbox("Level2 Server 연결됨...");

                streamReader1 = new StreamReader(tcpClient1.GetStream());
                streamWriter1 = new StreamWriter(tcpClient1.GetStream());
                streamWriter1.AutoFlush = true;

                while (tcpClient1.Connected)
                {
                    string receiveData1 = streamReader1.ReadLine();
                    writeRichTextbox(receiveData1);
                }
            }catch(Exception e)
            {
                
            }
        }
        private void writeRichTextbox(string str)
        {
            tcpRichTextBox.Invoke((MethodInvoker)delegate { tcpRichTextBox.AppendText(str + "\n"); });
            tcpRichTextBox.Invoke((MethodInvoker)delegate { tcpRichTextBox.ScrollToCaret(); });
        }//tcp 연결되어있는 서버 프로그램 textbox에 실적정보를 표시
        private static void ReleaseExcelObject(object obj)// 엑셀 오브젝트 메모리 할당 해제
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        /// *************** 이벤트 처리 
        bool connect_only_once = false;
        private void submitBtn_Click(object sender, EventArgs e)// 투입 탭의 전송 버튼 클릭
        {
            var confirmMSG = MessageBox.Show("전송하시겠습니까?", "알림", MessageBoxButtons.YesNo);
            if (confirmMSG == DialogResult.Yes)
            {
                string insNum = getInsNum();
                string state = "";
                try
                {
                    connection.Open();
                    sql = "SELECT * FROM ins_order_list_c WHERE ins_num='" + insNum + "';";
                    cmd = new MySqlCommand(sql, connection);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        state = Convert.ToString(dr["state"]);
                        state.Replace(" ", "");
                        if (state != "완료")
                        {
                            connection.Close();
                            MessageBox.Show("완료되지 않은 작업지시를 전송하려 했습니다!", "오류", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    connection.Close();
                }
                catch
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                try
                {
                    streamWriter1.WriteLine("지시번호 <"+ insNum + "> 의 실적을 전송하였습니다.");  // 스트림라이터를 통해 데이타를 전송
                    streamWriter1.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    streamWriter1.WriteLine("지시번호 "+ insNum + "("+state+")");
                    //client 에도 똑같이 적자
                    writeRichTextbox("지시번호 <" + insNum + "> 의 실적을 전송하였습니다.");
                    writeRichTextbox("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    writeRichTextbox("지시번호 " + insNum + "(" + state + ")");
                    connection.Open();
                    sql = "select * from scanned_list where ins_num='" + insNum + "';";
                    cmd = new MySqlCommand(sql, connection);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        streamWriter1.WriteLine("   LOT NO.: " + Convert.ToString(dr["lot_no"]) + ", 자재코드: "+Convert.ToString(dr["mat_code"]) +", 자재명: "+Convert.ToString(dr["mat_name"]) +", 투입중량: "+Convert.ToString(dr["input_wgt"]) +", 가용중량:"+Convert.ToString(dr["avl_wgt"]));
                        writeRichTextbox("   LOT NO.: " + Convert.ToString(dr["lot_no"]) + ", 자재코드: " + Convert.ToString(dr["mat_code"]) + ", 자재명: " + Convert.ToString(dr["mat_name"]) + ", 투입중량: " + Convert.ToString(dr["input_wgt"]) + ", 가용중량:" + Convert.ToString(dr["avl_wgt"]));
                    }
                    connection.Close();
                    streamWriter1.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    writeRichTextbox("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    writeRichTextbox("데이터 전송 성공");
                    group4datagrid1.DataSource = null;
                    orderTextBox.Text = "";
                }
                catch
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                try
                {
                    group2pic1.Image = null;
                    group2LotnotextBox.Text = null;
                    mat_code_textBox.Text = null;
                    mat_name_textBox.Text = null;
                    aval_wgt_textBox.Text = null;
                    insert_wgt_textBox.Text = null;

                    group1datagrid2.DataSource = null;
                    group3datagrid1.DataSource = null;


                    orderTextBox.Text = null;
                    group4datagrid1.DataSource = null;

                }
                catch
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        private void group1datagrid1_CellClick(object sender, DataGridViewCellEventArgs e)  // 1_1테이블 셀 클릭
        {
            string insNum = getInsNum();
            setTable1_2(insNum);
            setTable3_1(insNum);
        }
        private void group2insertBtn_Click(object sender, EventArgs e)  // 투입 버튼
        {
            var confirmMSG = MessageBox.Show("원료를 투입하시겠습니까?", "알림", MessageBoxButtons.YesNo);
            if (confirmMSG == DialogResult.Yes)
            {
                string insNum = getInsNum();
                string insert_wgt = "", avl_wgt = "", state = ""; // 총 투입해야될 양과 지금 상태
                //// 이전에 찍었던 바코드면 알림 띄우고 투입x
                try
                {
                    connection.Open();
                    sql = "SELECT count(*) FROM scanned_list WHERE lot_no='" + group2LotnotextBox.Text + "';";
                    //Console.WriteLine(sql);
                    cmd = new MySqlCommand(sql, connection);
                    try
                    {
                        int index = Convert.ToInt32(cmd.ExecuteScalar());
                        Console.WriteLine(Convert.ToString(index));
                        if (index > 0)
                        {
                            Console.WriteLine(index + "");
                            MessageBox.Show("이미 투입된 원료입니다!", "오류", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch
                    {

                    }
                    connection.Close();
                }
                catch
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                try
                {
                    connection.Open();
                    ////*** ins_order 에 현재 자재를 검색해서 정보를 불러온다.
                    sql = "SELECT mat_code, mat_name, insert_wgt, avl_wgt, state FROM ins_order_c WHERE ins_num='" + insNum + "' AND mat_code='" + mat_code_textBox.Text + "';";
                    cmd = new MySqlCommand(sql, connection);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        insert_wgt = Convert.ToString(dr["insert_wgt"]);
                        Console.WriteLine(insert_wgt);
                        avl_wgt = Convert.ToString(dr["avl_wgt"]);
                        state = Convert.ToString(dr["state"]);
                        Console.WriteLine(insert_wgt + avl_wgt + state);

                    }
                    connection.Close();
                }
                catch
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                //*** state를 봐서
                float insert_wgt_f = 0.0f, avl_wgt_f = 0.0f;
                try
                {
                    insert_wgt_f = float.Parse(insert_wgt);
                    avl_wgt_f = float.Parse(avl_wgt);
                }
                catch (Exception ex)
                {
                    insert_wgt_f = -1f;
                    avl_wgt_f = -1f;
                }
                float insertwgt = float.Parse(insert_wgt_textBox.Text);

                if (state == "진행중") // 현재 state가 숫자면
                {
                    try
                    {
                        Console.WriteLine("insert_wgt={0}, 합하면?{1}", (int)(insert_wgt_f * 100), (int)((insertwgt + avl_wgt_f) * 100));
                        //Console.WriteLine(Convert.ToString((int)(insertwgt * 100) + (int)avl_wgt_f * 100));
                        if ((int)(float)(insert_wgt_f * 100) > (int)(float)((insertwgt + avl_wgt_f) * 100))  // 
                        {

                            connection.Open();
                            sql = "INSERT INTO scanned_list(ins_num, lot_no, mat_code, mat_name, input_wgt, avl_wgt) SELECT '" + insNum + "',lot_no,mat_code,mat_name,input_wgt,avl_wgt FROM com_lot WHERE lot_no='" + group2LotnotextBox.Text + "';"
                                    + "UPDATE ins_order_c SET avl_wgt=" + (insertwgt + avl_wgt_f) + " WHERE ins_num = '" + insNum + "' AND mat_code='" + mat_code_textBox.Text + "';";
                            Console.WriteLine(sql);
                            cmd = new MySqlCommand(sql, connection);
                            try { cmd.ExecuteNonQuery(); } catch { };
                            connection.Close();
                        }
                        else if ((int)(float)(insert_wgt_f * 100) == (int)(float)((insertwgt + avl_wgt_f) * 100))
                        {
                            connection.Open();
                            sql = "INSERT INTO scanned_list(ins_num, lot_no, mat_code, mat_name, input_wgt, avl_wgt) SELECT '" + insNum + "',lot_no,mat_code,mat_name,input_wgt,avl_wgt FROM com_lot WHERE lot_no='" + group2LotnotextBox.Text + "';"
                                    + "UPDATE ins_order_c SET avl_wgt=" + (insertwgt + avl_wgt_f) + " WHERE ins_num = '" + insNum + "' AND mat_code='" + mat_code_textBox.Text + "';"
                                    + "UPDATE ins_order_c SET state='완료' WHERE ins_num='" + insNum + "' and mat_code='" + mat_code_textBox.Text + "';";
                            cmd = new MySqlCommand(sql, connection);
                            try { cmd.ExecuteNonQuery(); } catch { };
                            connection.Close();

                            bool notyet = false;

                            try
                            {
                                connection.Open();
                                sql = "SELECT state FROM ins_order_c WHERE ins_num='" + insNum + "';";
                                cmd = new MySqlCommand(sql, connection);
                                dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    string ins_order_state = Convert.ToString(dr["state"]);
                                    if (ins_order_state != "완료")
                                    {
                                        notyet = true;
                                        Console.WriteLine(ins_order_state);
                                    }
                                }
                                connection.Close();
                            }
                            catch
                            {
                                if (connection != null && connection.State == ConnectionState.Open)
                                {
                                    connection.Close();
                                }
                            }

                            if (!notyet)
                            {
                                try
                                {
                                    connection.Open();
                                    sql = "UPDATE ins_order_list_c SET state='완료' WHERE ins_num='" + insNum + "';";

                                    Console.WriteLine(sql);
                                    cmd = new MySqlCommand(sql, connection);
                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                }
                                catch
                                {
                                    if (connection != null && connection.State == ConnectionState.Open)
                                    {
                                        connection.Close();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("투입중량을 초과하는 중량입니다!", "오류", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch
                    {
                        if (connection != null && connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }

                }
                else if (state == "완료")
                {
                    MessageBox.Show("더 이상 투입할 수 없습니다!", "오류", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                setTable1_1();
                setTable1_2(insNum);
                setTable3_1(insNum);
            }
        }
        private void group3datagrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string insNum = getInsNum();
            try
            {
                connection.Open();
                cmd = new MySqlCommand("SELECT * FROM scanned_list WHERE ins_num='" + insNum + "';", connection);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    group2pic1.Image = GenerateBarcode(Convert.ToString(dr["lot_no"]));
                    group2LotnotextBox.Text = Convert.ToString(dr["lot_no"]);
                    mat_code_textBox.Text = Convert.ToString(dr["mat_code"]);
                    mat_name_textBox.Text = Convert.ToString(dr["mat_name"]);
                    insert_wgt_textBox.Text = Convert.ToString(dr["insert_wgt"]);
                    aval_wgt_textBox.Text = Convert.ToString(dr["avl_wgt"]);
                }
                connection.Close();
            }
            catch
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void OnBarcodeEvent(short eventType, ref string pscanData)  //바코드 찍으면
        {
            try
            {
                connection.Open();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(pscanData);

                string lot_no = GetBarcodeLotNo(xmlDoc, pscanData);

                Console.WriteLine(lot_no);

                this.Invoke((MethodInvoker)delegate
                {
                    group2pic1.Image = GenerateBarcode(lot_no);
                    group2LotnotextBox.Text = lot_no;
                    sql = "select * from com_lot where lot_no='" + lot_no + "';";
                    cmd = new MySqlCommand(sql, connection);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        mat_code_textBox.Text = Convert.ToString(dr["mat_code"]);
                        mat_name_textBox.Text = Convert.ToString(dr["mat_name"]);
                        insert_wgt_textBox.Text = Convert.ToString(dr["input_wgt"]);
                        aval_wgt_textBox.Text = Convert.ToString(dr["avl_wgt"]);
                    }
                    for (int i = 0; i < group1datagrid2.Rows.Count; i++)
                    {
                        if (Convert.ToString(group1datagrid2.Rows[i].Cells[0].Value) == mat_code_textBox.Text)
                        {
                            group1datagrid2.CurrentCell = group1datagrid2.Rows[i].Cells[0];
                        }
                    }
                });
                connection.Close();

            }
            catch (Exception)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
        private void printBtn_Click(object sender, EventArgs e)//인쇄 버튼 클릭
        {
            Excel.Application ExcelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            string strLocalPath = System.Windows.Forms.Application.ExecutablePath.Substring(0, System.Windows.Forms.Application.ExecutablePath.LastIndexOf("\\"));
            string strExcelFile = strLocalPath + "\\Print.xlsx";

            if (!File.Exists(strExcelFile)) return;
            try
            {
                ExcelApp = new Excel.Application();
                wb = ExcelApp.Workbooks.Open(strExcelFile, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                ws = wb.Worksheets["Sheet1"] as Excel.Worksheet;

                string barcodeIMG_Path = strLocalPath + "\\" + group2LotnotextBox.Text + ".jpg";
                if (group2pic1.Image == null) return;
                group2pic1.Image.Save(barcodeIMG_Path, System.Drawing.Imaging.ImageFormat.Jpeg);

                ws.Select();
                ws.get_Range(ws.Cells[3, 3] as object, ws.Cells[3, 3] as object).Select();
                Excel.Pictures excelPictures = ws.Pictures(Type.Missing);
                excelPictures.Insert(barcodeIMG_Path, Type.Missing).Select(Type.Missing);

                File.Delete(barcodeIMG_Path);

                ws.Cells[14, 4] = mat_code_textBox.Text;
                ws.Cells[14, 6] = mat_name_textBox.Text;
                ws.Cells[17, 4] = insert_wgt_textBox.Text;
                ws.Cells[17, 6] = aval_wgt_textBox.Text;
                ws.Cells[11, 4] = group2LotnotextBox.Text;

                ExcelApp.Visible = true;
                ExcelApp.Sheets.PrintPreview(true);

                wb.Close(false, Type.Missing, Type.Missing);
                wb = null;
                ExcelApp.Quit();
            }
            catch { }
            finally
            {
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(ExcelApp);
                GC.Collect();
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)  // 투입취소 버튼 클릭
        {
            var confirmMSG = MessageBox.Show("투입을 취소합니다. 계속하시겠습니까?  ", "알림", MessageBoxButtons.YesNo);
            if (confirmMSG == DialogResult.Yes)
            {
                if (group3datagrid1.Rows.Count <= 0)
                {
                    MessageBox.Show("취소할 수 있는 투입내역이 없습니다!", "오류", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    connection.Open();
                    sql = "DELETE FROM scanned_list WHERE lot_no='" + Convert.ToString(group3datagrid1.Rows[group3datagrid1.CurrentCell.RowIndex].Cells[0].Value) + "';" +
                            "UPDATE ins_order_c SET avl_wgt=" + (float.Parse(Convert.ToString(group1datagrid2.Rows[group1datagrid2.CurrentCell.RowIndex].Cells[3].Value)) - float.Parse(Convert.ToString(group3datagrid1.Rows[group3datagrid1.CurrentCell.RowIndex].Cells[3].Value))) + " WHERE mat_code='" + Convert.ToString(group1datagrid2.Rows[group1datagrid2.CurrentCell.RowIndex].Cells[0].Value) + "';";
                    Console.WriteLine(sql);
                    cmd = new MySqlCommand(sql, connection);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        string insNum = getInsNum();
                        setTable1_2(insNum);
                        setTable3_1(insNum);
                    }
                    else
                    {
                        MessageBox.Show("취소할 수 있는 투입내역이 없습니다!", "오류", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                    connection.Close();
                }
                catch (Exception)
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            if (group3datagrid1.Rows.Count > 0)
            {
                group3datagrid1.CurrentCell = group3datagrid1.Rows[group3datagrid1.RowCount - 1].Cells[0];
            }
        }
        private void connectBtn_Click(object sender, EventArgs e)// 연결하기 버튼 클릭
        {
            if (!connect_only_once)
            {
                //TCP로 전송
                Thread thread1 = new Thread(connect);    //thread 객체 생성, Form과는 별도 쓰레드에서 connect
                thread1.IsBackground = true;    // Form이 종료되면 thread1도 종료
                thread1.Start();    // thread1 시작
                connect_only_once = true;
            }
            else
            {
                Console.WriteLine("이미 한번 연결 했습니다.");
            }
        }
        private void searchBtn_Click(object sender, EventArgs e)// 연결탭의 검색 버튼 클릭
        {
            setTable4_1(orderTextBox.Text);
            if (table4_1.Rows.Count <= 0)
            {
                MessageBox.Show("해당 작업지시번호에 대한 투입내역이 없습니다", "오류", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }

    }
}