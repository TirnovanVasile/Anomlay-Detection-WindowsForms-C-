using Proiect_IA_3.Models;
using Proiect_IA_3.Services;
using Proiect_IA_3.Services.Autoencoder;
using Proiect_IA_3.MLNet.Services;
using System.Diagnostics; 

namespace Proiect_IA_3
{
    public partial class MainForm : Form
    {
        private DataManager dataManager;
        private NeuralNetwork network;
        private TrainingEngine trainingEngine;
        private ModelEvaluator evaluator;

        private AutoencoderDataManager autoencoderDataManager;
        private AutoencoderTrainingEngine autoencoderEngine;
        private AutoencoderEvaluator autoencoderEvaluator;

        private MLNetEngine mlNetEngine;

        private Stopwatch trainingStopwatch;


        private int[] currentNetworkTopology = null;


        public MainForm()
        {
            InitializeComponent();
            InitializeLogic();
            pbNetworkCanvas.Paint += pbNetworkCanvas_Paint;

            autoencoderDataManager = new AutoencoderDataManager();
            autoencoderEvaluator = new AutoencoderEvaluator();

            mlNetEngine = new MLNetEngine();
        }

        private void InitializeLogic()
        {
            dataManager = new DataManager();
            evaluator = new ModelEvaluator();
            trainingStopwatch = new Stopwatch();

            if (cmbActivationFunction.Items.Count > 0)
                cmbActivationFunction.SelectedIndex = 0;

            if (cmbInitMethod.Items.Count > 0)
                cmbInitMethod.SelectedIndex = 1;

            UpdateUIState();
        }

        private void UpdateUIState()
        {
            if (numAnomalyThreshold != null)
                numAnomalyThreshold.Enabled = rbAutoencoder.Checked;

            bool hasData = dataManager != null && dataManager.HasData;

            bool isMLNetSelected = rbLogisticRegression.Checked || rbKMeans.Checked;

            bool hasNetwork = network != null;
            bool isCustomTrained = hasNetwork && network.IsTrained;
            bool isMLNetTrained = mlNetEngine != null && mlNetEngine.IsTrained;

            bool isTrained = (isCustomTrained && !isMLNetSelected) || (isMLNetTrained && isMLNetSelected);

            bool isTraining = (trainingEngine?.IsTraining == true) || (autoencoderEngine?.IsTraining == true);

            btnNormalizeData.Enabled = hasData;

            btnCreateNetwork.Enabled = hasData && !isTraining && !isMLNetSelected;

            btnStartTraining.Enabled = hasData && !isTraining && (hasNetwork || isMLNetSelected);

            btnStopTraining.Enabled = isTraining;

            bool hasTestData = dataManager?.TestInputs != null && dataManager.TestInputs.Count > 0;

            btnTestModel.Enabled = isTrained && hasTestData;

            if (btnSaveModel != null)
                btnSaveModel.Enabled = isCustomTrained && !isMLNetSelected;
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string destDir = Path.Combine(Application.StartupPath, "PreprocessedData");
            try
            {
                Cursor = Cursors.WaitCursor;
                dataManager.LoadCSV(Path.Combine(destDir, "train_normal.csv"), false);
                dataManager.LoadCSV(Path.Combine(destDir, "train_faulty.csv"), true);

                DisplayDataPreview();
                UpdateUIState();
                if (lblInputCount != null) lblInputCount.Text = dataManager.InputCount + " sensors";
                MessageBox.Show($"Train Data Loaded: {dataManager.TotalSamples} samples.");
            }
            catch (Exception ex) { MessageBox.Show("Error: Did you run preprocessing? " + ex.Message); }
            finally { Cursor = Cursors.Default; }
        }

        private void btnPreprocess_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select the folder containing the 4 original TEP CSV files." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string destDir = Path.Combine(Application.StartupPath, "PreprocessedData");
                    var preprocessor = new DataPreprocessor();

