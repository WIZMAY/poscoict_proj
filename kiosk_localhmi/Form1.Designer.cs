
namespace real_poscoict
{
    partial class BarcodeHmi
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeHmi));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.group1datagrid1 = new System.Windows.Forms.DataGridView();
            this.group2LotnoLabel = new System.Windows.Forms.Label();
            this.group2LotnotextBox = new System.Windows.Forms.TextBox();
            this.group2pic1 = new System.Windows.Forms.PictureBox();
            this.group2printBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.group1datagrid2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.insert_wgt_textBox = new System.Windows.Forms.TextBox();
            this.aval_wgt_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.group2insertBtn = new System.Windows.Forms.Button();
            this.mat_name_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mat_code_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.group3datagrid1 = new System.Windows.Forms.DataGridView();
            this.submitBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.tcpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.group4datagrid1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.orderTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.group1datagrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group2pic1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group1datagrid2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group3datagrid1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group4datagrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // group1datagrid1
            // 
            this.group1datagrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.group1datagrid1.Location = new System.Drawing.Point(15, 24);
            this.group1datagrid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group1datagrid1.Name = "group1datagrid1";
            this.group1datagrid1.ReadOnly = true;
            this.group1datagrid1.RowHeadersWidth = 51;
            this.group1datagrid1.RowTemplate.Height = 27;
            this.group1datagrid1.Size = new System.Drawing.Size(216, 139);
            this.group1datagrid1.TabIndex = 25;
            this.group1datagrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.group1datagrid1_CellClick);
            // 
            // group2LotnoLabel
            // 
            this.group2LotnoLabel.AutoSize = true;
            this.group2LotnoLabel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.group2LotnoLabel.Location = new System.Drawing.Point(281, 34);
            this.group2LotnoLabel.Name = "group2LotnoLabel";
            this.group2LotnoLabel.Size = new System.Drawing.Size(71, 21);
            this.group2LotnoLabel.TabIndex = 1;
            this.group2LotnoLabel.Text = "LOT No.";
            // 
            // group2LotnotextBox
            // 
            this.group2LotnotextBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.group2LotnotextBox.Location = new System.Drawing.Point(370, 32);
            this.group2LotnotextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group2LotnotextBox.Name = "group2LotnotextBox";
            this.group2LotnotextBox.ReadOnly = true;
            this.group2LotnotextBox.Size = new System.Drawing.Size(391, 29);
            this.group2LotnotextBox.TabIndex = 2;
            // 
            // group2pic1
            // 
            this.group2pic1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.group2pic1.Location = new System.Drawing.Point(31, 33);
            this.group2pic1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group2pic1.Name = "group2pic1";
            this.group2pic1.Size = new System.Drawing.Size(223, 73);
            this.group2pic1.TabIndex = 0;
            this.group2pic1.TabStop = false;
            // 
            // group2printBtn
            // 
            this.group2printBtn.Location = new System.Drawing.Point(31, 114);
            this.group2printBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group2printBtn.Name = "group2printBtn";
            this.group2printBtn.Size = new System.Drawing.Size(80, 30);
            this.group2printBtn.TabIndex = 20;
            this.group2printBtn.Text = "인쇄";
            this.group2printBtn.UseVisualStyleBackColor = true;
            this.group2printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(7, 561);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(116, 30);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "투입 취소";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.group1datagrid2);
            this.groupBox1.Controls.Add(this.group1datagrid1);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(883, 171);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "작업지시";
            // 
            // group1datagrid2
            // 
            this.group1datagrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.group1datagrid2.Enabled = false;
            this.group1datagrid2.Location = new System.Drawing.Point(236, 24);
            this.group1datagrid2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group1datagrid2.Name = "group1datagrid2";
            this.group1datagrid2.ReadOnly = true;
            this.group1datagrid2.RowHeadersWidth = 51;
            this.group1datagrid2.RowTemplate.Height = 27;
            this.group1datagrid2.Size = new System.Drawing.Size(634, 139);
            this.group1datagrid2.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.insert_wgt_textBox);
            this.groupBox2.Controls.Add(this.aval_wgt_textBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.group2insertBtn);
            this.groupBox2.Controls.Add(this.mat_name_textBox);
            this.groupBox2.Controls.Add(this.group2pic1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.mat_code_textBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.group2LotnoLabel);
            this.groupBox2.Controls.Add(this.group2printBtn);
            this.groupBox2.Controls.Add(this.group2LotnotextBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(883, 148);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "바코드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(578, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 35;
            this.label4.Text = "가용중량";
            // 
            // insert_wgt_textBox
            // 
            this.insert_wgt_textBox.Location = new System.Drawing.Point(370, 107);
            this.insert_wgt_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insert_wgt_textBox.Name = "insert_wgt_textBox";
            this.insert_wgt_textBox.ReadOnly = true;
            this.insert_wgt_textBox.Size = new System.Drawing.Size(196, 29);
            this.insert_wgt_textBox.TabIndex = 38;
            // 
            // aval_wgt_textBox
            // 
            this.aval_wgt_textBox.Location = new System.Drawing.Point(666, 107);
            this.aval_wgt_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aval_wgt_textBox.Name = "aval_wgt_textBox";
            this.aval_wgt_textBox.ReadOnly = true;
            this.aval_wgt_textBox.Size = new System.Drawing.Size(196, 29);
            this.aval_wgt_textBox.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(578, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "자재명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // group2insertBtn
            // 
            this.group2insertBtn.Location = new System.Drawing.Point(781, 32);
            this.group2insertBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group2insertBtn.Name = "group2insertBtn";
            this.group2insertBtn.Size = new System.Drawing.Size(80, 29);
            this.group2insertBtn.TabIndex = 32;
            this.group2insertBtn.Text = "투입";
            this.group2insertBtn.UseVisualStyleBackColor = true;
            this.group2insertBtn.Click += new System.EventHandler(this.group2insertBtn_Click);
            // 
            // mat_name_textBox
            // 
            this.mat_name_textBox.Location = new System.Drawing.Point(666, 71);
            this.mat_name_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mat_name_textBox.Name = "mat_name_textBox";
            this.mat_name_textBox.ReadOnly = true;
            this.mat_name_textBox.Size = new System.Drawing.Size(196, 29);
            this.mat_name_textBox.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 34;
            this.label3.Text = "포장중량";
            // 
            // mat_code_textBox
            // 
            this.mat_code_textBox.Location = new System.Drawing.Point(370, 71);
            this.mat_code_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mat_code_textBox.Name = "mat_code_textBox";
            this.mat_code_textBox.ReadOnly = true;
            this.mat_code_textBox.Size = new System.Drawing.Size(196, 29);
            this.mat_code_textBox.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(281, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "자재코드";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.group3datagrid1);
            this.groupBox3.Location = new System.Drawing.Point(6, 318);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(883, 238);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "원료투입목록";
            // 
            // group3datagrid1
            // 
            this.group3datagrid1.AllowUserToAddRows = false;
            this.group3datagrid1.AllowUserToDeleteRows = false;
            this.group3datagrid1.AllowUserToResizeColumns = false;
            this.group3datagrid1.AllowUserToResizeRows = false;
            this.group3datagrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.group3datagrid1.Enabled = false;
            this.group3datagrid1.Location = new System.Drawing.Point(14, 27);
            this.group3datagrid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group3datagrid1.Name = "group3datagrid1";
            this.group3datagrid1.ReadOnly = true;
            this.group3datagrid1.RowHeadersWidth = 51;
            this.group3datagrid1.RowTemplate.Height = 27;
            this.group3datagrid1.Size = new System.Drawing.Size(856, 195);
            this.group3datagrid1.TabIndex = 27;
            this.group3datagrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.group3datagrid1_CellClick);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(809, 563);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(80, 30);
            this.submitBtn.TabIndex = 31;
            this.submitBtn.Text = "전송";
            this.submitBtn.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(906, 634);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.submitBtn);
            this.tabPage1.Controls.Add(this.cancelBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(898, 600);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "투입";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(898, 600);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "연결";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.connectBtn);
            this.groupBox5.Controls.Add(this.portTextBox);
            this.groupBox5.Controls.Add(this.ipTextBox);
            this.groupBox5.Controls.Add(this.tcpRichTextBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 243);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(887, 343);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TCP통신";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "IP";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(626, 27);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(80, 27);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "연결";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(525, 27);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(84, 29);
            this.portTextBox.TabIndex = 5;
            this.portTextBox.Text = "5000";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(191, 27);
            this.ipTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(276, 29);
            this.ipTextBox.TabIndex = 4;
            this.ipTextBox.Text = "localhost";
            // 
            // tcpRichTextBox
            // 
            this.tcpRichTextBox.Location = new System.Drawing.Point(17, 70);
            this.tcpRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcpRichTextBox.Name = "tcpRichTextBox";
            this.tcpRichTextBox.Size = new System.Drawing.Size(855, 259);
            this.tcpRichTextBox.TabIndex = 0;
            this.tcpRichTextBox.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.searchBtn);
            this.groupBox4.Controls.Add(this.group4datagrid1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.orderTextBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 5);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(887, 234);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "투입내역조회";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(598, 39);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(80, 28);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "검색";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // group4datagrid1
            // 
            this.group4datagrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.group4datagrid1.Location = new System.Drawing.Point(15, 81);
            this.group4datagrid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group4datagrid1.Name = "group4datagrid1";
            this.group4datagrid1.RowHeadersWidth = 51;
            this.group4datagrid1.RowTemplate.Height = 27;
            this.group4datagrid1.Size = new System.Drawing.Size(857, 139);
            this.group4datagrid1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "작업지시번호";
            // 
            // orderTextBox
            // 
            this.orderTextBox.Location = new System.Drawing.Point(308, 39);
            this.orderTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderTextBox.Name = "orderTextBox";
            this.orderTextBox.Size = new System.Drawing.Size(276, 29);
            this.orderTextBox.TabIndex = 0;
            // 
            // BarcodeHmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 632);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BarcodeHmi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kiosk HMI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group1datagrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group2pic1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group1datagrid2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group3datagrid1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group4datagrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView group1datagrid1;
        private System.Windows.Forms.Label group2LotnoLabel;
        private System.Windows.Forms.TextBox group2LotnotextBox;
        private System.Windows.Forms.PictureBox group2pic1;
        private System.Windows.Forms.Button group2printBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView group1datagrid2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView group3datagrid1;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox aval_wgt_textBox;
        private System.Windows.Forms.TextBox insert_wgt_textBox;
        private System.Windows.Forms.TextBox mat_name_textBox;
        private System.Windows.Forms.TextBox mat_code_textBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button group2insertBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox tcpRichTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataGridView group4datagrid1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox orderTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox ipTextBox;
    }
}

