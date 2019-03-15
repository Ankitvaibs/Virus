namespace SimulatedSensors.Windows
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textConnectionString = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textAlerts = new System.Windows.Forms.TextBox();
            this.btnGetDevices = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSentCount = new System.Windows.Forms.Label();
            this.textDBConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmbHubDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bacnetControls = new System.Windows.Forms.GroupBox();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.checkBoxVariation = new System.Windows.Forms.CheckBox();
            this.trackBarTemperature = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInstance = new System.Windows.Forms.ComboBox();
            this.cmbObjectType = new System.Windows.Forms.ComboBox();
            this.cmbDeviceId = new System.Windows.Forms.ComboBox();
            this.cmbGatewayId = new System.Windows.Forms.ComboBox();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.labelGateway = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deviceTypes = new System.Windows.Forms.ComboBox();
            this.sbControls = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.presence = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sensorId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deviceId = new System.Windows.Forms.TextBox();
            this.lblSendFrequency = new System.Windows.Forms.Label();
            this.sendFrequency = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.bacnetControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTemperature)).BeginInit();
            this.sbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // textConnectionString
            // 
            this.textConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textConnectionString.Location = new System.Drawing.Point(7, 165);
            this.textConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.textConnectionString.Multiline = true;
            this.textConnectionString.Name = "textConnectionString";
            this.textConnectionString.Size = new System.Drawing.Size(398, 55);
            this.textConnectionString.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SimulatedSensors.Windows.Properties.Resources.SBLogoMedium;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionString.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelConnectionString.Location = new System.Drawing.Point(11, 150);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(181, 13);
            this.labelConnectionString.TabIndex = 4;
            this.labelConnectionString.Text = "Connection String (of IoT Hub)";
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelTemperature.Location = new System.Drawing.Point(11, 525);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(82, 13);
            this.labelTemperature.TabIndex = 6;
            this.labelTemperature.Text = "PresentValue";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(143, 689);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(129, 19);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "Send Data";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // textAlerts
            // 
            this.textAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAlerts.BackColor = System.Drawing.SystemColors.Window;
            this.textAlerts.Location = new System.Drawing.Point(9, 712);
            this.textAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.textAlerts.Multiline = true;
            this.textAlerts.Name = "textAlerts";
            this.textAlerts.ReadOnly = true;
            this.textAlerts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textAlerts.Size = new System.Drawing.Size(398, 143);
            this.textAlerts.TabIndex = 11;
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.Location = new System.Drawing.Point(143, 277);
            this.btnGetDevices.Name = "btnGetDevices";
            this.btnGetDevices.Size = new System.Drawing.Size(127, 23);
            this.btnGetDevices.TabIndex = 17;
            this.btnGetDevices.Text = "Get IoTHub Devices";
            this.btnGetDevices.UseVisualStyleBackColor = true;
            this.btnGetDevices.Click += new System.EventHandler(this.btnGetDevices_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 139);
            this.panel1.TabIndex = 23;
            // 
            // lblSentCount
            // 
            this.lblSentCount.AutoSize = true;
            this.lblSentCount.Location = new System.Drawing.Point(278, 588);
            this.lblSentCount.Name = "lblSentCount";
            this.lblSentCount.Size = new System.Drawing.Size(0, 13);
            this.lblSentCount.TabIndex = 25;
            // 
            // textDBConnectionString
            // 
            this.textDBConnectionString.Location = new System.Drawing.Point(7, 247);
            this.textDBConnectionString.Name = "textDBConnectionString";
            this.textDBConnectionString.Size = new System.Drawing.Size(398, 20);
            this.textDBConnectionString.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(11, 232);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "DB Connection String (Optional)";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // cmbHubDevices
            // 
            this.cmbHubDevices.FormattingEnabled = true;
            this.cmbHubDevices.Location = new System.Drawing.Point(7, 328);
            this.cmbHubDevices.Name = "cmbHubDevices";
            this.cmbHubDevices.Size = new System.Drawing.Size(398, 21);
            this.cmbHubDevices.TabIndex = 18;
            this.cmbHubDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(11, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Device Id (IoTHub registered device)";
            // 
            // bacnetControls
            // 
            this.bacnetControls.Controls.Add(this.labelDeviceName);
            this.bacnetControls.Controls.Add(this.checkBoxVariation);
            this.bacnetControls.Controls.Add(this.trackBarTemperature);
            this.bacnetControls.Controls.Add(this.label3);
            this.bacnetControls.Controls.Add(this.cmbInstance);
            this.bacnetControls.Controls.Add(this.cmbObjectType);
            this.bacnetControls.Controls.Add(this.cmbDeviceId);
            this.bacnetControls.Controls.Add(this.cmbGatewayId);
            this.bacnetControls.Controls.Add(this.lblObjectType);
            this.bacnetControls.Controls.Add(this.lblDevice);
            this.bacnetControls.Controls.Add(this.labelGateway);
            this.bacnetControls.Location = new System.Drawing.Point(7, 415);
            this.bacnetControls.Margin = new System.Windows.Forms.Padding(2);
            this.bacnetControls.Name = "bacnetControls";
            this.bacnetControls.Padding = new System.Windows.Forms.Padding(2);
            this.bacnetControls.Size = new System.Drawing.Size(400, 221);
            this.bacnetControls.TabIndex = 28;
            this.bacnetControls.TabStop = false;
            this.bacnetControls.Visible = false;
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.ForeColor = System.Drawing.Color.White;
            this.labelDeviceName.Location = new System.Drawing.Point(5, 156);
            this.labelDeviceName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(229, 13);
            this.labelDeviceName.TabIndex = 40;
            this.labelDeviceName.Text = "DeviceInstance Id  (physical, not azure device)";
            // 
            // checkBoxVariation
            // 
            this.checkBoxVariation.AutoSize = true;
            this.checkBoxVariation.Location = new System.Drawing.Point(5, 203);
            this.checkBoxVariation.Name = "checkBoxVariation";
            this.checkBoxVariation.Size = new System.Drawing.Size(111, 17);
            this.checkBoxVariation.TabIndex = 39;
            this.checkBoxVariation.Text = "Add 10% variation";
            this.checkBoxVariation.UseVisualStyleBackColor = true;
            // 
            // trackBarTemperature
            // 
            this.trackBarTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTemperature.Location = new System.Drawing.Point(1, 171);
            this.trackBarTemperature.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarTemperature.Maximum = 100;
            this.trackBarTemperature.Name = "trackBarTemperature";
            this.trackBarTemperature.Size = new System.Drawing.Size(398, 45);
            this.trackBarTemperature.TabIndex = 38;
            this.trackBarTemperature.TabStop = false;
            this.trackBarTemperature.Value = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(216, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Instance";
            // 
            // cmbInstance
            // 
            this.cmbInstance.DropDownWidth = 185;
            this.cmbInstance.FormattingEnabled = true;
            this.cmbInstance.Location = new System.Drawing.Point(215, 123);
            this.cmbInstance.Name = "cmbInstance";
            this.cmbInstance.Size = new System.Drawing.Size(183, 21);
            this.cmbInstance.TabIndex = 36;
            // 
            // cmbObjectType
            // 
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(0, 123);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(185, 21);
            this.cmbObjectType.TabIndex = 35;
            // 
            // cmbDeviceId
            // 
            this.cmbDeviceId.FormattingEnabled = true;
            this.cmbDeviceId.Location = new System.Drawing.Point(0, 73);
            this.cmbDeviceId.Name = "cmbDeviceId";
            this.cmbDeviceId.Size = new System.Drawing.Size(398, 21);
            this.cmbDeviceId.TabIndex = 34;
            // 
            // cmbGatewayId
            // 
            this.cmbGatewayId.FormattingEnabled = true;
            this.cmbGatewayId.Location = new System.Drawing.Point(0, 27);
            this.cmbGatewayId.Name = "cmbGatewayId";
            this.cmbGatewayId.Size = new System.Drawing.Size(398, 21);
            this.cmbGatewayId.TabIndex = 33;
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjectType.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblObjectType.Location = new System.Drawing.Point(4, 107);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(72, 13);
            this.lblObjectType.TabIndex = 32;
            this.lblObjectType.Text = "ObjectType";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDevice.Location = new System.Drawing.Point(4, 54);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(357, 13);
            this.lblDevice.TabIndex = 31;
            this.lblDevice.Text = "DeviceName (name of on premise device sending to gateway)";
            // 
            // labelGateway
            // 
            this.labelGateway.AutoSize = true;
            this.labelGateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGateway.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelGateway.Location = new System.Drawing.Point(4, 13);
            this.labelGateway.Name = "labelGateway";
            this.labelGateway.Size = new System.Drawing.Size(284, 13);
            this.labelGateway.TabIndex = 30;
            this.labelGateway.Text = "GatewayName (name of on premise IoT gateway)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(11, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Device type";
            // 
            // deviceTypes
            // 
            this.deviceTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceTypes.Location = new System.Drawing.Point(7, 381);
            this.deviceTypes.Name = "deviceTypes";
            this.deviceTypes.Size = new System.Drawing.Size(398, 21);
            this.deviceTypes.TabIndex = 29;
            this.deviceTypes.SelectedIndexChanged += new System.EventHandler(this.deviceTypes_SelectedIndexChanged);
            // 
            // sbControls
            // 
            this.sbControls.Controls.Add(this.label7);
            this.sbControls.Controls.Add(this.presence);
            this.sbControls.Controls.Add(this.label6);
            this.sbControls.Controls.Add(this.sensorId);
            this.sbControls.Controls.Add(this.label5);
            this.sbControls.Controls.Add(this.deviceId);
            this.sbControls.Location = new System.Drawing.Point(8, 415);
            this.sbControls.Margin = new System.Windows.Forms.Padding(2);
            this.sbControls.Name = "sbControls";
            this.sbControls.Padding = new System.Windows.Forms.Padding(2);
            this.sbControls.Size = new System.Drawing.Size(400, 149);
            this.sbControls.TabIndex = 32;
            this.sbControls.TabStop = false;
            this.sbControls.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(4, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Presence";
            // 
            // presence
            // 
            this.presence.Location = new System.Drawing.Point(0, 123);
            this.presence.Name = "presence";
            this.presence.Size = new System.Drawing.Size(398, 21);
            this.presence.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(4, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Sensor id";
            // 
            // sensorId
            // 
            this.sensorId.Location = new System.Drawing.Point(0, 73);
            this.sensorId.Name = "sensorId";
            this.sensorId.Size = new System.Drawing.Size(398, 20);
            this.sensorId.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(4, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Device id";
            // 
            // deviceId
            // 
            this.deviceId.Location = new System.Drawing.Point(0, 27);
            this.deviceId.Name = "deviceId";
            this.deviceId.Size = new System.Drawing.Size(398, 20);
            this.deviceId.TabIndex = 28;
            // 
            // lblSendFrequency
            // 
            this.lblSendFrequency.AutoSize = true;
            this.lblSendFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendFrequency.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSendFrequency.Location = new System.Drawing.Point(12, 647);
            this.lblSendFrequency.Name = "lblSendFrequency";
            this.lblSendFrequency.Size = new System.Drawing.Size(123, 13);
            this.lblSendFrequency.TabIndex = 36;
            this.lblSendFrequency.Text = "Send frequency (ms)";
            // 
            // sendFrequency
            // 
            this.sendFrequency.Location = new System.Drawing.Point(8, 663);
            this.sendFrequency.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.sendFrequency.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sendFrequency.Name = "sendFrequency";
            this.sendFrequency.Size = new System.Drawing.Size(115, 20);
            this.sendFrequency.TabIndex = 37;
            this.sendFrequency.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sendFrequency.ValueChanged += new System.EventHandler(this.sendFrequency_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(412, 861);
            this.Controls.Add(this.sendFrequency);
            this.Controls.Add(this.lblSendFrequency);
            this.Controls.Add(this.bacnetControls);
            this.Controls.Add(this.sbControls);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deviceTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDBConnectionString);
            this.Controls.Add(this.lblSentCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbHubDevices);
            this.Controls.Add(this.btnGetDevices);
            this.Controls.Add(this.textAlerts);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.textConnectionString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "e";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.bacnetControls.ResumeLayout(false);
            this.bacnetControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTemperature)).EndInit();
            this.sbControls.ResumeLayout(false);
            this.sbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textConnectionString;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textAlerts;
        private System.Windows.Forms.Button btnGetDevices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSentCount;
        private System.Windows.Forms.TextBox textDBConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox cmbHubDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox bacnetControls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbInstance;
        private System.Windows.Forms.ComboBox cmbObjectType;
        private System.Windows.Forms.ComboBox cmbDeviceId;
        private System.Windows.Forms.ComboBox cmbGatewayId;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label labelGateway;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox deviceTypes;
        private System.Windows.Forms.GroupBox sbControls;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox presence;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sensorId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox deviceId;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.CheckBox checkBoxVariation;
        private System.Windows.Forms.TrackBar trackBarTemperature;
        private System.Windows.Forms.Label lblSendFrequency;
        private System.Windows.Forms.NumericUpDown sendFrequency;
    }
}