                    Task.Run(() =>
                    {
                        preprocessor.ProcessAllTEP(fbd.SelectedPath, destDir, (msg) =>
                        {
                            this.Invoke(new Action(() => lblNetworkStatus.Text = msg));
                        });
                        this.Invoke(new Action(() => MessageBox.Show($"Done! The files have been saved in: {destDir}")));
                    });
                }
            }
        }
        private void DisplayDataPreview()
        {
            dgvDataPreview.DataSource = dataManager.GetPreviewDataTable(1000);
            dgvDataPreview.AutoResizeColumns();

            dgvDataPreview.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvDataPreview.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvDataPreview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDataPreview.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            if (dgvDataPreview.Columns.Count > 0)
            {
                var lastColumn = dgvDataPreview.Columns[dgvDataPreview.Columns.Count - 1];
                lastColumn.DefaultCellStyle.BackColor = Color.LightYellow;
                lastColumn.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void btnNormalizeData_Click(object sender, EventArgs e)
        {
            try
            {
                dataManager.NormalizeData();
                dataManager.ShuffleAndSplitTrainValidation();
                DisplayDataPreview();
                UpdateUIState();
                MessageBox.Show("The data has been normalized and shuffled! Ready for training.");

                int defecte = dataManager.TrainOutputs.Count(outList => outList[0] >= 0.5);
                int normale = dataManager.TrainOutputs.Count - defecte;
                int validare = dataManager.ValidationCount;
                double procentaj = (double)defecte / dataManager.TrainOutputs.Count * 100;

                MessageBox.Show($"Training Set Diagnostics:\n\n" +
                    $"Normal Data (0): {normale}\n" +
                    $"Faulty Data (1): {defecte}\n" +
                    $"Fault Percentage: {procentaj:F2}%\n\n" +
                    $"Validation Data (10%): {validare}",
                    "Data Analysis");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnLoadTestData_Click(object sender, EventArgs e)
        {
            string destDir = Path.Combine(Application.StartupPath, "PreprocessedData");
            try
            {
                Cursor = Cursors.WaitCursor;
                DataManager testReader = new DataManager();
                testReader.LoadCSV(Path.Combine(destDir, "test_normal.csv"), false);
                testReader.LoadCSV(Path.Combine(destDir, "test_faulty.csv"), true);

                dataManager.PrepareTestData(testReader.rawInputs, testReader.rawOutputs);
                UpdateUIState();
                MessageBox.Show($"Test Set loaded and normalized: {dataManager.TestInputs.Count} samples.");
            }
            catch (Exception ex) { MessageBox.Show("Error loading test data: " + ex.Message); }
            finally { Cursor = Cursors.Default; }
        }


        private void btnCreateNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                int outputNeuronsCount = rbAutoencoder.Checked ? dataManager.InputCount : 1;

                NetworkConfiguration config = new NetworkConfiguration
                {
                    InputNeurons = dataManager.InputCount,
                    OutputNeurons = outputNeuronsCount,
                    HiddenLayerCount = (int)numHiddenLayers.Value,
                    HiddenNeuronCounts = new List<int>()
                };


                if (rbAutoencoder.Checked)
                {
                    List<int> encoderLayers = new List<int>();
                    if (config.HiddenLayerCount >= 1) encoderLayers.Add((int)numNeuronsLayer1.Value);
                    if (config.HiddenLayerCount >= 2) encoderLayers.Add((int)numNeuronsLayer2.Value);
                    if (config.HiddenLayerCount >= 3) encoderLayers.Add((int)numNeuronsLayer3.Value);

                    config.HiddenNeuronCounts.AddRange(encoderLayers);

                    if (encoderLayers.Count > 1)
                    {
                        for (int i = encoderLayers.Count - 2; i >= 0; i--)
                        {
                            config.HiddenNeuronCounts.Add(encoderLayers[i]);
                        }
                    }

                    config.HiddenLayerCount = config.HiddenNeuronCounts.Count;
                }
                else
                {
                    if (config.HiddenLayerCount >= 1) config.HiddenNeuronCounts.Add((int)numNeuronsLayer1.Value);
                    if (config.HiddenLayerCount >= 2) config.HiddenNeuronCounts.Add((int)numNeuronsLayer2.Value);
                    if (config.HiddenLayerCount >= 3) config.HiddenNeuronCounts.Add((int)numNeuronsLayer3.Value);
                }

                ActivationType activation = ActivationType.Sigmoid;
                if (cmbActivationFunction.SelectedIndex == 0)
                    activation = ActivationType.Sigmoid;
                else if (cmbActivationFunction.SelectedIndex == 1)
                    activation = ActivationType.Tanh;
                else if (cmbActivationFunction.SelectedIndex == 2)
                    activation = ActivationType.ReLU;

                network = new NeuralNetwork();
                network.SetInputNeurons(config.InputNeurons);

                foreach (int count in config.HiddenNeuronCounts)
                {
                    network.AddHiddenLayer(count);
                }

                network.CreateOutputLayer(config.OutputNeurons);

                foreach (var layer in network.HiddenLayers)
                {
                    layer.activationType = activation;
                    layer.ginType = GinType.Sum;
                    layer.outputType = OutputType.Real;
                    layer.g = 1.0;
                }

                network.OutputLayer.activationType = ActivationType.Sigmoid;
                network.OutputLayer.ginType = GinType.Sum;
                network.OutputLayer.outputType = OutputType.Real;
                network.OutputLayer.g = 1.0;

                InitializeWeights(cmbInitMethod.SelectedIndex);

                string architecture = "" + config.InputNeurons;
                foreach (int neurons in config.HiddenNeuronCounts)
                    architecture += "-" + neurons;
                architecture += "-" + config.OutputNeurons;

                lblNetworkStatus.Text = "OK Network created: " + architecture + "\n" +
                                        "Activation: " + cmbActivationFunction.Text + " | " +
                                        "Initialization: " + cmbInitMethod.Text;
                lblNetworkStatus.ForeColor = Color.Green;


                List<int> topology = new List<int>();
                topology.Add(config.InputNeurons);
                topology.AddRange(config.HiddenNeuronCounts);
                topology.Add(config.OutputNeurons);

                currentNetworkTopology = topology.ToArray();
                pbNetworkCanvas.Invalidate();

                UpdateUIState();

                MessageBox.Show(
                  " Neural Network Created Successfully!\n\n" +
                  "Architecture: " + architecture + "\n" +
                  "Total Layers: " + (config.HiddenLayerCount + 2) + "\n" +
                  "Activation Function: " + cmbActivationFunction.Text + "\n" +
                  "Initialization Method: " + cmbInitMethod.Text + "\n\n",
                  "Network Created",
                  MessageBoxButtons.OK
                );

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating network:\n" + ex.Message,
                  "Error", MessageBoxButtons.OK);

                lblNetworkStatus.Text = "Error during creation";
                lblNetworkStatus.ForeColor = Color.Red;
            }
        }


        private void InitializeWeights(int method)
        {
            Random rand = new Random(42);

            foreach (var layer in network.HiddenLayers)
            {
                foreach (var neuron in layer.neurons)
                {
                    int inputCount = neuron.weights.Count;

                    for (int i = 0; i < inputCount; i++)
                    {
                        switch (method)
                        {
                            case 0:
                                neuron.weights[i] = rand.NextDouble() * 2.0 - 1.0;
                                break;

                            case 1:
                                double xavier = Math.Sqrt(6.0 / (inputCount + layer.neurons.Count));
                                neuron.weights[i] = (rand.NextDouble() * 2.0 - 1.0) * xavier;
                                break;
                        }
                    }
                }
            }

            foreach (var neuron in network.OutputLayer.neurons)
            {
                int inputCount = neuron.weights.Count;

                for (int i = 0; i < inputCount; i++)
                {
                    switch (method)
                    {
                        case 0:
                            neuron.weights[i] = rand.NextDouble() * 2.0 - 1.0;
                            break;
                        case 1:
                            double xavier = Math.Sqrt(6.0 / (inputCount + network.OutputLayer.neurons.Count));
                            neuron.weights[i] = (rand.NextDouble() * 2.0 - 1.0) * xavier;
                            break;
                    }
                }
            }
        }
        private void numHiddenLayers_ValueChanged_1(object sender, EventArgs e)
        {
            int layers = (int)numHiddenLayers.Value;

            numNeuronsLayer1.Enabled = layers >= 1;
            lblLayer1.Enabled = layers >= 1;

            numNeuronsLayer2.Enabled = layers >= 2;
            lblLayer2.Enabled = layers >= 2;

            numNeuronsLayer3.Enabled = layers >= 3;
            lblLayer3.Enabled = layers >= 3;
        }


        private void btnStartTraining_Click(object sender, EventArgs e)
        {
            try
            {
                btnStartTraining.Enabled = false;

                string detectionMethod = "";
                string dataInfo = "";
                int sampleCount = 0;

                if (rbLogisticRegression.Checked || rbKMeans.Checked)
                {
                    sampleCount = dataManager.TrainCount;

                    if (rbLogisticRegression.Checked)
                    {
                        detectionMethod = "Logistic Regression (ML.NET)";
                        dataInfo = "Mixed data (Supervised - using the labels)";
                        mlNetEngine.TrainLogisticRegression(dataManager);
                    }
                    else 
                    {
                        detectionMethod = "K-Means Clustering (ML.NET)";
                        dataInfo = "Mixed data (Unsupervised - ignores the labels, finds 2 clusters)";
                        mlNetEngine.TrainKMeans(dataManager);
                    }


                    UpdateUIState();

                    MessageBox.Show($"{detectionMethod} was successfully trained in just a few seconds!\n" +
                                    $"Samples: {sampleCount}\n" +
                                    $"Data: {dataInfo}\n\n" +
                                    $"Now you can go to the Testing tab.",
                                    "Training Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return; 
                }

                else
                {
                    btnStopTraining.Enabled = true; 
                    progressBarTraining.Value = 0;
                    progressBarTraining.Maximum = (int)numMaxEpochs.Value;
                    InitializeTrainingChart();
                    trainingStopwatch.Restart();

                    if (rbAutoencoder.Checked)
                    {
                        autoencoderDataManager.PrepareDataFromMLP(dataManager);

                        autoencoderEngine = new AutoencoderTrainingEngine(network, autoencoderDataManager);
                        autoencoderEngine.LearningRate = (double)numLearningRate.Value;
                        autoencoderEngine.MaxEpochs = (int)numMaxEpochs.Value;
                        autoencoderEngine.TargetError = (double)numTargetError.Value;
                        autoencoderEngine.UseValidation = chkUseValidation.Checked;

                        detectionMethod = "Autoencoder (Unsupervised)";
                        sampleCount = autoencoderDataManager.TrainCount;
                        dataInfo = "Clean data only (Normal states)";

                        autoencoderEngine.EpochCompleted += TrainingEngine_EpochCompleted;
                        autoencoderEngine.TrainingCompleted += TrainingEngine_TrainingCompleted;
                        autoencoderEngine.StartTrainingAsync();
                    }
                    else 
                    {
                        trainingEngine = new TrainingEngine(network, dataManager);
                        trainingEngine.LearningRate = (double)numLearningRate.Value;
                        trainingEngine.MaxEpochs = (int)numMaxEpochs.Value;
                        trainingEngine.TargetError = (double)numTargetError.Value;
                        trainingEngine.UseValidation = chkUseValidation.Checked;

                        detectionMethod = "Multi-Layer Perceptron (Supervised)";
                        sampleCount = dataManager.TrainCount;
                        dataInfo = "Mixed data (Clean + Faulty samples)";

                        trainingEngine.EpochCompleted += TrainingEngine_EpochCompleted;
                        trainingEngine.TrainingCompleted += TrainingEngine_TrainingCompleted;
                        trainingEngine.StartTrainingAsync();
                    }

                    string message = $"Training has started!\n\n" +
                                     $"Detection Method: {detectionMethod}\n" +
                                     $"Training Samples: {sampleCount}\n" +
                                     $"Data Type: {dataInfo}\n\n" +
                                     $"Monitor the progress:\n" +
                                     $"- Loss Chart (should decrease)\n" +
                                     $"- Validation Loss (should not increase)\n" +
                                     $"- Progress Bar\n\n" +
                                     $"You can stop the training anytime with the STOP button.";

                    MessageBox.Show(message, "Training Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting training:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopTraining_Click(object sender, EventArgs e)
        {
            if (rbAutoencoder.Checked && autoencoderEngine != null && autoencoderEngine.IsTraining)
            {
                autoencoderEngine.StopTraining();
                MessageBox.Show("Autoencoder training stopped!", "Stop", MessageBoxButtons.OK);
            }
            else if (!rbAutoencoder.Checked && trainingEngine != null && trainingEngine.IsTraining)
            {
                trainingEngine.StopTraining();
                MessageBox.Show("MLP training stopped!", "Stop", MessageBoxButtons.OK);
            }
        }

        private void InitializeTrainingChart()
        {
            chartLoss.Series.Clear();
            chartLoss.ChartAreas[0].AxisX.Title = "Epoch";
            chartLoss.ChartAreas[0].AxisY.Title = "Loss (MSE)";
            chartLoss.ChartAreas[0].BackColor = Color.WhiteSmoke;

            var seriesTrain = chartLoss.Series.Add("Training Loss");
            seriesTrain.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesTrain.Color = Color.Blue;
            seriesTrain.BorderWidth = 2;

            if (chkUseValidation.Checked)
            {
                var seriesValid = chartLoss.Series.Add("Validation Loss");
                seriesValid.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                seriesValid.Color = Color.Red;
                seriesValid.BorderWidth = 2;
                seriesValid.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            }
        }

        private void TrainingEngine_EpochCompleted(object sender, EpochCompletedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EpochCompletedEventArgs>(TrainingEngine_EpochCompleted), sender, e);
                return;
            }

            int currentMaxEpochs = rbAutoencoder.Checked ? autoencoderEngine.MaxEpochs : trainingEngine.MaxEpochs;

            if (e.Epoch <= progressBarTraining.Maximum)
                progressBarTraining.Value = e.Epoch;

            chartLoss.Series["Training Loss"].Points.AddXY(e.Epoch, e.TrainingLoss);

            if (chkUseValidation.Checked && chartLoss.Series.IndexOf("Validation Loss") >= 0)
            {
                chartLoss.Series["Validation Loss"].Points.AddXY(e.Epoch, e.ValidationLoss);
            }

            lblCurrentEpoch.Text = "Epoch: " + e.Epoch + " / " + currentMaxEpochs;
            lblCurrentLoss.Text = "Training Loss: " + e.TrainingLoss.ToString("F6");
            lblValidationLoss.Text = "Validation Loss: " + e.ValidationLoss.ToString("F6");

            double avgTimePerEpoch = trainingStopwatch.Elapsed.TotalSeconds / e.Epoch;

            int remainingEpochs = currentMaxEpochs - e.Epoch;

            TimeSpan eta = TimeSpan.FromSeconds(avgTimePerEpoch * remainingEpochs);

            lblTimeElapsed.Text = "Time: " + trainingStopwatch.Elapsed.ToString("hh\\:mm\\:ss");
            lblETA.Text = "ETA: " + eta.ToString("hh\\:mm\\:ss");
        }

        private void TrainingEngine_TrainingCompleted(object sender, TrainingCompletedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, TrainingCompletedEventArgs>(TrainingEngine_TrainingCompleted), sender, e);
                return;
            }

            trainingStopwatch.Stop();

            btnStartTraining.Enabled = false;
            btnStopTraining.Enabled = false;

            network.IsTrained = true;
            UpdateUIState();

            MessageBox.Show(
              " Training Complete!\n\n" +
              "Epochs: " + e.TotalEpochs + "\n" +
              "Final Loss: " + e.FinalLoss.ToString("F6") + "\n" +
              "Total Time: " + e.TrainingTime.TotalSeconds.ToString("F1") + "s\n\n",
              "Training Finished",
              MessageBoxButtons.OK
            );
        }



        private void btnTestModel_Click(object sender, EventArgs e)
        {
            try
            {

                if (rbLogisticRegression.Checked || rbKMeans.Checked)
                {
                    bool isKMeans = rbKMeans.Checked;
                    var predictions = mlNetEngine.PredictAll(dataManager.TestInputs, isKMeans);
                    var metrics = CalculateMLNetMetrics(predictions, dataManager.TestOutputs);

                    double accuracy = (double)(metrics.TruePositives + metrics.TrueNegatives) / predictions.Count * 100.0;

                    lblAccuracy.Text = "Accuracy: " + accuracy.ToString("F2") + "%";
                    lblPrecision.Text = "Precision: " + metrics.Precision.ToString("P2");
                    lblRecall.Text = "Recall: " + metrics.Recall.ToString("P2");
                    lblF1Score.Text = "F1-Score: " + metrics.F1Score.ToString("F4");
                    lblFNR.Text = "False Neg Rate: " + metrics.FalseNegativeRate.ToString("P2");

                    lblTP.Text = "True Pos: " + metrics.TruePositives;
                    lblTN.Text = "True Neg: " + metrics.TrueNegatives;
                    lblFP.Text = "False Pos: " + metrics.FalsePositives;
                    lblFN.Text = "False Neg: " + metrics.FalseNegatives;

                    lblMSE.Text = rbLogisticRegression.Checked ? "Mode: ML.NET Logistic Regression" : "Mode: ML.NET K-Means Clustering";

                    MessageBox.Show("ML.NET model tested successfully!", "Testing Complete", MessageBoxButtons.OK);
                }
                else if (rbAutoencoder.Checked)
                {
                    autoencoderDataManager.PrepareDataFromMLP(dataManager);

                    double threshold = (double)numAnomalyThreshold.Value;
                    var results = autoencoderEvaluator.Evaluate(network, autoencoderDataManager, threshold);

                    lblAccuracy.Text = "Accuracy: " + results.Accuracy.ToString("F2") + "%";
                    lblPrecision.Text = "Precision: " + results.Precision.ToString("P2");
                    lblRecall.Text = "Recall: " + results.Recall.ToString("P2");
                    lblF1Score.Text = "F1-Score: " + results.F1Score.ToString("F4");

                    lblTP.Text = "True Pos: " + results.TruePositives;
                    lblTN.Text = "True Neg: " + results.TrueNegatives;
                    lblFP.Text = "False Pos: " + results.FalsePositives;
                    lblFN.Text = "False Neg: " + results.FalseNegatives;

                    lblMSE.Text = "Mode: Autoencoder";

                    MessageBox.Show("Autoencoder Tested Successfully!", "Testing Complete", MessageBoxButtons.OK);
                }
                else
                {
                    var testResults = evaluator.Evaluate(network, dataManager.TestInputs, dataManager.TestOutputs);
                    var anomalyMetrics = CalculateAnomalyMetrics(testResults);

                    lblAccuracy.Text = "Accuracy: " + testResults.Accuracy.ToString("F2") + "%";
                    lblPrecision.Text = "Precision: " + anomalyMetrics.Precision.ToString("P2");
                    lblRecall.Text = "Recall: " + anomalyMetrics.Recall.ToString("P2");
                    lblF1Score.Text = "F1-Score: " + anomalyMetrics.F1Score.ToString("F4");
                    lblMSE.Text = "MSE: " + testResults.MSE.ToString("F6");
                    lblFNR.Text = "False Neg Rate: " + anomalyMetrics.FalseNegativeRate.ToString("P2");

                    lblTP.Text = "True Pos: " + anomalyMetrics.TruePositives;
                    lblTN.Text = "True Neg: " + anomalyMetrics.TrueNegatives;
                    lblFP.Text = "False Pos: " + anomalyMetrics.FalsePositives;
                    lblFN.Text = "False Neg: " + anomalyMetrics.FalseNegatives;

                    MessageBox.Show("MLP Tested Successfully!", "Testing Complete", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during testing:\n" + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private AnomalyMetrics CalculateAnomalyMetrics(EvaluationResults results)
        {
            var metrics = new AnomalyMetrics();

            for (int i = 0; i < results.Predictions.Count; i++)
            {
                int predicted;
                if (results.Predictions[i][0] > 0.3) //!!!
                    predicted = 1;
                else
                    predicted = 0;

                int actual = (int)Math.Round(results.ActualValues[i][0]);

                if (predicted == 1 && actual == 1)
                    metrics.TruePositives++;
                else if (predicted == 0 && actual == 0)
                    metrics.TrueNegatives++;
                else if (predicted == 1 && actual == 0)
                    metrics.FalsePositives++;
                else if (predicted == 0 && actual == 1)
                    metrics.FalseNegatives++;
            }

            return metrics;
        }

        private AnomalyMetrics CalculateMLNetMetrics(List<int> predictions, List<List<double>> actualOutputs)
        {
            var metrics = new AnomalyMetrics();

            for (int i = 0; i < predictions.Count; i++)
            {
                int predicted = predictions[i];
                int actual = (int)Math.Round(actualOutputs[i][0]);

                if (predicted == 1 && actual == 1) metrics.TruePositives++;
                else if (predicted == 0 && actual == 0) metrics.TrueNegatives++;
                else if (predicted == 1 && actual == 0) metrics.FalsePositives++;
                else if (predicted == 0 && actual == 1) metrics.FalseNegatives++;
            }

            return metrics;
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Model MLP (*.mlp)|*.mlp|JSON Files (*.json)|*.json";
                sfd.Title = "Save the trained model";
                sfd.DefaultExt = "mlp";
                sfd.FileName = "FaultyDetection_Model_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ModelSerializer.SaveModel(network, sfd.FileName);

                        MessageBox.Show(
                          " Model saved successfully!\n\n" +
                          "Location: " + sfd.FileName + "\n\n" +
                          "You can load this model later\n" +
                          "to continue making predictions!",
                          "Model Saved",
                          MessageBoxButtons.OK
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving the model:\n" + ex.Message,
                          "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Model MLP (*.mlp)|*.mlp|JSON Files (*.json)|*.json";
                ofd.Title = "Load trained model";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        network = ModelSerializer.LoadModel(ofd.FileName);
                        network.IsTrained = true;

                        lblNetworkStatus.Text = "OK Model loaded: " + network.InputValues.Count + " inputs, " +
                                    network.HiddenLayers.Count + " hidden layers, " +
                                    network.OutputLayer.neurons.Count + " outputs";
                        lblNetworkStatus.ForeColor = Color.Green;

                        UpdateUIState();
                        MessageBox.Show(
                          " Model loaded successfully!\n\n" +
                          "Architecture:\n" +
                          "- Inputs: " + network.InputValues.Count + "\n" +
                          "- Hidden layers: " + network.HiddenLayers.Count + "\n" +
                          "- Outputs: " + network.OutputLayer.neurons.Count + "\n\n",
                          "Model Loaded",
                          MessageBoxButtons.OK
                          );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading the model:\n" + ex.Message,
                          "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }



        private void pbNetworkCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (currentNetworkTopology == null || currentNetworkTopology.Length < 2) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(SystemColors.Control);

            int width = pbNetworkCanvas.Width;
            int height = pbNetworkCanvas.Height;

            int numLayers = currentNetworkTopology.Length;
            int maxNeurons = currentNetworkTopology.Max();

            float layerSpacing = (float)width / (numLayers + 1);
            float neuronSpacing = (float)height / (maxNeurons + 1);

            float radius = Math.Min(layerSpacing, neuronSpacing) * 0.4f;
            radius = Math.Clamp(radius, 2f, 15f);

            List<PointF>[] positions = new List<PointF>[numLayers];

            for (int i = 0; i < numLayers; i++)
            {
                positions[i] = new List<PointF>();
                int n = currentNetworkTopology[i];

                float x = layerSpacing * (i + 1);
                float totalLayerHeight = (n - 1) * neuronSpacing;
                float startY = (height - totalLayerHeight) / 2f;

                for (int j = 0; j < n; j++)
                {
                    positions[i].Add(new PointF(x, startY + j * neuronSpacing));
                }
            }

            using (Pen synapsePen = new Pen(Color.FromArgb(30, 100, 100, 100), 1f))
            {
                for (int i = 0; i < numLayers - 1; i++)
                {
                    foreach (var from in positions[i])
                    {
                        foreach (var to in positions[i + 1])
                        {
                            g.DrawLine(synapsePen, from, to);
                        }
                    }
                }
            }

            using SolidBrush inputBrush = new SolidBrush(Color.LightGreen);
            using SolidBrush hiddenBrush = new SolidBrush(Color.LightBlue);
            using SolidBrush outputBrush = new SolidBrush(Color.LightPink);
            using Pen borderPen = new Pen(Color.DimGray, Math.Max(1f, radius * 0.1f));

            for (int i = 0; i < numLayers; i++)
            {
                SolidBrush currentBrush = hiddenBrush;
                if (i == 0) currentBrush = inputBrush;
                else if (i == numLayers - 1) currentBrush = outputBrush;

                foreach (var pos in positions[i])
                {
                    g.FillEllipse(currentBrush, pos.X - radius, pos.Y - radius, radius * 2, radius * 2);
                    g.DrawEllipse(borderPen, pos.X - radius, pos.Y - radius, radius * 2, radius * 2);
                }
            }
        }

        private void rbAutoencoder_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAutoencoder.Checked)
            {
                lblOutputCount.Text = dataManager.InputCount + " (Reconstruction)";
                numAnomalyThreshold.Enabled = true;
            }
            else
            {
                lblOutputCount.Text = " 1 (Anomaly Detection)";
                numAnomalyThreshold.Enabled = false;
            }
            UpdateUIState();
        }

        private void UpdateDetectionMethodUI()
        {

            bool isCustomNetwork = rbMLP.Checked || rbAutoencoder.Checked;

            numHiddenLayers.Enabled = isCustomNetwork;
            numNeuronsLayer1.Enabled = isCustomNetwork;
            numNeuronsLayer2.Enabled = isCustomNetwork;
            numNeuronsLayer3.Enabled = isCustomNetwork;
            cmbActivationFunction.Enabled = isCustomNetwork;
            cmbInitMethod.Enabled = isCustomNetwork;

            btnCreateNetwork.Enabled = isCustomNetwork;

            if (rbAutoencoder.Checked)
            {
                lblOutputCount.Text = dataManager.InputCount + " (Reconstruction)";
                numAnomalyThreshold.Enabled = true;
            }
            else
            {
                lblOutputCount.Text = " 1 (Anomaly Detection)";
                numAnomalyThreshold.Enabled = false;
            }

            UpdateUIState();
        }

        private void rbMethod_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDetectionMethodUI();
        }

    }



    public class AnomalyMetrics
    {
        public int TruePositives { get; set; } 
        public int TrueNegatives { get; set; }  
        public int FalsePositives { get; set; } 
        public int FalseNegatives { get; set; } 

        public double Precision
        {
            get
            {
                if (TruePositives + FalsePositives > 0)
                    return (double)TruePositives / (TruePositives + FalsePositives);
                else
                    return 0;
            }
        }
        public double Recall
        {
            get
            {
                if (TruePositives + FalseNegatives > 0)
                    return (double)TruePositives / (TruePositives + FalseNegatives);
                else
                    return 0;
            }
        }
        public double F1Score
        {
            get
            {
                if (Precision + Recall > 0)
                    return 2 * (Precision * Recall) / (Precision + Recall);
                else
                    return 0;
            }
        }
        public double FalseNegativeRate
        {
            get
            {
                if (TruePositives + FalseNegatives > 0)
                    return (double)FalseNegatives / (TruePositives + FalseNegatives);
                else               
                    return 0;
            }
        }
    }
}