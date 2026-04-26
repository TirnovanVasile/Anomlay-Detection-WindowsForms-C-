namespace Proiect_IA_3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            tabData = new TabPage();
            groupBox1 = new GroupBox();
            btnPreprocess = new Button();
            dgvDataPreview = new DataGridView();
            groupBoxPreprocess = new GroupBox();
            btnNormalizeData = new Button();
            groupBoxDataset = new GroupBox();
            btnLoadData = new Button();
            tabConfig = new TabPage();
            groupBox2 = new GroupBox();
            rbKMeans = new RadioButton();
            rbLogisticRegression = new RadioButton();
            rbAutoencoder = new RadioButton();
            rbMLP = new RadioButton();
            groupBoxNetworkInfo = new GroupBox();
            pbNetworkCanvas = new PictureBox();
            btnCreateNetwork = new Button();
            lblNetworkStatus = new Label();
            groupBoxArchitecture = new GroupBox();
            cmbInitMethod = new ComboBox();
            label8 = new Label();
            cmbActivationFunction = new ComboBox();
            label7 = new Label();
            lblOutputCount = new Label();
            label6 = new Label();
            numNeuronsLayer3 = new NumericUpDown();
            lblLayer3 = new Label();
            numNeuronsLayer2 = new NumericUpDown();
            lblLayer2 = new Label();
            numNeuronsLayer1 = new NumericUpDown();
            lblLayer1 = new Label();
            numHiddenLayers = new NumericUpDown();
            label5 = new Label();
            lblInputCount = new Label();
            label4 = new Label();
            tabTraining = new TabPage();
            chartLoss = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBoxProgress = new GroupBox();
            progressBarTraining = new ProgressBar();
            lblETA = new Label();
            lblTimeElapsed = new Label();
            lblValidationLoss = new Label();
            lblCurrentLoss = new Label();
            lblCurrentEpoch = new Label();
            groupBoxTrainingControl = new GroupBox();
            btnStopTraining = new Button();
            btnStartTraining = new Button();
            groupBoxHyperparams = new GroupBox();
            numAnomalyThreshold = new NumericUpDown();
            label1 = new Label();
            chkUseValidation = new CheckBox();
            numTargetError = new NumericUpDown();
            label11 = new Label();
            numMaxEpochs = new NumericUpDown();
            label10 = new Label();
            numLearningRate = new NumericUpDown();
            label9 = new Label();
            tabTesting = new TabPage();
            groupBoxConfusion = new GroupBox();
            lblFN = new Label();
            lblFP = new Label();
            lblTN = new Label();
            lblTP = new Label();
            groupBoxMetrics = new GroupBox();
            lblFNR = new Label();
            lblMSE = new Label();
            lblF1Score = new Label();
            lblRecall = new Label();
            lblPrecision = new Label();
            lblAccuracy = new Label();
            groupBoxTestActions = new GroupBox();
            btnLoadTestData = new Button();
            btnTestModel = new Button();
            toolStrip1 = new ToolStrip();
            toolStripSeparator1 = new ToolStripSeparator();
            btnSaveModel = new ToolStripButton();
            btnLoadModel = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            tabControl1.SuspendLayout();
            tabData.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataPreview).BeginInit();
            groupBoxPreprocess.SuspendLayout();
            groupBoxDataset.SuspendLayout();
            tabConfig.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBoxNetworkInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbNetworkCanvas).BeginInit();
            groupBoxArchitecture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNeuronsLayer3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNeuronsLayer2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNeuronsLayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHiddenLayers).BeginInit();
            tabTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartLoss).BeginInit();
            groupBoxProgress.SuspendLayout();
            groupBoxTrainingControl.SuspendLayout();
            groupBoxHyperparams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnomalyThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxEpochs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLearningRate).BeginInit();
            tabTesting.SuspendLayout();
            groupBoxConfusion.SuspendLayout();
            groupBoxMetrics.SuspendLayout();
            groupBoxTestActions.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabData);
            tabControl1.Controls.Add(tabConfig);
            tabControl1.Controls.Add(tabTraining);
            tabControl1.Controls.Add(tabTesting);
            tabControl1.Location = new Point(3, 46);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2301, 1284);
            tabControl1.TabIndex = 0;
            // 
            // tabData
            // 
            tabData.Controls.Add(groupBox1);
            tabData.Controls.Add(dgvDataPreview);
            tabData.Controls.Add(groupBoxPreprocess);
            tabData.Controls.Add(groupBoxDataset);
            tabData.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            tabData.Location = new Point(8, 46);
            tabData.Name = "tabData";
            tabData.Padding = new Padding(3);
            tabData.Size = new Size(2285, 1230);
            tabData.TabIndex = 0;
            tabData.Text = "Load Data";
            tabData.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.PaleGreen;
            groupBox1.Controls.Add(btnPreprocess);
            groupBox1.Location = new Point(41, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(673, 326);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data Preprocessing";
            // 
            // btnPreprocess
            // 
            btnPreprocess.BackColor = Color.DarkGreen;
            btnPreprocess.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnPreprocess.ForeColor = SystemColors.ButtonHighlight;
            btnPreprocess.Location = new Point(181, 103);
            btnPreprocess.Name = "btnPreprocess";
            btnPreprocess.Size = new Size(296, 136);
            btnPreprocess.TabIndex = 10;
            btnPreprocess.Text = "Preprocess Data";
            btnPreprocess.UseVisualStyleBackColor = false;
            btnPreprocess.Click += btnPreprocess_Click;
            // 
            // dgvDataPreview
            // 
            dgvDataPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDataPreview.BackgroundColor = SystemColors.ControlLightLight;
            dgvDataPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataPreview.Location = new Point(757, 40);
            dgvDataPreview.Name = "dgvDataPreview";
            dgvDataPreview.ReadOnly = true;
            dgvDataPreview.RowHeadersWidth = 82;
            dgvDataPreview.RowTemplate.Height = 41;
            dgvDataPreview.Size = new Size(1484, 1164);
            dgvDataPreview.TabIndex = 9;
            // 
            // groupBoxPreprocess
            // 
            groupBoxPreprocess.BackColor = Color.PaleGoldenrod;
            groupBoxPreprocess.Controls.Add(btnNormalizeData);
            groupBoxPreprocess.Location = new Point(41, 853);
            groupBoxPreprocess.Name = "groupBoxPreprocess";
            groupBoxPreprocess.Size = new Size(673, 315);
            groupBoxPreprocess.TabIndex = 5;
            groupBoxPreprocess.TabStop = false;
            groupBoxPreprocess.Text = "Data Normalization";
            // 
            // btnNormalizeData
            // 
            btnNormalizeData.BackColor = Color.Olive;
            btnNormalizeData.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnNormalizeData.ForeColor = SystemColors.ControlLightLight;
            btnNormalizeData.Location = new Point(180, 101);
            btnNormalizeData.Name = "btnNormalizeData";
            btnNormalizeData.Size = new Size(297, 136);
            btnNormalizeData.TabIndex = 5;
            btnNormalizeData.Text = "Normalize Data";
            btnNormalizeData.UseVisualStyleBackColor = false;
            btnNormalizeData.Click += btnNormalizeData_Click;
            // 
            // groupBoxDataset
            // 
            groupBoxDataset.BackColor = Color.PaleTurquoise;
            groupBoxDataset.Controls.Add(btnLoadData);
            groupBoxDataset.Location = new Point(41, 456);
            groupBoxDataset.Name = "groupBoxDataset";
            groupBoxDataset.Size = new Size(673, 337);
            groupBoxDataset.TabIndex = 4;
            groupBoxDataset.TabStop = false;
            groupBoxDataset.Text = "Train Dataset";
            // 
            // btnLoadData
            // 
            btnLoadData.BackColor = Color.DarkCyan;
            btnLoadData.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadData.ForeColor = SystemColors.ButtonHighlight;
            btnLoadData.Location = new Point(181, 118);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(296, 136);
            btnLoadData.TabIndex = 4;
            btnLoadData.Text = "Load Train Data";
            btnLoadData.UseVisualStyleBackColor = false;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // tabConfig
            // 
            tabConfig.Controls.Add(groupBox2);
            tabConfig.Controls.Add(groupBoxNetworkInfo);
            tabConfig.Controls.Add(groupBoxArchitecture);
            tabConfig.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            tabConfig.Location = new Point(8, 46);
            tabConfig.Name = "tabConfig";
            tabConfig.Padding = new Padding(3);
            tabConfig.Size = new Size(2285, 1230);
            tabConfig.TabIndex = 1;
            tabConfig.Text = "Configuration";
            tabConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.PowderBlue;
            groupBox2.Controls.Add(rbKMeans);
            groupBox2.Controls.Add(rbLogisticRegression);
            groupBox2.Controls.Add(rbAutoencoder);
            groupBox2.Controls.Add(rbMLP);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBox2.Location = new Point(44, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(674, 310);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detection Method";
            // 
            // rbKMeans
            // 
            rbKMeans.AutoSize = true;
            rbKMeans.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            rbKMeans.Location = new Point(22, 239);
            rbKMeans.Name = "rbKMeans";
            rbKMeans.Size = new Size(492, 41);
            rbKMeans.TabIndex = 3;
            rbKMeans.Text = "K-Means Clustering (Unsupervised)";
            rbKMeans.UseVisualStyleBackColor = true;
            rbKMeans.CheckedChanged += rbMethod_CheckedChanged;
            // 
            // rbLogisticRegression
            // 
            rbLogisticRegression.AutoSize = true;
            rbLogisticRegression.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            rbLogisticRegression.Location = new Point(21, 114);
            rbLogisticRegression.Name = "rbLogisticRegression";
            rbLogisticRegression.Size = new Size(454, 41);
            rbLogisticRegression.TabIndex = 2;
            rbLogisticRegression.Text = "Logistic Regression (Supervised)";
            rbLogisticRegression.UseVisualStyleBackColor = true;
            rbLogisticRegression.CheckedChanged += rbMethod_CheckedChanged;
            // 
            // rbAutoencoder
            // 
            rbAutoencoder.AutoSize = true;
            rbAutoencoder.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            rbAutoencoder.Location = new Point(21, 175);
            rbAutoencoder.Name = "rbAutoencoder";
            rbAutoencoder.Size = new Size(569, 41);
            rbAutoencoder.TabIndex = 1;
            rbAutoencoder.Text = "Autoencoder (Unsupervised - 52 Outputs)";
            rbAutoencoder.UseVisualStyleBackColor = true;
            rbAutoencoder.CheckedChanged += rbMethod_CheckedChanged;
            // 
            // rbMLP
            // 
            rbMLP.AutoSize = true;
            rbMLP.Checked = true;
            rbMLP.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            rbMLP.Location = new Point(21, 54);
            rbMLP.Name = "rbMLP";
            rbMLP.Size = new Size(647, 41);
            rbMLP.TabIndex = 0;
            rbMLP.TabStop = true;
            rbMLP.Text = "Multi-Layer Perceptron  (Supervised - 1 Output)";
            rbMLP.UseVisualStyleBackColor = true;
            rbMLP.CheckedChanged += rbMethod_CheckedChanged;
            // 
            // groupBoxNetworkInfo
            // 
            groupBoxNetworkInfo.BackColor = Color.AntiqueWhite;
            groupBoxNetworkInfo.Controls.Add(pbNetworkCanvas);
            groupBoxNetworkInfo.Controls.Add(btnCreateNetwork);
            groupBoxNetworkInfo.Controls.Add(lblNetworkStatus);
            groupBoxNetworkInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxNetworkInfo.Location = new Point(776, 23);
            groupBoxNetworkInfo.Name = "groupBoxNetworkInfo";
            groupBoxNetworkInfo.Size = new Size(1492, 1186);
            groupBoxNetworkInfo.TabIndex = 1;
            groupBoxNetworkInfo.TabStop = false;
            groupBoxNetworkInfo.Text = "Network Info";
            // 
            // pbNetworkCanvas
            // 
            pbNetworkCanvas.Location = new Point(25, 39);
            pbNetworkCanvas.Name = "pbNetworkCanvas";
            pbNetworkCanvas.Size = new Size(1448, 968);
            pbNetworkCanvas.TabIndex = 3;
            pbNetworkCanvas.TabStop = false;
            // 
            // btnCreateNetwork
            // 
            btnCreateNetwork.BackColor = Color.SaddleBrown;
            btnCreateNetwork.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateNetwork.ForeColor = SystemColors.ControlLightLight;
            btnCreateNetwork.Location = new Point(87, 1056);
            btnCreateNetwork.Name = "btnCreateNetwork";
            btnCreateNetwork.Size = new Size(416, 97);
            btnCreateNetwork.TabIndex = 2;
            btnCreateNetwork.Text = "Create Neural Network";
            btnCreateNetwork.UseVisualStyleBackColor = false;
            btnCreateNetwork.Click += btnCreateNetwork_Click;
            // 
            // lblNetworkStatus
            // 
            lblNetworkStatus.AutoSize = true;
            lblNetworkStatus.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            lblNetworkStatus.Location = new Point(670, 1057);
            lblNetworkStatus.Name = "lblNetworkStatus";
            lblNetworkStatus.Size = new Size(273, 50);
            lblNetworkStatus.TabIndex = 0;
            lblNetworkStatus.Text = "Network Status";
            // 
            // groupBoxArchitecture
            // 
            groupBoxArchitecture.BackColor = Color.Gainsboro;
            groupBoxArchitecture.Controls.Add(cmbInitMethod);
            groupBoxArchitecture.Controls.Add(label8);
            groupBoxArchitecture.Controls.Add(cmbActivationFunction);
            groupBoxArchitecture.Controls.Add(label7);
            groupBoxArchitecture.Controls.Add(lblOutputCount);
            groupBoxArchitecture.Controls.Add(label6);
            groupBoxArchitecture.Controls.Add(numNeuronsLayer3);
            groupBoxArchitecture.Controls.Add(lblLayer3);
            groupBoxArchitecture.Controls.Add(numNeuronsLayer2);
            groupBoxArchitecture.Controls.Add(lblLayer2);
            groupBoxArchitecture.Controls.Add(numNeuronsLayer1);
            groupBoxArchitecture.Controls.Add(lblLayer1);
            groupBoxArchitecture.Controls.Add(numHiddenLayers);
            groupBoxArchitecture.Controls.Add(label5);
            groupBoxArchitecture.Controls.Add(lblInputCount);
            groupBoxArchitecture.Controls.Add(label4);
            groupBoxArchitecture.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxArchitecture.Location = new Point(44, 363);
            groupBoxArchitecture.Name = "groupBoxArchitecture";
            groupBoxArchitecture.Size = new Size(674, 846);
            groupBoxArchitecture.TabIndex = 0;
            groupBoxArchitecture.TabStop = false;
            groupBoxArchitecture.Text = "Network Architecture";
            // 
            // cmbInitMethod
            // 
            cmbInitMethod.FormattingEnabled = true;
            cmbInitMethod.Items.AddRange(new object[] { "Random", "Xavier" });
            cmbInitMethod.Location = new Point(377, 666);
            cmbInitMethod.Name = "cmbInitMethod";
            cmbInitMethod.Size = new Size(242, 40);
            cmbInitMethod.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(72, 669);
            label8.Name = "label8";
            label8.Size = new Size(299, 37);
            label8.TabIndex = 14;
            label8.Text = "Weights Initialization:";
            // 
            // cmbActivationFunction
            // 
            cmbActivationFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActivationFunction.FormattingEnabled = true;
            cmbActivationFunction.Items.AddRange(new object[] { "Sigmoid", "Tanh", "ReLU" });
            cmbActivationFunction.Location = new Point(349, 607);
            cmbActivationFunction.Name = "cmbActivationFunction";
            cmbActivationFunction.Size = new Size(242, 40);
            cmbActivationFunction.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(72, 606);
            label7.Name = "label7";
            label7.Size = new Size(275, 37);
            label7.TabIndex = 12;
            label7.Text = "Activation Function:";
            // 
            // lblOutputCount
            // 
            lblOutputCount.AutoSize = true;
            lblOutputCount.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            lblOutputCount.Location = new Point(290, 492);
            lblOutputCount.Name = "lblOutputCount";
            lblOutputCount.Size = new Size(282, 37);
            lblOutputCount.TabIndex = 11;
            lblOutputCount.Text = "1 (Anomaly Detection)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(80, 492);
            label6.Name = "label6";
            label6.Size = new Size(213, 37);
            label6.TabIndex = 10;
            label6.Text = "Outputs (auto):";
            // 
            // numNeuronsLayer3
            // 
            numNeuronsLayer3.Enabled = false;
            numNeuronsLayer3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numNeuronsLayer3.Location = new Point(373, 415);
            numNeuronsLayer3.Margin = new Padding(2, 3, 2, 3);
            numNeuronsLayer3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNeuronsLayer3.Name = "numNeuronsLayer3";
            numNeuronsLayer3.Size = new Size(135, 39);
            numNeuronsLayer3.TabIndex = 9;
            numNeuronsLayer3.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // lblLayer3
            // 
            lblLayer3.AutoSize = true;
            lblLayer3.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblLayer3.Location = new Point(124, 413);
            lblLayer3.Name = "lblLayer3";
            lblLayer3.Size = new Size(257, 37);
            lblLayer3.TabIndex = 8;
            lblLayer3.Text = "Layer 3 - Neurons: ";
            // 
            // numNeuronsLayer2
            // 
            numNeuronsLayer2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numNeuronsLayer2.Location = new Point(373, 354);
            numNeuronsLayer2.Margin = new Padding(2, 3, 2, 3);
            numNeuronsLayer2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNeuronsLayer2.Name = "numNeuronsLayer2";
            numNeuronsLayer2.Size = new Size(135, 39);
            numNeuronsLayer2.TabIndex = 7;
            numNeuronsLayer2.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // lblLayer2
            // 
            lblLayer2.AutoSize = true;
            lblLayer2.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblLayer2.Location = new Point(124, 352);
            lblLayer2.Name = "lblLayer2";
            lblLayer2.Size = new Size(257, 37);
            lblLayer2.TabIndex = 6;
            lblLayer2.Text = "Layer 2 - Neurons: ";
            // 
            // numNeuronsLayer1
            // 
            numNeuronsLayer1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numNeuronsLayer1.Location = new Point(373, 289);
            numNeuronsLayer1.Margin = new Padding(2, 3, 2, 3);
            numNeuronsLayer1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNeuronsLayer1.Name = "numNeuronsLayer1";
            numNeuronsLayer1.Size = new Size(135, 39);
            numNeuronsLayer1.TabIndex = 5;
            numNeuronsLayer1.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // lblLayer1
            // 
            lblLayer1.AutoSize = true;
            lblLayer1.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblLayer1.Location = new Point(124, 287);
            lblLayer1.Name = "lblLayer1";
            lblLayer1.Size = new Size(257, 37);
            lblLayer1.TabIndex = 4;
            lblLayer1.Text = "Layer 1 - Neurons: ";
            // 
            // numHiddenLayers
            // 
            numHiddenLayers.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numHiddenLayers.Location = new Point(290, 203);
            numHiddenLayers.Margin = new Padding(2, 3, 2, 3);
            numHiddenLayers.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numHiddenLayers.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHiddenLayers.Name = "numHiddenLayers";
            numHiddenLayers.Size = new Size(161, 39);
            numHiddenLayers.TabIndex = 3;
            numHiddenLayers.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numHiddenLayers.ValueChanged += numHiddenLayers_ValueChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(62, 203);
            label5.Name = "label5";
            label5.Size = new Size(207, 37);
            label5.TabIndex = 2;
            label5.Text = "Hidden Layers:";
            // 
            // lblInputCount
            // 
            lblInputCount.AutoSize = true;
            lblInputCount.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            lblInputCount.Location = new Point(290, 121);
            lblInputCount.Name = "lblInputCount";
            lblInputCount.Size = new Size(148, 37);
            lblInputCount.TabIndex = 1;
            lblInputCount.Text = "52 features";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(80, 121);
            label4.Name = "label4";
            label4.Size = new Size(191, 37);
            label4.TabIndex = 0;
            label4.Text = "Inputs (auto):";
            // 
            // tabTraining
            // 
            tabTraining.Controls.Add(chartLoss);
            tabTraining.Controls.Add(groupBoxProgress);
            tabTraining.Controls.Add(groupBoxTrainingControl);
            tabTraining.Controls.Add(groupBoxHyperparams);
            tabTraining.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            tabTraining.Location = new Point(8, 46);
            tabTraining.Name = "tabTraining";
            tabTraining.Size = new Size(2285, 1230);
            tabTraining.TabIndex = 2;
            tabTraining.Text = "Training";
            tabTraining.UseVisualStyleBackColor = true;
            // 
            // chartLoss
            // 
            chartLoss.BackColor = Color.WhiteSmoke;
            chartLoss.BorderlineColor = Color.Gray;
            chartArea1.BorderColor = Color.BlanchedAlmond;
            chartArea1.Name = "ChartArea1";
            chartLoss.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartLoss.Legends.Add(legend1);
            chartLoss.Location = new Point(144, 461);
            chartLoss.Name = "chartLoss";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartLoss.Series.Add(series1);
            chartLoss.Size = new Size(2009, 698);
            chartLoss.TabIndex = 3;
            chartLoss.Text = "chart1";
            // 
            // groupBoxProgress
            // 
            groupBoxProgress.BackColor = Color.LavenderBlush;
            groupBoxProgress.Controls.Add(progressBarTraining);
            groupBoxProgress.Controls.Add(lblETA);
            groupBoxProgress.Controls.Add(lblTimeElapsed);
            groupBoxProgress.Controls.Add(lblValidationLoss);
            groupBoxProgress.Controls.Add(lblCurrentLoss);
            groupBoxProgress.Controls.Add(lblCurrentEpoch);
            groupBoxProgress.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxProgress.Location = new Point(1345, 20);
            groupBoxProgress.Name = "groupBoxProgress";
            groupBoxProgress.Size = new Size(849, 418);
            groupBoxProgress.TabIndex = 2;
            groupBoxProgress.TabStop = false;
            groupBoxProgress.Text = "Progress";
            // 
            // progressBarTraining
            // 
            progressBarTraining.Location = new Point(50, 297);
            progressBarTraining.Name = "progressBarTraining";
            progressBarTraining.Size = new Size(774, 46);
            progressBarTraining.TabIndex = 5;
            // 
            // lblETA
            // 
            lblETA.AutoSize = true;
            lblETA.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblETA.Location = new Point(50, 240);
            lblETA.Name = "lblETA";
            lblETA.Size = new Size(188, 37);
            lblETA.TabIndex = 4;
            lblETA.Text = "ETA: 00:00:00";
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimeElapsed.Location = new Point(50, 192);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(205, 37);
            lblTimeElapsed.TabIndex = 3;
            lblTimeElapsed.Text = "Time: 00:00:00";
            // 
            // lblValidationLoss
            // 
            lblValidationLoss.AutoSize = true;
            lblValidationLoss.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblValidationLoss.Location = new Point(50, 146);
            lblValidationLoss.Name = "lblValidationLoss";
            lblValidationLoss.Size = new Size(276, 37);
            lblValidationLoss.TabIndex = 2;
            lblValidationLoss.Text = "Valid Loss: 0.000000";
            // 
            // lblCurrentLoss
            // 
            lblCurrentLoss.AutoSize = true;
            lblCurrentLoss.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentLoss.Location = new Point(50, 94);
            lblCurrentLoss.Name = "lblCurrentLoss";
            lblCurrentLoss.Size = new Size(205, 37);
            lblCurrentLoss.TabIndex = 1;
            lblCurrentLoss.Text = "Loss: 0.000000";
            // 
            // lblCurrentEpoch
            // 
            lblCurrentEpoch.AutoSize = true;
            lblCurrentEpoch.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentEpoch.Location = new Point(50, 49);
            lblCurrentEpoch.Name = "lblCurrentEpoch";
            lblCurrentEpoch.Size = new Size(152, 37);
            lblCurrentEpoch.TabIndex = 0;
            lblCurrentEpoch.Text = "Epoch: 0/0";
            // 
            // groupBoxTrainingControl
            // 
            groupBoxTrainingControl.BackColor = Color.GhostWhite;
            groupBoxTrainingControl.Controls.Add(btnStopTraining);
            groupBoxTrainingControl.Controls.Add(btnStartTraining);
            groupBoxTrainingControl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxTrainingControl.Location = new Point(806, 20);
            groupBoxTrainingControl.Name = "groupBoxTrainingControl";
            groupBoxTrainingControl.Size = new Size(433, 418);
            groupBoxTrainingControl.TabIndex = 1;
            groupBoxTrainingControl.TabStop = false;
            groupBoxTrainingControl.Text = "Training Control";
            // 
            // btnStopTraining
            // 
            btnStopTraining.BackColor = Color.Red;
            btnStopTraining.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnStopTraining.ForeColor = SystemColors.ControlLightLight;
            btnStopTraining.Location = new Point(71, 240);
            btnStopTraining.Name = "btnStopTraining";
            btnStopTraining.Size = new Size(286, 111);
            btnStopTraining.TabIndex = 1;
            btnStopTraining.Text = "Stop Training";
            btnStopTraining.UseVisualStyleBackColor = false;
            btnStopTraining.Click += btnStopTraining_Click;
            // 
            // btnStartTraining
            // 
            btnStartTraining.BackColor = Color.Lime;
            btnStartTraining.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartTraining.ForeColor = SystemColors.ControlLightLight;
            btnStartTraining.Location = new Point(71, 72);
            btnStartTraining.Name = "btnStartTraining";
            btnStartTraining.Size = new Size(286, 111);
            btnStartTraining.TabIndex = 0;
            btnStartTraining.Text = "Start Training";
            btnStartTraining.UseVisualStyleBackColor = false;
            btnStartTraining.Click += btnStartTraining_Click;
            // 
            // groupBoxHyperparams
            // 
            groupBoxHyperparams.BackColor = Color.AliceBlue;
            groupBoxHyperparams.Controls.Add(numAnomalyThreshold);
            groupBoxHyperparams.Controls.Add(label1);
            groupBoxHyperparams.Controls.Add(chkUseValidation);
            groupBoxHyperparams.Controls.Add(numTargetError);
            groupBoxHyperparams.Controls.Add(label11);
            groupBoxHyperparams.Controls.Add(numMaxEpochs);
            groupBoxHyperparams.Controls.Add(label10);
            groupBoxHyperparams.Controls.Add(numLearningRate);
            groupBoxHyperparams.Controls.Add(label9);
            groupBoxHyperparams.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxHyperparams.Location = new Point(104, 20);
            groupBoxHyperparams.Name = "groupBoxHyperparams";
            groupBoxHyperparams.Size = new Size(585, 418);
            groupBoxHyperparams.TabIndex = 0;
            groupBoxHyperparams.TabStop = false;
            groupBoxHyperparams.Text = "Hyperparameters";
            // 
            // numAnomalyThreshold
            // 
            numAnomalyThreshold.DecimalPlaces = 6;
            numAnomalyThreshold.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numAnomalyThreshold.Location = new Point(367, 267);
            numAnomalyThreshold.Margin = new Padding(2, 3, 2, 3);
            numAnomalyThreshold.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numAnomalyThreshold.Name = "numAnomalyThreshold";
            numAnomalyThreshold.Size = new Size(195, 39);
            numAnomalyThreshold.TabIndex = 8;
            numAnomalyThreshold.Value = new decimal(new int[] { 5, 0, 0, 262144 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 269);
            label1.Name = "label1";
            label1.Size = new Size(356, 37);
            label1.TabIndex = 7;
            label1.Text = "Anomaly Threshold (MSE):";
            // 
            // chkUseValidation
            // 
            chkUseValidation.AutoSize = true;
            chkUseValidation.Checked = true;
            chkUseValidation.CheckState = CheckState.Checked;
            chkUseValidation.Location = new Point(40, 341);
            chkUseValidation.Name = "chkUseValidation";
            chkUseValidation.Size = new Size(206, 36);
            chkUseValidation.TabIndex = 6;
            chkUseValidation.Text = "Use Validation";
            chkUseValidation.UseVisualStyleBackColor = true;
            // 
            // numTargetError
            // 
            numTargetError.DecimalPlaces = 6;
            numTargetError.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numTargetError.Location = new Point(266, 205);
            numTargetError.Margin = new Padding(2, 3, 2, 3);
            numTargetError.Name = "numTargetError";
            numTargetError.Size = new Size(195, 39);
            numTargetError.TabIndex = 5;
            numTargetError.Value = new decimal(new int[] { 1, 0, 0, 196608 });
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(6, 203);
            label11.Name = "label11";
            label11.Size = new Size(260, 37);
            label11.TabIndex = 4;
            label11.Text = "Target Error (MSE):";
            // 
            // numMaxEpochs
            // 
            numMaxEpochs.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numMaxEpochs.Location = new Point(187, 138);
            numMaxEpochs.Margin = new Padding(2, 3, 2, 3);
            numMaxEpochs.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numMaxEpochs.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numMaxEpochs.Name = "numMaxEpochs";
            numMaxEpochs.Size = new Size(106, 39);
            numMaxEpochs.TabIndex = 3;
            numMaxEpochs.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(6, 136);
            label10.Name = "label10";
            label10.Size = new Size(176, 37);
            label10.TabIndex = 2;
            label10.Text = "Max Epochs:";
            // 
            // numLearningRate
            // 
            numLearningRate.DecimalPlaces = 4;
            numLearningRate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numLearningRate.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numLearningRate.Location = new Point(248, 74);
            numLearningRate.Margin = new Padding(2, 3, 2, 3);
            numLearningRate.Name = "numLearningRate";
            numLearningRate.Size = new Size(162, 39);
            numLearningRate.TabIndex = 1;
            numLearningRate.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(6, 72);
            label9.Name = "label9";
            label9.Size = new Size(246, 37);
            label9.TabIndex = 0;
            label9.Text = "Learning Rate (α):";
            // 
            // tabTesting
            // 
            tabTesting.Controls.Add(groupBoxConfusion);
            tabTesting.Controls.Add(groupBoxMetrics);
            tabTesting.Controls.Add(groupBoxTestActions);
            tabTesting.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            tabTesting.Location = new Point(8, 46);
            tabTesting.Name = "tabTesting";
            tabTesting.Size = new Size(2285, 1230);
            tabTesting.TabIndex = 3;
            tabTesting.Text = "Testing";
            tabTesting.UseVisualStyleBackColor = true;
            // 
            // groupBoxConfusion
            // 
            groupBoxConfusion.BackColor = Color.Gainsboro;
            groupBoxConfusion.Controls.Add(lblFN);
            groupBoxConfusion.Controls.Add(lblFP);
            groupBoxConfusion.Controls.Add(lblTN);
            groupBoxConfusion.Controls.Add(lblTP);
            groupBoxConfusion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxConfusion.Location = new Point(415, 824);
            groupBoxConfusion.Name = "groupBoxConfusion";
            groupBoxConfusion.Size = new Size(1304, 325);
            groupBoxConfusion.TabIndex = 2;
            groupBoxConfusion.TabStop = false;
            groupBoxConfusion.Text = "Confusion";
            // 
            // lblFN
            // 
            lblFN.AutoSize = true;
            lblFN.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblFN.ForeColor = Color.DarkRed;
            lblFN.Location = new Point(741, 181);
            lblFN.Name = "lblFN";
            lblFN.Size = new Size(239, 50);
            lblFN.TabIndex = 4;
            lblFN.Text = "False Neg: --";
            // 
            // lblFP
            // 
            lblFP.AutoSize = true;
            lblFP.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblFP.ForeColor = Color.DarkRed;
            lblFP.Location = new Point(741, 76);
            lblFP.Name = "lblFP";
            lblFP.Size = new Size(228, 50);
            lblFP.TabIndex = 3;
            lblFP.Text = "False Pos: --";
            // 
            // lblTN
            // 
            lblTN.AutoSize = true;
            lblTN.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblTN.ForeColor = Color.SeaGreen;
            lblTN.Location = new Point(344, 181);
            lblTN.Name = "lblTN";
            lblTN.Size = new Size(230, 50);
            lblTN.TabIndex = 2;
            lblTN.Text = "True Neg: --";
            // 
            // lblTP
            // 
            lblTP.AutoSize = true;
            lblTP.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblTP.ForeColor = Color.SeaGreen;
            lblTP.Location = new Point(344, 76);
            lblTP.Name = "lblTP";
            lblTP.Size = new Size(219, 50);
            lblTP.TabIndex = 1;
            lblTP.Text = "True Pos: --";
            // 
            // groupBoxMetrics
            // 
            groupBoxMetrics.BackColor = Color.Gainsboro;
            groupBoxMetrics.Controls.Add(lblFNR);
            groupBoxMetrics.Controls.Add(lblMSE);
            groupBoxMetrics.Controls.Add(lblF1Score);
            groupBoxMetrics.Controls.Add(lblRecall);
            groupBoxMetrics.Controls.Add(lblPrecision);
            groupBoxMetrics.Controls.Add(lblAccuracy);
            groupBoxMetrics.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxMetrics.Location = new Point(415, 411);
            groupBoxMetrics.Name = "groupBoxMetrics";
            groupBoxMetrics.Size = new Size(1304, 337);
            groupBoxMetrics.TabIndex = 1;
            groupBoxMetrics.TabStop = false;
            groupBoxMetrics.Text = "Performance Metrics";
            // 
            // lblFNR
            // 
            lblFNR.AutoSize = true;
            lblFNR.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblFNR.Location = new Point(687, 217);
            lblFNR.Name = "lblFNR";
            lblFNR.Size = new Size(327, 50);
            lblFNR.TabIndex = 4;
            lblFNR.Text = "False Neg Rate: --";
            // 
            // lblMSE
            // 
            lblMSE.AutoSize = true;
            lblMSE.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblMSE.Location = new Point(687, 158);
            lblMSE.Name = "lblMSE";
            lblMSE.Size = new Size(148, 50);
            lblMSE.TabIndex = 2;
            lblMSE.Text = "MSE: --";
            // 
            // lblF1Score
            // 
            lblF1Score.AutoSize = true;
            lblF1Score.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblF1Score.Location = new Point(687, 90);
            lblF1Score.Name = "lblF1Score";
            lblF1Score.Size = new Size(224, 50);
            lblF1Score.TabIndex = 3;
            lblF1Score.Text = "F1-Score: --";
            // 
            // lblRecall
            // 
            lblRecall.AutoSize = true;
            lblRecall.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblRecall.Location = new Point(344, 217);
            lblRecall.Name = "lblRecall";
            lblRecall.Size = new Size(194, 54);
            lblRecall.TabIndex = 2;
            lblRecall.Text = "Recall: --";
            // 
            // lblPrecision
            // 
            lblPrecision.AutoSize = true;
            lblPrecision.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecision.Location = new Point(344, 158);
            lblPrecision.Name = "lblPrecision";
            lblPrecision.Size = new Size(231, 50);
            lblPrecision.TabIndex = 1;
            lblPrecision.Text = "Precision: --";
            // 
            // lblAccuracy
            // 
            lblAccuracy.AutoSize = true;
            lblAccuracy.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblAccuracy.Location = new Point(344, 90);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(229, 50);
            lblAccuracy.TabIndex = 0;
            lblAccuracy.Text = "Accuracy: --";
            // 
            // groupBoxTestActions
            // 
            groupBoxTestActions.BackColor = Color.Gainsboro;
            groupBoxTestActions.Controls.Add(btnLoadTestData);
            groupBoxTestActions.Controls.Add(btnTestModel);
            groupBoxTestActions.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBoxTestActions.Location = new Point(415, 52);
            groupBoxTestActions.Name = "groupBoxTestActions";
            groupBoxTestActions.Size = new Size(1304, 262);
            groupBoxTestActions.TabIndex = 0;
            groupBoxTestActions.TabStop = false;
            groupBoxTestActions.Text = "Test Actions";
            // 
            // btnLoadTestData
            // 
            btnLoadTestData.BackColor = Color.SkyBlue;
            btnLoadTestData.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadTestData.ForeColor = Color.White;
            btnLoadTestData.Location = new Point(392, 39);
            btnLoadTestData.Name = "btnLoadTestData";
            btnLoadTestData.Size = new Size(463, 83);
            btnLoadTestData.TabIndex = 1;
            btnLoadTestData.Text = "Load Test Data";
            btnLoadTestData.UseVisualStyleBackColor = false;
            btnLoadTestData.Click += btnLoadTestData_Click;
            // 
            // btnTestModel
            // 
            btnTestModel.BackColor = Color.SteelBlue;
            btnTestModel.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnTestModel.ForeColor = Color.White;
            btnTestModel.Location = new Point(392, 151);
            btnTestModel.Name = "btnTestModel";
            btnTestModel.Size = new Size(463, 83);
            btnTestModel.TabIndex = 0;
            btnTestModel.Text = "Test Model on Data Set";
            btnTestModel.UseVisualStyleBackColor = false;
            btnTestModel.Click += btnTestModel_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator1, btnSaveModel, btnLoadModel, toolStripSeparator2, toolStripSeparator3 });
            toolStrip1.Location = new Point(1923, 9);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(393, 42);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 42);
            // 
            // btnSaveModel
            // 
            btnSaveModel.Image = (Image)resources.GetObject("btnSaveModel.Image");
            btnSaveModel.ImageTransparentColor = Color.Magenta;
            btnSaveModel.Name = "btnSaveModel";
            btnSaveModel.Size = new Size(176, 36);
            btnSaveModel.Text = "Save Model";
            btnSaveModel.Click += btnSaveModel_Click;
            // 
            // btnLoadModel
            // 
            btnLoadModel.Image = (Image)resources.GetObject("btnLoadModel.Image");
            btnLoadModel.ImageTransparentColor = Color.Magenta;
            btnLoadModel.Name = "btnLoadModel";
            btnLoadModel.Size = new Size(177, 36);
            btnLoadModel.Text = "Load Model";
            btnLoadModel.Click += btnLoadModel_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 42);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 42);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2301, 1325);
            Controls.Add(toolStrip1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anomaly Detection";
            tabControl1.ResumeLayout(false);
            tabData.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDataPreview).EndInit();
            groupBoxPreprocess.ResumeLayout(false);
            groupBoxDataset.ResumeLayout(false);
            tabConfig.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBoxNetworkInfo.ResumeLayout(false);
            groupBoxNetworkInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbNetworkCanvas).EndInit();
            groupBoxArchitecture.ResumeLayout(false);
            groupBoxArchitecture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNeuronsLayer3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNeuronsLayer2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNeuronsLayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHiddenLayers).EndInit();
            tabTraining.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartLoss).EndInit();
            groupBoxProgress.ResumeLayout(false);
            groupBoxProgress.PerformLayout();
            groupBoxTrainingControl.ResumeLayout(false);
            groupBoxHyperparams.ResumeLayout(false);
            groupBoxHyperparams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnomalyThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetError).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxEpochs).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLearningRate).EndInit();
            tabTesting.ResumeLayout(false);
            groupBoxConfusion.ResumeLayout(false);
            groupBoxConfusion.PerformLayout();
            groupBoxMetrics.ResumeLayout(false);
            groupBoxMetrics.PerformLayout();
            groupBoxTestActions.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabData;
        private TabPage tabConfig;
        private TabPage tabTraining;
        private TabPage tabTesting;
        private GroupBox groupBoxDataset;
        private Button btnLoadData;
        private GroupBox groupBoxPreprocess;
        private Button btnNormalizeData;
        private DataGridView dgvDataPreview;
        private GroupBox groupBoxArchitecture;
        private Label label4;
        private NumericUpDown numHiddenLayers;
        private Label label5;
        private Label lblInputCount;
        private NumericUpDown numNeuronsLayer1;
        private Label lblLayer1;
        private NumericUpDown numNeuronsLayer3;
        private Label lblLayer3;
        private NumericUpDown numNeuronsLayer2;
        private Label lblLayer2;
        private ComboBox cmbActivationFunction;
        private Label label7;
        private Label lblOutputCount;
        private Label label6;
        private GroupBox groupBoxNetworkInfo;
        private ComboBox cmbInitMethod;
        private Label label8;
        private Button btnCreateNetwork;
        private Label lblNetworkStatus;
        private GroupBox groupBoxHyperparams;
        private NumericUpDown numLearningRate;
        private Label label9;
        private NumericUpDown numMaxEpochs;
        private Label label10;
        private CheckBox chkUseValidation;
        private NumericUpDown numTargetError;
        private Label label11;
        private GroupBox groupBoxTrainingControl;
        private GroupBox groupBoxProgress;
        private Button btnStopTraining;
        private Button btnStartTraining;
        private Label lblCurrentLoss;
        private Label lblCurrentEpoch;
        private Label lblValidationLoss;
        private ProgressBar progressBarTraining;
        private Label lblETA;
        private Label lblTimeElapsed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoss;
        private GroupBox groupBoxTestActions;
        private Button btnTestModel;
        private GroupBox groupBoxMetrics;
        private Label lblF1Score;
        private Label lblRecall;
        private Label lblPrecision;
        private Label lblAccuracy;
        private GroupBox groupBoxConfusion;
        private Label lblFNR;
        private Label lblMSE;
        private Label lblFN;
        private Label lblFP;
        private Label lblTN;
        private Label lblTP;
        private ToolStrip toolStrip1;
        private ToolStripButton btnSaveModel;
        private ToolStripButton btnLoadModel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private Button btnPreprocess;
        private Button btnLoadTestData;
        private GroupBox groupBox1;
        private PictureBox pbNetworkCanvas;
        private GroupBox groupBox2;
        private RadioButton rbMLP;
        private RadioButton rbAutoencoder;
        private NumericUpDown numAnomalyThreshold;
        private Label label1;
        private RadioButton rbKMeans;
        private RadioButton rbLogisticRegression;
    }
}