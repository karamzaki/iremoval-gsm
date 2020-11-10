using Claunia.PropertyList;
using iRemovalPRO.Properties;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MobileDevice;
using MobileDevice.Event;
using ns1;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace iRemovalPRO
{
	public class Form1 : MetroForm
	{
		private bool bool_0;

		private bool bool_1;

		private long long_0;

		private iOSDeviceManager iOSDeviceManager_0;

		private iOSDevice iOSDevice_0;

		public bool headless;

		public string udid;

		private string string_0;

		private IContainer icontainer_0;

		private Label label_0;

		public BackgroundWorker ActivationWorker;

		private ToolTip toolTip_0;

		public MetroProgressBar progressBar1;

		private Label label_1;

		public MetroLabel MODEL_TEXT;

		public MetroLabel SN_TEXT;

		public MetroLabel IOS_TEXT;

		public MetroLabel IMEI_TEXT;

		public MetroLabel metroLabel2;

		public MetroLabel metroLabel1;

		public MetroLabel metroLabel5;

		public MetroLabel metroLabel3;

		private MetroLabel metroLabel_0;

		private MetroStyleManager metroStyleManager_0;

		public Button button1;

		private PictureBox pictureBox_0;

		private MetroCheckBox metroCheckBox_0;

		public MetroCheckBox DisableBBBox;

		public MetroCheckBox NoOTABox;

		public MetroCheckBox SkipSetupBox;

		public MetroCheckBox SubstrateBox;

		public MetroCheckBox RebootBox;

		public MetroCheckBox RFSCheckBox;

		private MetroCheckBox metroCheckBox_1;

		private PictureBox pictureBox_1;

		private static SshClient sshClient_0;

		private string string_1;

		private string string_2;

		private static bool bool_2;

		private BackgroundWorker backgroundWorker_0;

		private BackgroundWorker backgroundWorker_1;

		private BackgroundWorker backgroundWorker_2;

		private static string string_3;

		private static ScpClient scpClient_0;

		public MemoryStream comm;

		private bool bool_3;

		private BackgroundWorker backgroundWorker_3;

		public static MemoryStream actrec;

		public static MemoryStream commpatched;

		public MemoryStream purple;

		public static MemoryStream dataark;

		public static MemoryStream dataarkp;

		public static MemoryStream data1;

		private bool bool_4;

		private string string_4;

		public Form1()
			: this()
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected O, but got Unknown
			long_0 = GC.GetTotalMemory(forceFullCollection: true);
			iOSDeviceManager_0 = (iOSDeviceManager)(object)new iOSDeviceManager();
			string_0 = Directory.GetCurrentDirectory();
			method_12();
		}

		private unsafe void Form1_Shown(object sender, EventArgs e)
		{
			//IL_0037: Expected O, but got Ref
			if (File.Exists("%USERPROFILE%\\.ssh\\known_hosts"))
			{
				File.Delete("%USERPROFILE%\\.ssh\\known_hosts");
			}
			Process[] processesByName = Process.GetProcessesByName("iproxy");
			for (int i = 0; i < processesByName.Length; i++)
			{
				((Process)Unsafe.AsPointer(ref processesByName[i])).Kill();
			}
			base.Invoke((Delegate)(MethodInvoker)delegate
			{
				((CheckBox)(object)metroCheckBox_0).Checked = Settings.Default.isDarkMode;
			});
			base.Invoke((Delegate)(MethodInvoker)delegate
			{
				headless = Settings.Default.isNonInteractive;
			});
			SetButtonText();
			base.Invoke((Delegate)(MethodInvoker)delegate
			{
				((Control)(object)metroLabel_0).Visible = false;
			});
			try
			{
				if (iOSDevice_0 == null)
				{
					method_8(connected: false);
				}
			}
			catch
			{
				method_8(connected: false);
			}
		}

		private unsafe void method_0(object sender, FormClosingEventArgs e)
		{
			//IL_0053: Expected O, but got Ref
			Process[] processesByName = default(Process[]);
			int num2 = default(int);
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						processesByName = Process.GetProcessesByName("iproxy");
						num = Math.Abs(0);
						continue;
					case 0:
						num2 = 0;
						num = Math.Abs(-2);
						continue;
					case 1:
						((Process)Unsafe.AsPointer(ref processesByName[num2])).Kill();
						num2++;
						goto case 2;
					case 2:
						if (num2 >= processesByName.Length)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public void Button1_Click(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 2:
						return;
					case 3:
						if (bool_2)
						{
							num = Math.Abs(0);
							continue;
						}
						goto case 1;
					case 0:
						backgroundWorker_3.RunWorkerAsync();
						num = Math.Abs(-2);
						continue;
					case 1:
						backgroundWorker_0.RunWorkerAsync();
						return;
					}
					break;
				}
			}
		}

		public void TriggerHeadlessMode()
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (!headless)
						{
							headless = true;
							num = Math.Abs(0);
						}
						else
						{
							headless = false;
							num = Math.Abs(-2);
						}
						continue;
					case 0:
					case 2:
						Settings.Default.isNonInteractive = headless;
						Settings.Default.Save();
						num = Math.Abs(-1);
						continue;
					case 1:
						SetButtonText();
						return;
					}
					break;
				}
			}
		}

		public void SetButtonText()
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (((CheckBox)(object)RFSCheckBox).Checked && !((CheckBox)(object)SubstrateBox).Checked)
						{
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								button1.Text = "Deactivate";
							});
							num = Math.Abs(0);
							continue;
						}
						if (((CheckBox)(object)RFSCheckBox).Checked && ((CheckBox)(object)SubstrateBox).Checked)
						{
							num = Math.Abs(-2);
							continue;
						}
						if (!headless)
						{
							num = Math.Abs(-1);
							continue;
						}
						goto case 0;
					case 1:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							button1.Text = "Activate";
						});
						goto case 0;
					case 2:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							button1.Text = "Erase";
						});
						goto case 0;
					case 0:
						if (headless)
						{
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								button1.Text = "Waiting..";
							});
						}
						return;
					}
					break;
				}
			}
		}

		private void method_1(object sender, EventArgs e)
		{
		}

		private void method_2(object sender, EventArgs e)
		{
		}

		private void method_3(object sender, EventArgs e)
		{
		}

		private void method_4(object sender, EventArgs e)
		{
		}

		public void Label5_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			button1.Enabled = false;
			backgroundWorker_2 = new BackgroundWorker();
			backgroundWorker_2.DoWork += backgroundWorker_2_DoWork;
			backgroundWorker_0 = new BackgroundWorker();
			backgroundWorker_0.DoWork += backgroundWorker_0_DoWork;
			backgroundWorker_0.RunWorkerCompleted += backgroundWorker_3_RunWorkerCompleted;
			backgroundWorker_3 = new BackgroundWorker();
			backgroundWorker_3.DoWork += backgroundWorker_3_DoWork;
			backgroundWorker_3.RunWorkerCompleted += backgroundWorker_3_RunWorkerCompleted;
			backgroundWorker_1 = new BackgroundWorker();
			backgroundWorker_1.DoWork += backgroundWorker_1_DoWork;
			backgroundWorker_1.RunWorkerCompleted += backgroundWorker_1_RunWorkerCompleted;
			try
			{
				if (smethod_0("Renci.SshNet.dll") != "DC82B57FA50CA8C82765CCA651132473")
				{
					MessageBox.Show("Hehe! (0x1) ", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
				}
				if (smethod_0("plist-cil.dll") != "70CCA699B84668B59054D40E3C108EE4")
				{
					MessageBox.Show("Hehe! (0x2)", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error HASH!", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Process.GetCurrentProcess().Kill();
			}
			backgroundWorker_2.RunWorkerAsync();
		}

		private void iOSDeviceManager_0_CommonConnectEvent(object sender, DeviceCommonConnectEventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Invalid comparison between Unknown and I4
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if ((int)e.get_Message() == 1)
						{
							iOSDevice_0 = e.get_Device();
							if (iOSDevice_0 != null)
							{
								num = Math.Abs(0);
								continue;
							}
						}
						goto IL_0030;
					case 2:
						if (!string.IsNullOrEmpty(iOSDevice_0.get_SerialNumber()))
						{
							iDevice_Check();
						}
						goto IL_0030;
					case 0:
						if (iOSDevice_0.get_IsConnected())
						{
							method_8(connected: true);
							if (!bool_3)
							{
								num = Math.Abs(-2);
								continue;
							}
						}
						goto IL_0030;
					case 1:
						{
							method_8(connected: false);
							if (bool_3)
							{
								bool_3 = false;
							}
							button1.Enabled = false;
							label_1.Text = "";
							return;
						}
						IL_0030:
						if ((int)e.get_Message() == 2)
						{
							num = Math.Abs(-1);
							continue;
						}
						return;
					}
					break;
				}
			}
		}

		private void method_5(object sender, ListenErrorEventHandlerEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			if ((int)e.get_ErrorType() == 0)
			{
				throw new Exception(e.get_ErrorMessage());
			}
		}

		public void SetProgress(int progress)
		{
			progressBar1.set_Value(progress);
		}

		public void ProgressBar1_Click(object sender, EventArgs e)
		{
		}

		private void method_6(object sender, EventArgs e)
		{
		}

		private void method_7(object sender, EventArgs e)
		{
		}

		private void RFSCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (((CheckBox)(object)RFSCheckBox).Checked)
						{
							((CheckBox)(object)RebootBox).Checked = true;
							((CheckBox)(object)SubstrateBox).Checked = false;
							button1.Text = "Deactivate";
							if (bool_1)
							{
								goto case 0;
							}
							((Control)(object)SubstrateBox).Enabled = false;
							goto IL_0064;
						}
						button1.Text = "Activate";
						if (bool_1)
						{
							((Control)(object)SubstrateBox).Text = "Don't push substrate";
							num = Math.Abs(-1);
							continue;
						}
						((Control)(object)SubstrateBox).Enabled = true;
						goto case 1;
					case 0:
						((Control)(object)SubstrateBox).Text = "Wipe Data";
						goto IL_0064;
					case 2:
						((Control)(object)RebootBox).Enabled = false;
						return;
					case 1:
						{
							((Control)(object)DisableBBBox).Enabled = true;
							((Control)(object)NoOTABox).Enabled = true;
							((Control)(object)SkipSetupBox).Enabled = true;
							((CheckBox)(object)RebootBox).Checked = false;
							((Control)(object)RebootBox).Enabled = true;
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								button1.BackColor = Color.FromArgb(0, 170, 173);
							});
							return;
						}
						IL_0064:
						((CheckBox)(object)DisableBBBox).Checked = false;
						((Control)(object)DisableBBBox).Enabled = false;
						((CheckBox)(object)SkipSetupBox).Checked = false;
						((Control)(object)SkipSetupBox).Enabled = false;
						((CheckBox)(object)NoOTABox).Checked = false;
						((Control)(object)NoOTABox).Enabled = false;
						num = Math.Abs(-2);
						continue;
					}
					break;
				}
			}
		}

		private void DisableBBBox_CheckedChanged(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (((CheckBox)(object)DisableBBBox).Checked)
						{
							num = Math.Abs(0);
							continue;
						}
						goto case 1;
					case 0:
						Settings.Default.doesDisableBaseband = true;
						num = Math.Abs(-2);
						continue;
					case 1:
						Settings.Default.doesDisableBaseband = false;
						goto case 2;
					case 2:
						Settings.Default.Save();
						return;
					}
					break;
				}
			}
		}

		private void method_8(bool connected)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (connected)
						{
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								udid = iOSDevice_0.get_UniqueDeviceID().ToUpper().Trim();
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)MODEL_TEXT).Text = iOSDevice_0.get_ProductType();
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)SN_TEXT).Text = iOSDevice_0.get_SerialNumber();
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)IMEI_TEXT).Text = iOSDevice_0.get_InternationalMobileEquipmentIdentity();
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)IOS_TEXT).Text = iOSDevice_0.get_ProductVersion();
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)metroLabel_0).Visible = false;
							});
							num = Math.Abs(0);
						}
						else
						{
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)metroLabel1).Visible = false;
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)metroLabel2).Visible = false;
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)metroLabel3).Visible = false;
							});
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)(object)metroLabel5).Visible = false;
							});
							num = Math.Abs(-1);
						}
						continue;
					case 0:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							pictureBox_1.Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)metroLabel1).Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)metroLabel2).Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)metroLabel3).Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)metroLabel5).Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)MODEL_TEXT).Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)IOS_TEXT).Visible = true;
						});
						num = Math.Abs(-2);
						continue;
					case 1:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)MODEL_TEXT).Visible = false;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)IOS_TEXT).Visible = false;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)SN_TEXT).Visible = false;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)IMEI_TEXT).Visible = false;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)metroLabel_0).Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							pictureBox_1.Visible = false;
						});
						return;
					case 2:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)SN_TEXT).Visible = true;
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)(object)IMEI_TEXT).Visible = true;
						});
						return;
					}
					break;
				}
			}
		}

		private void metroLabel_0_Click(object sender, EventArgs e)
		{
		}

		private void method_9(object sender, EventArgs e)
		{
		}

		private void metroCheckBox_0_CheckedChanged(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (((CheckBox)(object)metroCheckBox_0).Checked)
						{
							base.Invoke((Delegate)(MethodInvoker)delegate
							{
								metroStyleManager_0.set_Theme((MetroThemeStyle)1);
							});
							num = Math.Abs(0);
							continue;
						}
						goto case 2;
					case 2:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							metroStyleManager_0.set_Theme((MetroThemeStyle)0);
						});
						Settings.Default.isDarkMode = false;
						num = Math.Abs(-1);
						continue;
					case 0:
						Settings.Default.isDarkMode = true;
						goto case 1;
					case 1:
						Settings.Default.Save();
						return;
					}
					break;
				}
			}
		}

		private void metroCheckBox_1_CheckedChanged(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 2:
						return;
					case 3:
						if (((CheckBox)(object)metroCheckBox_1).Checked)
						{
							bool_0 = true;
							num = Math.Abs(0);
						}
						else
						{
							bool_0 = false;
							num = Math.Abs(-1);
						}
						continue;
					case 0:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							metroStyleManager_0.set_Style((MetroColorStyle)10);
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							button1.BackColor = Color.FromArgb(255, 0, 148);
						});
						num = Math.Abs(-2);
						continue;
					case 1:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							metroStyleManager_0.set_Style((MetroColorStyle)6);
						});
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							button1.BackColor = Color.FromArgb(0, 170, 173);
						});
						return;
					}
					break;
				}
			}
		}

		private void SkipSetupBox_CheckedChanged(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (((CheckBox)(object)SkipSetupBox).Checked)
						{
							num = Math.Abs(0);
							continue;
						}
						goto case 1;
					case 0:
						Settings.Default.doesSkipSetup = true;
						num = Math.Abs(-2);
						continue;
					case 1:
						Settings.Default.doesSkipSetup = false;
						goto case 2;
					case 2:
						Settings.Default.Save();
						return;
					}
					break;
				}
			}
		}

		private void NoOTABox_CheckedChanged(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (((CheckBox)(object)NoOTABox).Checked)
						{
							num = Math.Abs(0);
							continue;
						}
						goto case 1;
					case 0:
						Settings.Default.doesDisableOTA = true;
						num = Math.Abs(-2);
						continue;
					case 1:
						Settings.Default.doesDisableOTA = false;
						goto case 2;
					case 2:
						Settings.Default.Save();
						return;
					}
					break;
				}
			}
		}

		private void method_10(object sender, EventArgs e)
		{
		}

		private void SubstrateBox_CheckedChanged(object sender, EventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 2:
						return;
					case 3:
						if (((CheckBox)(object)RFSCheckBox).Checked)
						{
							if (((CheckBox)(object)SubstrateBox).Checked)
							{
								num = Math.Abs(0);
								continue;
							}
							button1.Text = "Deactivate";
							num = Math.Abs(-1);
							continue;
						}
						return;
					case 0:
						button1.Text = "Erase";
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							button1.BackColor = Color.FromArgb(190, 0, 40);
						});
						num = Math.Abs(-2);
						continue;
					case 1:
						base.Invoke((Delegate)(MethodInvoker)delegate
						{
							button1.BackColor = Color.FromArgb(0, 170, 173);
						});
						return;
					}
					break;
				}
			}
		}

		private void method_11(object sender, EventArgs e)
		{
		}

		private void toolTip_0_Popup(object sender, PopupEventArgs e)
		{
		}

		private void RebootBox_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void pictureBox_1_Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (disposing)
						{
							num = Math.Abs(0);
							continue;
						}
						goto case 1;
					case 2:
						icontainer_0.Dispose();
						num = Math.Abs(-1);
						continue;
					case 0:
						if (icontainer_0 != null)
						{
							num = Math.Abs(-2);
							continue;
						}
						goto case 1;
					case 1:
						((MetroForm)this).Dispose(disposing);
						return;
					}
					break;
				}
			}
		}

		private void method_12()
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Expected O, but got Unknown
			ComponentResourceManager componentResourceManager = default(ComponentResourceManager);
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						icontainer_0 = new Container();
						componentResourceManager = new ComponentResourceManager(typeof(Form1));
						label_0 = new Label();
						ActivationWorker = new BackgroundWorker();
						toolTip_0 = new ToolTip(icontainer_0);
						button1 = new Button();
						SkipSetupBox = (MetroCheckBox)(object)new MetroCheckBox();
						metroStyleManager_0 = (MetroStyleManager)(object)new MetroStyleManager();
						NoOTABox = (MetroCheckBox)(object)new MetroCheckBox();
						DisableBBBox = (MetroCheckBox)(object)new MetroCheckBox();
						metroCheckBox_1 = (MetroCheckBox)(object)new MetroCheckBox();
						RFSCheckBox = (MetroCheckBox)(object)new MetroCheckBox();
						RebootBox = (MetroCheckBox)(object)new MetroCheckBox();
						SubstrateBox = (MetroCheckBox)(object)new MetroCheckBox();
						progressBar1 = (MetroProgressBar)(object)new MetroProgressBar();
						metroLabel1 = (MetroLabel)(object)new MetroLabel();
						MODEL_TEXT = (MetroLabel)(object)new MetroLabel();
						metroLabel2 = (MetroLabel)(object)new MetroLabel();
						label_1 = new Label();
						IMEI_TEXT = (MetroLabel)(object)new MetroLabel();
						metroLabel3 = (MetroLabel)(object)new MetroLabel();
						IOS_TEXT = (MetroLabel)(object)new MetroLabel();
						metroLabel5 = (MetroLabel)(object)new MetroLabel();
						SN_TEXT = (MetroLabel)(object)new MetroLabel();
						metroLabel_0 = (MetroLabel)(object)new MetroLabel();
						pictureBox_0 = new PictureBox();
						metroCheckBox_0 = (MetroCheckBox)(object)new MetroCheckBox();
						pictureBox_1 = new PictureBox();
						((ISupportInitialize)pictureBox_0).BeginInit();
						((ISupportInitialize)pictureBox_1).BeginInit();
						base.SuspendLayout();
						label_0.AutoSize = true;
						label_0.Enabled = false;
						label_0.Location = new Point(253, 132);
						label_0.Margin = new Padding(1, 0, 1, 0);
						label_0.Name = "label5";
						label_0.Size = new Size(0, 13);
						label_0.TabIndex = 6;
						label_0.Click += Label5_Click;
						toolTip_0.Tag = "";
						toolTip_0.Popup += toolTip_0_Popup;
						button1.BackColor = Color.DarkGreen;
						button1.FlatStyle = FlatStyle.Popup;
						button1.Font = new Font("Segoe UI Semilight", 16f);
						button1.ForeColor = Color.WhiteSmoke;
						button1.Location = new Point(274, 241);
						button1.Name = "button1";
						button1.Size = new Size(123, 56);
						button1.TabIndex = 19;
						button1.Text = "Activate";
						toolTip_0.SetToolTip(button1, "Start activation process");
						button1.UseVisualStyleBackColor = false;
						button1.Click += Button1_Click;
						((Control)(object)SkipSetupBox).AutoSize = true;
						((CheckBox)(object)SkipSetupBox).Checked = Settings.Default.doesSkipSetup;
						((CheckBox)(object)SkipSetupBox).CheckState = CheckState.Checked;
						SkipSetupBox.set_CustomBackground(false);
						((Control)(object)SkipSetupBox).DataBindings.Add(new Binding("Checked", Settings.Default, "doesSkipSetup", formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged));
						SkipSetupBox.set_FontSize((MetroLinkSize)0);
						SkipSetupBox.set_FontWeight((MetroLinkWeight)1);
						((Control)(object)SkipSetupBox).Location = new Point(274, 92);
						((Control)(object)SkipSetupBox).Name = "SkipSetupBox";
						((Control)(object)SkipSetupBox).Size = new Size(77, 15);
						SkipSetupBox.set_Style((MetroColorStyle)4);
						SkipSetupBox.set_StyleManager(metroStyleManager_0);
						((Control)(object)SkipSetupBox).TabIndex = 12;
						((Control)(object)SkipSetupBox).Text = "Skip setup";
						SkipSetupBox.set_Theme((MetroThemeStyle)1);
						toolTip_0.SetToolTip((Control)(object)SkipSetupBox, "Skip initial Setup");
						SkipSetupBox.set_UseStyleColors(false);
						((ButtonBase)(object)SkipSetupBox).UseVisualStyleBackColor = true;
						((Control)(object)SkipSetupBox).Visible = false;
						((CheckBox)(object)SkipSetupBox).CheckedChanged += SkipSetupBox_CheckedChanged;
						metroStyleManager_0.set_OwnerForm((Form)(object)this);
						metroStyleManager_0.set_Style((MetroColorStyle)4);
						metroStyleManager_0.set_Theme((MetroThemeStyle)1);
						((Control)(object)NoOTABox).AutoSize = true;
						((CheckBox)(object)NoOTABox).Checked = Settings.Default.doesDisableOTA;
						((CheckBox)(object)NoOTABox).CheckState = CheckState.Checked;
						NoOTABox.set_CustomBackground(false);
						((Control)(object)NoOTABox).DataBindings.Add(new Binding("Checked", Settings.Default, "doesDisableOTA", formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged));
						NoOTABox.set_FontSize((MetroLinkSize)0);
						NoOTABox.set_FontWeight((MetroLinkWeight)1);
						((Control)(object)NoOTABox).Location = new Point(274, 134);
						((Control)(object)NoOTABox).Name = "NoOTABox";
						((Control)(object)NoOTABox).Size = new Size(127, 15);
						NoOTABox.set_Style((MetroColorStyle)4);
						NoOTABox.set_StyleManager(metroStyleManager_0);
						((Control)(object)NoOTABox).TabIndex = 14;
						((Control)(object)NoOTABox).Text = "Disable iOS updates";
						NoOTABox.set_Theme((MetroThemeStyle)1);
						toolTip_0.SetToolTip((Control)(object)NoOTABox, "Disable OTA and Restore from settings");
						NoOTABox.set_UseStyleColors(false);
						((ButtonBase)(object)NoOTABox).UseVisualStyleBackColor = true;
						((Control)(object)NoOTABox).Visible = false;
						((CheckBox)(object)NoOTABox).CheckedChanged += NoOTABox_CheckedChanged;
						((Control)(object)DisableBBBox).AutoSize = true;
						((CheckBox)(object)DisableBBBox).Checked = Settings.Default.doesDisableBaseband;
						((CheckBox)(object)DisableBBBox).CheckState = CheckState.Checked;
						DisableBBBox.set_CustomBackground(false);
						((Control)(object)DisableBBBox).DataBindings.Add(new Binding("Checked", Settings.Default, "doesDisableBaseband", formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged));
						DisableBBBox.set_FontSize((MetroLinkSize)0);
						DisableBBBox.set_FontWeight((MetroLinkWeight)1);
						((Control)(object)DisableBBBox).Location = new Point(274, 113);
						((Control)(object)DisableBBBox).Name = "DisableBBBox";
						((Control)(object)DisableBBBox).Size = new Size(115, 15);
						DisableBBBox.set_Style((MetroColorStyle)4);
						DisableBBBox.set_StyleManager(metroStyleManager_0);
						((Control)(object)DisableBBBox).TabIndex = 13;
						((Control)(object)DisableBBBox).Text = "Disable baseband";
						num = Math.Abs(0);
						continue;
					case 2:
						MODEL_TEXT.set_FontSize((MetroLabelSize)2);
						MODEL_TEXT.set_FontWeight((MetroLabelWeight)1);
						MODEL_TEXT.set_LabelMode((MetroLabelMode)0);
						((Control)(object)MODEL_TEXT).Location = new Point(225, 97);
						((Control)(object)MODEL_TEXT).Name = "MODEL_TEXT";
						((Control)(object)MODEL_TEXT).Size = new Size(44, 25);
						MODEL_TEXT.set_Style((MetroColorStyle)4);
						MODEL_TEXT.set_StyleManager(metroStyleManager_0);
						((Control)(object)MODEL_TEXT).TabIndex = 2;
						((Control)(object)MODEL_TEXT).Text = "N/A";
						((Label)(object)MODEL_TEXT).TextAlign = ContentAlignment.MiddleLeft;
						MODEL_TEXT.set_Theme((MetroThemeStyle)1);
						MODEL_TEXT.set_UseStyleColors(false);
						((Control)(object)MODEL_TEXT).Visible = false;
						((Control)(object)metroLabel2).AutoSize = true;
						metroLabel2.set_CustomBackground(false);
						((Control)(object)metroLabel2).Enabled = false;
						metroLabel2.set_FontSize((MetroLabelSize)2);
						metroLabel2.set_FontWeight((MetroLabelWeight)2);
						metroLabel2.set_LabelMode((MetroLabelMode)0);
						((Control)(object)metroLabel2).Location = new Point(158, 127);
						((Control)(object)metroLabel2).Name = "metroLabel2";
						((Control)(object)metroLabel2).Size = new Size(46, 25);
						metroLabel2.set_Style((MetroColorStyle)4);
						metroLabel2.set_StyleManager(metroStyleManager_0);
						((Control)(object)metroLabel2).TabIndex = 3;
						((Control)(object)metroLabel2).Text = "iOS:";
						((Label)(object)metroLabel2).TextAlign = ContentAlignment.MiddleRight;
						metroLabel2.set_Theme((MetroThemeStyle)1);
						metroLabel2.set_UseStyleColors(false);
						((Control)(object)metroLabel2).Visible = false;
						label_1.AutoSize = true;
						label_1.Enabled = false;
						label_1.Location = new Point(253, 154);
						label_1.Margin = new Padding(1, 0, 1, 0);
						label_1.Name = "label1";
						label_1.Size = new Size(0, 13);
						label_1.TabIndex = 33;
						((Control)(object)IMEI_TEXT).AutoSize = true;
						IMEI_TEXT.set_CustomBackground(false);
						((Control)(object)IMEI_TEXT).Enabled = false;
						IMEI_TEXT.set_FontSize((MetroLabelSize)2);
						IMEI_TEXT.set_FontWeight((MetroLabelWeight)1);
						IMEI_TEXT.set_LabelMode((MetroLabelMode)0);
						((Control)(object)IMEI_TEXT).Location = new Point(225, 188);
						((Control)(object)IMEI_TEXT).Name = "IMEI_TEXT";
						((Control)(object)IMEI_TEXT).Size = new Size(44, 25);
						IMEI_TEXT.set_Style((MetroColorStyle)4);
						IMEI_TEXT.set_StyleManager(metroStyleManager_0);
						((Control)(object)IMEI_TEXT).TabIndex = 10;
						((Control)(object)IMEI_TEXT).Text = "N/A";
						((Label)(object)IMEI_TEXT).TextAlign = ContentAlignment.MiddleLeft;
						IMEI_TEXT.set_Theme((MetroThemeStyle)1);
						IMEI_TEXT.set_UseStyleColors(false);
						((Control)(object)IMEI_TEXT).Visible = false;
						((Control)(object)metroLabel3).AutoSize = true;
						metroLabel3.set_CustomBackground(false);
						((Control)(object)metroLabel3).Enabled = false;
						metroLabel3.set_FontSize((MetroLabelSize)2);
						metroLabel3.set_FontWeight((MetroLabelWeight)2);
						metroLabel3.set_LabelMode((MetroLabelMode)0);
						((Control)(object)metroLabel3).Location = new Point(158, 157);
						((Control)(object)metroLabel3).Name = "metroLabel3";
						((Control)(object)metroLabel3).Size = new Size(64, 25);
						metroLabel3.set_Style((MetroColorStyle)4);
						metroLabel3.set_StyleManager(metroStyleManager_0);
						((Control)(object)metroLabel3).TabIndex = 5;
						((Control)(object)metroLabel3).Text = "Serial:";
						((Label)(object)metroLabel3).TextAlign = ContentAlignment.MiddleRight;
						metroLabel3.set_Theme((MetroThemeStyle)1);
						metroLabel3.set_UseStyleColors(false);
						((Control)(object)metroLabel3).Visible = false;
						((Control)(object)IOS_TEXT).AutoSize = true;
						IOS_TEXT.set_CustomBackground(false);
						((Control)(object)IOS_TEXT).Enabled = false;
						IOS_TEXT.set_FontSize((MetroLabelSize)2);
						IOS_TEXT.set_FontWeight((MetroLabelWeight)1);
						IOS_TEXT.set_LabelMode((MetroLabelMode)0);
						((Control)(object)IOS_TEXT).Location = new Point(225, 127);
						((Control)(object)IOS_TEXT).Name = "IOS_TEXT";
						((Control)(object)IOS_TEXT).Size = new Size(44, 25);
						IOS_TEXT.set_Style((MetroColorStyle)4);
						IOS_TEXT.set_StyleManager(metroStyleManager_0);
						((Control)(object)IOS_TEXT).TabIndex = 4;
						((Control)(object)IOS_TEXT).Text = "N/A";
						((Label)(object)IOS_TEXT).TextAlign = ContentAlignment.MiddleLeft;
						IOS_TEXT.set_Theme((MetroThemeStyle)1);
						IOS_TEXT.set_UseStyleColors(false);
						((Control)(object)IOS_TEXT).Visible = false;
						((Control)(object)metroLabel5).AutoSize = true;
						metroLabel5.set_CustomBackground(false);
						((Control)(object)metroLabel5).Enabled = false;
						metroLabel5.set_FontSize((MetroLabelSize)2);
						metroLabel5.set_FontWeight((MetroLabelWeight)2);
						metroLabel5.set_LabelMode((MetroLabelMode)0);
						((Control)(object)metroLabel5).Location = new Point(158, 188);
						((Control)(object)metroLabel5).Name = "metroLabel5";
						((Control)(object)metroLabel5).Size = new Size(56, 25);
						metroLabel5.set_Style((MetroColorStyle)4);
						metroLabel5.set_StyleManager(metroStyleManager_0);
						((Control)(object)metroLabel5).TabIndex = 9;
						((Control)(object)metroLabel5).Text = "IMEI:";
						((Label)(object)metroLabel5).TextAlign = ContentAlignment.MiddleRight;
						metroLabel5.set_Theme((MetroThemeStyle)1);
						metroLabel5.set_UseStyleColors(false);
						((Control)(object)metroLabel5).Visible = false;
						((Control)(object)SN_TEXT).AutoSize = true;
						SN_TEXT.set_CustomBackground(false);
						((Control)(object)SN_TEXT).Enabled = false;
						SN_TEXT.set_FontSize((MetroLabelSize)2);
						num = Math.Abs(-1);
						continue;
					case 0:
						DisableBBBox.set_Theme((MetroThemeStyle)1);
						toolTip_0.SetToolTip((Control)(object)DisableBBBox, "[Experimental] Disable Baseband to achieve untethered without sim card");
						DisableBBBox.set_UseStyleColors(false);
						((ButtonBase)(object)DisableBBBox).UseVisualStyleBackColor = true;
						((Control)(object)DisableBBBox).Visible = false;
						((CheckBox)(object)DisableBBBox).CheckedChanged += DisableBBBox_CheckedChanged;
						((Control)(object)metroCheckBox_1).AutoSize = true;
						((Control)(object)metroCheckBox_1).BackColor = Color.FromArgb(17, 17, 17);
						metroCheckBox_1.set_CustomBackground(false);
						((Control)(object)metroCheckBox_1).Enabled = false;
						metroCheckBox_1.set_FontSize((MetroLinkSize)0);
						metroCheckBox_1.set_FontWeight((MetroLinkWeight)1);
						((Control)(object)metroCheckBox_1).Location = new Point(417, 72);
						((Control)(object)metroCheckBox_1).Name = "WildCardBox";
						((Control)(object)metroCheckBox_1).Size = new Size(90, 15);
						metroCheckBox_1.set_Style((MetroColorStyle)4);
						metroCheckBox_1.set_StyleManager(metroStyleManager_0);
						((Control)(object)metroCheckBox_1).TabIndex = 11;
						((Control)(object)metroCheckBox_1).Text = "Do wild stuff";
						metroCheckBox_1.set_Theme((MetroThemeStyle)1);
						toolTip_0.SetToolTip((Control)(object)metroCheckBox_1, "Activates phone using WildCard Server");
						metroCheckBox_1.set_UseStyleColors(false);
						((ButtonBase)(object)metroCheckBox_1).UseVisualStyleBackColor = false;
						((Control)(object)metroCheckBox_1).Visible = false;
						((CheckBox)(object)metroCheckBox_1).CheckedChanged += metroCheckBox_1_CheckedChanged;
						((Control)(object)RFSCheckBox).AutoSize = true;
						RFSCheckBox.set_CustomBackground(false);
						RFSCheckBox.set_FontSize((MetroLinkSize)0);
						RFSCheckBox.set_FontWeight((MetroLinkWeight)2);
						((Control)(object)RFSCheckBox).Location = new Point(417, 134);
						((Control)(object)RFSCheckBox).Name = "RFSCheckBox";
						((Control)(object)RFSCheckBox).Size = new Size(110, 15);
						RFSCheckBox.set_Style((MetroColorStyle)4);
						RFSCheckBox.set_StyleManager(metroStyleManager_0);
						((Control)(object)RFSCheckBox).TabIndex = 18;
						((Control)(object)RFSCheckBox).Text = "Restore RootFS";
						RFSCheckBox.set_Theme((MetroThemeStyle)1);
						toolTip_0.SetToolTip((Control)(object)RFSCheckBox, "Restore RootFS and undo some changes made by the tool");
						RFSCheckBox.set_UseStyleColors(true);
						((ButtonBase)(object)RFSCheckBox).UseVisualStyleBackColor = true;
						((Control)(object)RFSCheckBox).Visible = false;
						((CheckBox)(object)RFSCheckBox).CheckedChanged += RFSCheckBox_CheckedChanged;
						((Control)(object)RebootBox).AutoSize = true;
						((Control)(object)RebootBox).BackColor = Color.FromArgb(17, 17, 17);
						RebootBox.set_CustomBackground(false);
						RebootBox.set_FontSize((MetroLinkSize)0);
						RebootBox.set_FontWeight((MetroLinkWeight)2);
						((Control)(object)RebootBox).Location = new Point(417, 92);
						((Control)(object)RebootBox).Name = "RebootBox";
						((Control)(object)RebootBox).Size = new Size(64, 15);
						RebootBox.set_Style((MetroColorStyle)4);
						RebootBox.set_StyleManager(metroStyleManager_0);
						((Control)(object)RebootBox).TabIndex = 16;
						((Control)(object)RebootBox).Text = "Reboot";
						RebootBox.set_Theme((MetroThemeStyle)1);
						toolTip_0.SetToolTip((Control)(object)RebootBox, "Reboot phone after the activation is done");
						RebootBox.set_UseStyleColors(true);
						((ButtonBase)(object)RebootBox).UseVisualStyleBackColor = false;
						((Control)(object)RebootBox).Visible = false;
						((CheckBox)(object)RebootBox).CheckedChanged += RebootBox_CheckedChanged;
						((Control)(object)SubstrateBox).AutoSize = true;
						SubstrateBox.set_CustomBackground(false);
						SubstrateBox.set_FontSize((MetroLinkSize)0);
						SubstrateBox.set_FontWeight((MetroLinkWeight)2);
						((Control)(object)SubstrateBox).Location = new Point(417, 113);
						((Control)(object)SubstrateBox).Name = "SubstrateBox";
						((Control)(object)SubstrateBox).Size = new Size(140, 15);
						SubstrateBox.set_Style((MetroColorStyle)4);
						SubstrateBox.set_StyleManager(metroStyleManager_0);
						((Control)(object)SubstrateBox).TabIndex = 17;
						((Control)(object)SubstrateBox).Text = "Don't push Substrate";
						SubstrateBox.set_Theme((MetroThemeStyle)1);
						toolTip_0.SetToolTip((Control)(object)SubstrateBox, "Check this if you already have substrate installed");
						SubstrateBox.set_UseStyleColors(true);
						((ButtonBase)(object)SubstrateBox).UseVisualStyleBackColor = true;
						((Control)(object)SubstrateBox).Visible = false;
						((CheckBox)(object)SubstrateBox).CheckedChanged += SubstrateBox_CheckedChanged;
						progressBar1.set_FontSize((MetroProgressBarSize)1);
						progressBar1.set_FontWeight((MetroProgressBarWeight)0);
						progressBar1.set_HideProgressText(true);
						((Control)(object)progressBar1).Location = new Point(35, 319);
						((Control)(object)progressBar1).Name = "progressBar1";
						progressBar1.set_ProgressBarStyle(ProgressBarStyle.Continuous);
						((Control)(object)progressBar1).Size = new Size(492, 28);
						progressBar1.set_Style((MetroColorStyle)4);
						progressBar1.set_StyleManager(metroStyleManager_0);
						((Control)(object)progressBar1).TabIndex = 20;
						progressBar1.set_TextAlign(ContentAlignment.MiddleRight);
						progressBar1.set_Theme((MetroThemeStyle)1);
						((Control)(object)progressBar1).Click += ProgressBar1_Click;
						((Control)(object)metroLabel1).AutoSize = true;
						metroLabel1.set_CustomBackground(false);
						((Control)(object)metroLabel1).Enabled = false;
						metroLabel1.set_FontSize((MetroLabelSize)2);
						metroLabel1.set_FontWeight((MetroLabelWeight)2);
						metroLabel1.set_LabelMode((MetroLabelMode)0);
						((Control)(object)metroLabel1).Location = new Point(158, 97);
						((Control)(object)metroLabel1).Name = "metroLabel1";
						((Control)(object)metroLabel1).Size = new Size(71, 25);
						metroLabel1.set_Style((MetroColorStyle)4);
						metroLabel1.set_StyleManager(metroStyleManager_0);
						((Control)(object)metroLabel1).TabIndex = 1;
						((Control)(object)metroLabel1).Text = "Model:";
						((Label)(object)metroLabel1).TextAlign = ContentAlignment.MiddleCenter;
						metroLabel1.set_Theme((MetroThemeStyle)1);
						metroLabel1.set_UseStyleColors(false);
						((Control)(object)metroLabel1).Visible = false;
						((Control)(object)MODEL_TEXT).AutoSize = true;
						MODEL_TEXT.set_CustomBackground(false);
						((Control)(object)MODEL_TEXT).Enabled = false;
						num = Math.Abs(-2);
						continue;
					case 1:
						SN_TEXT.set_FontWeight((MetroLabelWeight)1);
						SN_TEXT.set_LabelMode((MetroLabelMode)0);
						((Control)(object)SN_TEXT).Location = new Point(225, 157);
						((Control)(object)SN_TEXT).Name = "SN_TEXT";
						((Control)(object)SN_TEXT).Size = new Size(44, 25);
						SN_TEXT.set_Style((MetroColorStyle)4);
						SN_TEXT.set_StyleManager(metroStyleManager_0);
						((Control)(object)SN_TEXT).TabIndex = 6;
						((Control)(object)SN_TEXT).Text = "N/A";
						((Label)(object)SN_TEXT).TextAlign = ContentAlignment.MiddleLeft;
						SN_TEXT.set_Theme((MetroThemeStyle)1);
						SN_TEXT.set_UseStyleColors(false);
						((Control)(object)SN_TEXT).Visible = false;
						((Control)(object)metroLabel_0).Anchor = (AnchorStyles.Top | AnchorStyles.Bottom);
						((Control)(object)metroLabel_0).AutoSize = true;
						metroLabel_0.set_CustomBackground(false);
						metroLabel_0.set_FontSize((MetroLabelSize)2);
						metroLabel_0.set_FontWeight((MetroLabelWeight)0);
						metroLabel_0.set_LabelMode((MetroLabelMode)0);
						((Control)(object)metroLabel_0).Location = new Point(50, 154);
						((Control)(object)metroLabel_0).Name = "waitingText";
						((Control)(object)metroLabel_0).Size = new Size(74, 75);
						metroLabel_0.set_Style((MetroColorStyle)4);
						metroLabel_0.set_StyleManager(metroStyleManager_0);
						((Control)(object)metroLabel_0).TabIndex = 22;
						((Control)(object)metroLabel_0).Text = "Checking \r\nFor \r\nUpdate...";
						((Label)(object)metroLabel_0).TextAlign = ContentAlignment.MiddleCenter;
						metroLabel_0.set_Theme((MetroThemeStyle)1);
						metroLabel_0.set_UseStyleColors(false);
						((Control)(object)metroLabel_0).Click += metroLabel_0_Click;
						pictureBox_0.BackColor = Color.Transparent;
						pictureBox_0.Image = Class1.Bitmap_0;
						pictureBox_0.Location = new Point(8, 60);
						pictureBox_0.Name = "iDevicePicture";
						pictureBox_0.Size = new Size(157, 253);
						pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
						pictureBox_0.TabIndex = 34;
						pictureBox_0.TabStop = false;
						((Control)(object)metroCheckBox_0).AutoSize = true;
						((CheckBox)(object)metroCheckBox_0).Checked = true;
						((CheckBox)(object)metroCheckBox_0).CheckState = CheckState.Checked;
						metroCheckBox_0.set_CustomBackground(false);
						metroCheckBox_0.set_FontSize((MetroLinkSize)0);
						metroCheckBox_0.set_FontWeight((MetroLinkWeight)1);
						((Control)(object)metroCheckBox_0).Location = new Point(274, 72);
						((Control)(object)metroCheckBox_0).Name = "metroCheckBox2";
						((Control)(object)metroCheckBox_0).Size = new Size(81, 15);
						metroCheckBox_0.set_Style((MetroColorStyle)4);
						metroCheckBox_0.set_StyleManager(metroStyleManager_0);
						((Control)(object)metroCheckBox_0).TabIndex = 15;
						((Control)(object)metroCheckBox_0).Text = "Dark mode";
						metroCheckBox_0.set_Theme((MetroThemeStyle)1);
						metroCheckBox_0.set_UseStyleColors(false);
						((ButtonBase)(object)metroCheckBox_0).UseVisualStyleBackColor = true;
						((Control)(object)metroCheckBox_0).Visible = false;
						((CheckBox)(object)metroCheckBox_0).CheckedChanged += metroCheckBox_0_CheckedChanged;
						pictureBox_1.AccessibleName = "";
						pictureBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						pictureBox_1.Image = (Image)componentResourceManager.GetObject("iRemovalPROLogo.Image");
						pictureBox_1.Location = new Point(35, 138);
						pictureBox_1.Name = "iRemovalPROLogo";
						pictureBox_1.Size = new Size(103, 106);
						pictureBox_1.SizeMode = PictureBoxSizeMode.StretchImage;
						pictureBox_1.TabIndex = 35;
						pictureBox_1.TabStop = false;
						pictureBox_1.Click += pictureBox_1_Click;
						base.AutoScaleDimensions = new SizeF(6f, 13f);
						base.AutoScaleMode = AutoScaleMode.Font;
						((Control)(object)this).BackgroundImageLayout = ImageLayout.Center;
						base.ClientSize = new Size(556, 366);
						base.Controls.Add((Control)(object)metroLabel_0);
						base.Controls.Add(button1);
						base.Controls.Add((Control)(object)metroCheckBox_0);
						base.Controls.Add((Control)(object)SN_TEXT);
						base.Controls.Add((Control)(object)metroLabel5);
						base.Controls.Add((Control)(object)IOS_TEXT);
						base.Controls.Add((Control)(object)IMEI_TEXT);
						base.Controls.Add((Control)(object)metroLabel3);
						base.Controls.Add((Control)(object)metroLabel2);
						base.Controls.Add(label_1);
						base.Controls.Add((Control)(object)MODEL_TEXT);
						base.Controls.Add((Control)(object)metroLabel1);
						base.Controls.Add((Control)(object)DisableBBBox);
						base.Controls.Add((Control)(object)SubstrateBox);
						base.Controls.Add((Control)(object)RebootBox);
						base.Controls.Add((Control)(object)NoOTABox);
						base.Controls.Add((Control)(object)RFSCheckBox);
						base.Controls.Add((Control)(object)SkipSetupBox);
						base.Controls.Add((Control)(object)metroCheckBox_1);
						base.Controls.Add((Control)(object)progressBar1);
						base.Controls.Add(label_0);
						base.Controls.Add(pictureBox_1);
						base.Controls.Add(pictureBox_0);
						((Control)(object)this).ForeColor = Color.DarkGray;
						base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
						base.Location = new Point(0, 0);
						base.Margin = new Padding(1);
						base.MaximizeBox = false;
						base.Name = "Form1";
						((MetroForm)this).set_Resizable(false);
						((Control)(object)this).RightToLeft = RightToLeft.No;
						((MetroForm)this).set_Style((MetroColorStyle)4);
						((MetroForm)this).set_StyleManager(metroStyleManager_0);
						((Control)(object)this).Text = "iRemovalPRO v2.2 by IFPDZ and GODLIKE5";
						((MetroForm)this).set_Theme((MetroThemeStyle)1);
						base.Load += Form1_Load;
						base.Shown += Form1_Shown;
						((ISupportInitialize)pictureBox_0).EndInit();
						((ISupportInitialize)pictureBox_1).EndInit();
						base.ResumeLayout(performLayout: false);
						base.PerformLayout();
						return;
					}
					break;
				}
			}
		}

		private void backgroundWorker_2_DoWork(object sender, DoWorkEventArgs e)
		{
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Expected O, but got Unknown
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			try
			{
				((Control)(object)metroLabel_0).Text = "Checking \r\nFor \r\nUpdate...";
				button1.Enabled = false;
				if (AppDomain.CurrentDomain.FriendlyName != "iRemoval PRO v2.2.exe")
				{
					Process.GetCurrentProcess().Kill();
				}
				if (((Control)(object)this).Text != "iRemovalPRO v2.2 by IFPDZ and GODLIKE5")
				{
					Process.GetCurrentProcess().Kill();
				}
				method_15();
				string text;
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(DecryptString("UPv6s2Ew8/WTUS3h65bElC3SB45hgfy61g3DzT2I3Y060ik0BQD61hOAPTuSJOtv"))).GetResponse())
				{
					using (Stream stream = httpWebResponse.GetResponseStream())
					{
						using (StreamReader streamReader = new StreamReader(stream))
						{
							text = streamReader.ReadToEnd();
						}
					}
				}
				if (!(text != "2.2") && !string.IsNullOrEmpty(text))
				{
					if (!IsAdministrator())
					{
						ExecuteAsAdmin(AppDomain.CurrentDomain.FriendlyName);
						Process.GetCurrentProcess().Kill();
						return;
					}
					if (!Directory.Exists(Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Common Files\\Apple\\Mobile Device Support"))
					{
						Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Common Files\\Apple\\Mobile Device Support");
					}
					if (!File.Exists(Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Common Files\\Apple\\Mobile Device Support\\iTunesMobileDevice.dll"))
					{
						byte[] bytes = File.ReadAllBytes("iTunesMobileDevice.dll");
						File.WriteAllBytes(Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Common Files\\Apple\\Mobile Device Support\\iTunesMobileDevice.dll", bytes);
					}
					iOSDeviceManager_0 = (iOSDeviceManager)(object)new iOSDeviceManager();
					iOSDeviceManager_0.add_CommonConnectEvent((DeviceCommonConnectEventHandler)(object)new DeviceCommonConnectEventHandler(iOSDeviceManager_0_CommonConnectEvent));
					iOSDeviceManager_0.add_ListenErrorEvent((EventHandler<ListenErrorEventHandlerEventArgs>)method_5);
					iOSDeviceManager_0.StartListen();
					((Control)(object)metroLabel_0).Text = "Waiting \r\nFor \r\nDevice...";
					button1.Enabled = false;
				}
				else
				{
					MessageBox.Show("This app is deprecated ! Please download the new one from iRemovalPRO.com" + Environment.NewLine + "Current Version: 2.2   Latest Version: " + text, "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Process.Start("https://iremovalpro.com");
					Process.GetCurrentProcess().Kill();
				}
			}
			catch
			{
			}
		}

		private void backgroundWorker_1_DoWork(object sender, DoWorkEventArgs e)
		{
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Expected O, but got Unknown
			((Control)(object)metroLabel_0).Text = "Checking \r\nFor \r\nDevice...";
			button1.Enabled = false;
			string_1 = DecryptString("UPv6s2Ew8/WTUS3h65bElK6CD5h9dxa8hoN1jFk1HClfvQ2s2CNeLZJzdPkKtuOJ");
			Thread.Sleep(100);
			method_15();
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_1);
			object obj = iOSDevice_0.get_SerialNumber();
			if (obj == null)
			{
				obj = "";
			}
			else if (obj == null)
			{
				obj = "";
			}
			string s = "SerialNumber=" + Uri.EscapeDataString((string)obj);
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.UserAgent = "RestSharp/106.11.4.0";
			httpWebRequest.ContentLength = bytes.Length;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			string base64EncodedData;
			using (Stream stream2 = ((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream())
			{
				using (StreamReader streamReader = new StreamReader(stream2))
				{
					base64EncodedData = streamReader.ReadToEnd();
				}
			}
			string text = Base64Decode(base64EncodedData);
			try
			{
				if (text.Contains("notauth"))
				{
					button1.Enabled = false;
					label_1.Text = "Unregistered";
					MessageBox.Show("Device is not registered please register device before starting process.." + Environment.NewLine + "Contact @ifpdz or @godlike50 on telegram", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (text.Contains("http"))
				{
					string_2 = text;
					iDevice_CheckMEID();
					base.BeginInvoke((Delegate)(Action)delegate
					{
						label_1.Text = "Checking...";
						button1.Enabled = false;
					});
					Process process = new Process();
					process.StartInfo.FileName = Environment.CurrentDirectory + "/ref/iproxy.exe";
					process.StartInfo.Arguments = "22 44";
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.StartInfo.CreateNoWindow = true;
					process.Start();
					sshClient_0 = (SshClient)(object)new SshClient("127.0.0.1", "root", "alpine");
					((BaseClient)sshClient_0).Connect();
					button1.Enabled = true;
					label_1.Text = "Ready";
					bool_3 = true;
				}
			}
			catch (SshException)
			{
				button1.Enabled = false;
				label_1.Text = "Unjailbroken";
				MessageBox.Show("There was a problem connecting to your device." + Environment.NewLine + "Please jailbreak using Checkra1n or try to reconnect the jailbroken device", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void iDevice_CheckMEID()
		{
			bool_2 = false;
			string text = "";
			using (Process process = new Process())
			{
				process.StartInfo.FileName = Environment.CurrentDirectory + "/ref/ideviceinfo.exe";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				text = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
			}
			if (text.Contains("MobileEquipmentIdentifier"))
			{
				bool_2 = true;
			}
		}

		private void backgroundWorker_3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 0:
						return;
					case 1:
						return;
					case 3:
						if (e.Cancelled)
						{
							button1.Enabled = true;
							num = Math.Abs(0);
							continue;
						}
						if (e.Error != null)
						{
							num = Math.Abs(-2);
							continue;
						}
						button1.Enabled = false;
						return;
					case 2:
						MessageBox.Show(e.Error.ToString(), "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						button1.Enabled = true;
						num = Math.Abs(-1);
						continue;
					}
					break;
				}
			}
		}

		private void backgroundWorker_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (e.Cancelled)
						{
							button1.Text = "Bypass Canceled";
							num = Math.Abs(0);
							continue;
						}
						goto case 2;
					case 2:
						if (e.Error != null)
						{
							MessageBox.Show(e.Error.ToString(), "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							num = Math.Abs(-1);
							continue;
						}
						return;
					case 0:
						button1.Enabled = true;
						return;
					case 1:
						button1.Enabled = true;
						return;
					}
					break;
				}
			}
		}

		public string Exec(string Comando)
		{
			if (!((BaseClient)sshClient_0).get_IsConnected())
			{
				((BaseClient)sshClient_0).get_ConnectionInfo().set_Timeout(TimeSpan.FromSeconds(180.0));
				((BaseClient)sshClient_0).Connect();
			}
			sshClient_0.CreateCommand("mount -o rw,union,update /").Execute();
			SshCommand val = sshClient_0.CreateCommand(Comando);
			try
			{
				val.Execute();
				string result = val.get_Result();
				if (val.get_Error() != null)
				{
					string_3 = val.get_Error();
					return result;
				}
				return result;
			}
			catch
			{
				((BaseClient)sshClient_0).Disconnect();
				return "XD";
			}
		}

		private void method_13()
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 1:
						return;
					case 3:
						iDevice_Pair();
						scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/ota"), "/Library/MobileSubstrate/DynamicLibraries/OTADisabler.dylib");
						scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/ota1"), "/Library/MobileSubstrate/DynamicLibraries/OTADisabler.plist");
						num = Math.Abs(0);
						continue;
					case 2:
						if (!iOSDevice_0.get_ProductVersion().Contains("14."))
						{
							if (iOSDevice_0.get_ProductVersion().Contains("12."))
							{
								scpClient_0.Upload((Stream)new MemoryStream(GetLib("general12")), "/var/mobile/Media/General.plist");
								Exec("cp -Rf /var/mobile/Media/General.plist /System/Library/PrivateFrameworks/Settings/GeneralSettingsUI.framework/General.plist");
							}
							return;
						}
						goto IL_0078;
					case 0:
						{
							Exec("chmod +x /Library/MobileSubstrate/DynamicLibraries/OTADisabler.dylib");
							Exec("killall -9 SpringBoard mobileactivationd");
							if (!iOSDevice_0.get_ProductVersion().Contains("13."))
							{
								num = Math.Abs(-2);
								continue;
							}
							goto IL_0078;
						}
						IL_0078:
						scpClient_0.Upload((Stream)new MemoryStream(GetLib("general")), "/var/mobile/Media/General.plist");
						Exec("cp -Rf /var/mobile/Media/General.plist /System/Library/PrivateFrameworks/Settings/GeneralSettingsUI.framework/General.plist");
						num = Math.Abs(-1);
						continue;
					}
					break;
				}
			}
		}

		public void GetActRec()
		{
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			string text = "";
			if (iOSDevice_0.get_ProductType().Contains("iPhone"))
			{
				text = "iPhone";
			}
			if (iOSDevice_0.get_ProductType().Contains("iPad"))
			{
				text = "iPad";
			}
			method_15();
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(DecryptString("UPv6s2Ew8/WTUS3h65bElFgCk49Fj2vxsR5jT/az7220M/mc7Vf2mQTTbNFRl1+Nacf4DhUFgBcv9mXFmmUuPg=="));
			object obj = iOSDevice_0.get_SerialNumber();
			if (obj == null)
			{
				obj = "";
			}
			else if (obj == null)
			{
				obj = "";
			}
			string text2 = "SerialNumber=" + Uri.EscapeDataString((string)obj);
			string str = text2;
			object obj2 = text;
			if (obj2 == null)
			{
				obj2 = "";
			}
			else if (obj2 == null)
			{
				obj2 = "";
			}
			text2 = str + "&Type=" + Uri.EscapeDataString((string)obj2);
			byte[] bytes = Encoding.ASCII.GetBytes(text2);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.UserAgent = "Commcenter API 1.0";
			httpWebRequest.ContentLength = bytes.Length;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			string s = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
			NSDictionary val = (NSDictionary)((NSDictionary)((NSDictionary)PropertyListParser.Parse(Encoding.UTF8.GetBytes(s))).get_Item("iphone-activation")).get_Item("activation-record");
			actrec = new MemoryStream();
			PropertyListParser.SaveAsXml((NSObject)(object)val, (Stream)actrec);
		}

		public void iDevice_Pair()
		{
			while (true)
			{
				string text = "";
				using (Process process = new Process())
				{
					process.StartInfo.FileName = Environment.CurrentDirectory + "/ref/idevicepair.exe";
					process.StartInfo.Arguments = "pair";
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.StartInfo.CreateNoWindow = true;
					process.Start();
					text = process.StandardOutput.ReadToEnd();
					process.WaitForExit();
				}
				if (text.Contains("trust"))
				{
					MessageBox.Show("Please unlock your device and press Trust !", "iRemoval ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					continue;
				}
				if (text.Contains("SUCCESS"))
				{
					break;
				}
				if (text.Contains("passcode"))
				{
					MessageBox.Show("Please unlock your device and press Trust ! once you do it click Ok", "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else if (text.Contains("No device"))
				{
					MessageBox.Show("No device connected!", "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else if (!text.Contains("with this host") && !text.Contains("code -7"))
				{
					MessageBox.Show("ERROR: " + text, "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Environment.Exit(1);
				}
			}
			while (true)
			{
				string text2 = "";
				using (Process process2 = new Process())
				{
					process2.StartInfo.FileName = Environment.CurrentDirectory + "/ref/idevicepair.exe";
					process2.StartInfo.Arguments = "validate";
					process2.StartInfo.UseShellExecute = false;
					process2.StartInfo.RedirectStandardOutput = true;
					process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process2.StartInfo.CreateNoWindow = true;
					process2.Start();
					text2 = process2.StandardOutput.ReadToEnd();
					process2.WaitForExit();
				}
				if (text2.Contains("trust"))
				{
					MessageBox.Show("Please unlock your device and press Trust !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					continue;
				}
				if (!text2.Contains("SUCCESS"))
				{
					if (text2.Contains("passcode"))
					{
						MessageBox.Show("Please unlock your device and press Trust !", "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						continue;
					}
					if (text2.Contains("No device"))
					{
						MessageBox.Show("Fatal error! No device found", "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						continue;
					}
					MessageBox.Show("FATAL ERROR: " + text2, "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Environment.Exit(1);
					continue;
				}
				break;
			}
		}

		public void iDevice_Deactivate()
		{
			using (Process process = new Process())
			{
				process.StartInfo.FileName = Environment.CurrentDirectory + "/ref/ideviceactivation.exe";
				process.StartInfo.Arguments = "deactivate";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				process.StandardOutput.ReadToEnd();
				process.WaitForExit();
			}
			Exec("launchctl unload /System/Library/LaunchDaemons/com.apple.mobileactivationd.plist");
			Exec("launchctl load /System/Library/LaunchDaemons/com.apple.mobileactivationd.plist");
		}

		public static string DeleteLines(string s, int linesToRemove)
		{
			return s.Split(Environment.NewLine.ToCharArray(), linesToRemove + 1).Skip(linesToRemove).FirstOrDefault();
		}

		public bool iDevice_Activate(string URLAct, bool B_EsHello = false)
		{
			try
			{
				method_15();
				string str = "";
				using (Process process = new Process())
				{
					process.StartInfo.FileName = Environment.CurrentDirectory + "\\ref\\ideviceactivation.exe";
					process.StartInfo.Arguments = "activate -s " + URLAct;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.StartInfo.CreateNoWindow = true;
					process.Start();
					str = process.StandardOutput.ReadToEnd();
					process.WaitForExit();
				}
				string text = "";
				using (Process process2 = new Process())
				{
					process2.StartInfo.FileName = Environment.CurrentDirectory + "\\ref\\ideviceactivation.exe";
					process2.StartInfo.Arguments = "state";
					process2.StartInfo.UseShellExecute = false;
					process2.StartInfo.RedirectStandardOutput = true;
					process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process2.StartInfo.CreateNoWindow = true;
					process2.Start();
					text = process2.StandardOutput.ReadToEnd();
					process2.WaitForExit();
				}
				if (text.Contains("Activated"))
				{
					return true;
				}
				if (!B_EsHello)
				{
					MessageBox.Show("FATAL ERROR: " + text + " - " + str, "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		private unsafe void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_0754: Expected O, but got Ref
			//IL_0783: Expected O, but got Unknown
			try
			{
				button1.Enabled = false;
				iDevice_Pair();
				Process process = new Process();
				process.StartInfo.FileName = Environment.CurrentDirectory + "/ref/iproxy.exe";
				process.StartInfo.Arguments = "22 44";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				sshClient_0 = (SshClient)(object)new SshClient("127.0.0.1", "root", "alpine");
				((BaseClient)sshClient_0).Connect();
				scpClient_0 = (ScpClient)(object)new ScpClient("127.0.0.1", "root", "alpine");
				((BaseClient)scpClient_0).Connect();
				iDevice_Deactivate();
				SetProgress(10);
				Exec("mount -o rw,union,update /");
				Exec("rm -rf /Library/MobileSubstrate/DynamicLibraries/");
				Exec("rm -rf /Library/Frameworks/CydiaSubstrate.framework");
				Exec("rm /Library/MobileSubstrate/MobileSubstrate.dylib");
				Exec("rm /Library/MobileSubstrate/DynamicLibraries");
				Exec("rm /Library/MobileSubstrate/ServerPlugins");
				Exec("rm /usr/bin/cycc");
				Exec("rm /usr/bin/cynject");
				Exec("rm /usr/include/substrate.h");
				Exec("rm /usr/lib/cycript0.9/com/saurik/substrate/MS.cy");
				Exec("rm -rf /usr/lib/substrate");
				Exec("rm /usr/lib/libsubstrate.dylib");
				Exec("rm /usr/libexec/substrate");
				Exec("rm /usr/libexec/substrated");
				SetProgress(20);
				string str = Exec("find /private/var/containers/Data/System/ -iname 'internal'").Replace("Library/internal", "").Replace("\n", "").Replace("//", "/");
				Exec("chflags nouchg " + str + "Library/internal/data_ark.plist");
				Exec("chflags nouchg " + str + "Library/activation_records/activation_record.plist");
				Exec("chflags nouchg /var/mobile/Library/Preferences/com.apple.purplebuddy.plist");
				Exec("chflags nouchg /var/wireless/Library/Preferences/com.apple.commcenter.device_specific_nobackup.plist");
				Exec("chflags nouchg /var/root/Library/Lockdown/data_ark.plist");
				Exec("rm " + str + "Library/internal/data_ark.plist");
				Exec("rm " + str + "Library/activation_records");
				Exec("rm /var/mobile/Library/Preferences/com.apple.purplebuddy.plist");
				Exec("rm /var/wireless/Library/Preferences/com.apple.commcenter.device_specific_nobackup.plist");
				Exec("rm /var/root/Library/Lockdown/data_ark.plist");
				Exec("launchctl unload -F /System/Library/LaunchDaemons/*");
				Exec("launchctl load -w -F /System/Library/LaunchDaemons/*");
				Thread.Sleep(4000);
				iDevice_Pair();
				SetProgress(30);
				string str2 = DeleteLines(Exec("snappy -f / -l"), 1).Replace("\n", "").Replace("\r", "");
				string comando = "snappy -f / -r " + str2 + " --to orig-fs";
				Exec(comando);
				Exec("rm -rf /System/Library/PrivateFrameworks/MobileActivation.framework/Support/Certificates/RaptorActivation.pem");
				scpClient_0.Upload((Stream)new MemoryStream(GetLib("raptor")), "/System/Library/PrivateFrameworks/MobileActivation.framework/Support/Certificates/RaptorActivation.pem");
				Exec("chown 444 /System/Library/PrivateFrameworks/MobileActivation.framework/Support/Certificates/RaptorActivation.pem");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/1"), "/foo.tar.lzma");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/2"), "/sbin/lzma");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/dep1"), "/uikit.tar");
				Exec("chmod 777 /sbin/lzma");
				Exec("lzma -d -v /foo.tar.lzma");
				Exec("tar -xvf /foo.tar -C /");
				Exec("rm /foo.tar.lzma");
				Exec("rm /foo.tar");
				Exec("cd / && tar -xvf uikit.tar && rm uikit.tar");
				Exec("chmod 755 /usr/libexec/substrate && /usr/libexec/substrate");
				Exec("chmod 755 /usr/libexec/substrated && /usr/libexec/substrated");
				Exec("killall backboardd");
				Thread.Sleep(4000);
				SetProgress(40);
				if (smethod_0(Environment.CurrentDirectory + "/ref/ideviceactivation.exe") != "AD1A92967E35AA1FB65FAC73F7FC0C7E")
				{
					MessageBox.Show("Hehe! (0x3)", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
				}
				iDevice_Activate(string_2 + "deviceActivationOS.php", B_EsHello: true);
				Thread.Sleep(500);
				string text = Exec("find /private/var/containers/Data/System/ -iname 'internal'").Replace("Library/internal", "").Replace("\n", "").Replace("//", "/");
				GetActRec();
				SetProgress(50);
				dataark = new MemoryStream();
				scpClient_0.Download(text + "Library/internal/data_ark.plist", (Stream)dataark);
				PatchArk();
				Exec("chflags nouchg " + text + "Library/activation_records/activation_record.plist");
				Exec("chflags nouchg " + text + "Library/internal/data_ark.plist");
				Exec("chflags nouchg /var/root/Library/Lockdown/data_ark.plist");
				Exec("mkdir -p /var/wireless/Library/Preferences/");
				Exec("mkdir -p " + text + "Library/activation_records");
				Exec("mkdir -p " + text + "Library/internal");
				Exec("mkdir -p /var/root/Library/Lockdown");
				MemoryStream memoryStream = new MemoryStream(actrec.ToArray());
				scpClient_0.Upload((Stream)memoryStream, "/var/mobile/Media/Downloads/activation_record.plist");
				Exec("mv -f /var/mobile/Media/Downloads/activation_record.plist " + text + "Library/activation_records/activation_record.plist");
				MemoryStream memoryStream2 = new MemoryStream(dataarkp.ToArray());
				scpClient_0.Upload((Stream)memoryStream2, "/var/mobile/Media/Downloads/data_ark.plist");
				Exec("mv -f /var/mobile/Media/Downloads/data_ark.plist " + text + "Library/internal/data_ark.plist");
				MemoryStream memoryStream3 = new MemoryStream(data1.ToArray());
				scpClient_0.Upload((Stream)memoryStream3, "/var/mobile/Media/Downloads/data_ark.plist");
				Exec("mv -f /var/mobile/Media/Downloads/data_ark.plist /var/root/Library/Lockdown/data_ark.plist");
				GetCommcenter();
				Exec("chflags uchg " + text + "Library/activation_records/activation_record.plist");
				Exec("chflags uchg " + text + "Library/internal/data_ark.plist");
				Exec("chflags uchg /var/root/Library/Lockdown/data_ark.plist");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/3"), "/Library/MobileSubstrate/DynamicLibraries/simple.dylib");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/4"), "/Library/MobileSubstrate/DynamicLibraries/simple.plist");
				Exec("chmod +x /Library/MobileSubstrate/DynamicLibraries/simple.dylib");
				Exec("killall -9 SpringBoard mobileactivationd");
				Thread.Sleep(4000);
				SetProgress(90);
				Exec("rm -rf /Library/MobileSubstrate/");
				Exec("rm -rf /Library/Frameworks/CydiaSubstrate.framework");
				Exec("rm /usr/bin/cycc");
				Exec("rm /usr/bin/cynject");
				Exec("rm /usr/include/substrate.h");
				Exec("rm -rf /usr/lib/cycript0.9/");
				Exec("rm -rf /usr/lib/substrate");
				Exec("rm /usr/lib/libsubstrate.dylib");
				Exec("rm /usr/libexec/substrate");
				Exec("rm /usr/libexec/substrated");
				SetProgress(100);
				((BaseClient)sshClient_0).Disconnect();
				sshClient_0 = null;
				((BaseClient)scpClient_0).Disconnect();
				scpClient_0 = null;
				Process[] processesByName = Process.GetProcessesByName("iproxy");
				for (int i = 0; i < processesByName.Length; i++)
				{
					((Process)Unsafe.AsPointer(ref processesByName[i])).Kill();
				}
				MessageBox.Show("Your device has been succesfully Activated! \n\nSetup your device and reboot it later.. \n\nRemember, you cannot update or restore if you do that activation will be lost. If you lose it, you don't need to pay again and you only do it again with this same tool. The activation will be done without problems as long as the tool is compatible with the iOS that is signed by Apple.", "Congrats iDevice ACTIVATED Enjoy !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				SetProgress(0);
			}
			catch (ScpException val)
			{
				ScpException val2 = (ScpException)(object)val;
				File.WriteAllText("error_log", ((Exception)(object)val2).Message);
				MessageBox.Show("Failed to activate your device! send error_log to your provider and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				button1.Enabled = true;
				SetProgress(0);
			}
			catch (Exception ex)
			{
				File.WriteAllText("error_log", ex.Message + ex.StackTrace);
				MessageBox.Show("Failed to activate your device! send error_log to your provider and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				button1.Enabled = true;
				SetProgress(0);
			}
		}

		public void iDevice_Check()
		{
			backgroundWorker_1.RunWorkerAsync();
		}

		public string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}

		private unsafe void backgroundWorker_3_DoWork(object sender, DoWorkEventArgs e)
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_065d: Expected O, but got Ref
			//IL_0689: Expected O, but got Unknown
			try
			{
				button1.Enabled = false;
				iDevice_Pair();
				Process process = new Process();
				process.StartInfo.FileName = Environment.CurrentDirectory + "/ref/iproxy.exe";
				process.StartInfo.Arguments = "22 44";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				sshClient_0 = (SshClient)(object)new SshClient("127.0.0.1", "root", "alpine");
				((BaseClient)sshClient_0).Connect();
				scpClient_0 = (ScpClient)(object)new ScpClient("127.0.0.1", "root", "alpine");
				((BaseClient)scpClient_0).Connect();
				iDevice_Deactivate();
				SetProgress(10);
				Exec("mount -o rw,union,update /");
				Exec("rm /Library/MobileSubstrate/DynamicLibraries/simple.dylib");
				Exec("rm /Library/MobileSubstrate/DynamicLibraries/simple.plist");
				Exec("rm /Library/MobileSubstrate/DynamicLibraries/*");
				iDevice_CheckWIFI();
				string str = Exec("find /private/var/containers/Data/System/ -iname 'internal'").Replace("Library/internal", "").Replace("\n", "").Replace("//", "/");
				Exec("chflags nouchg " + str + "Library/internal/data_ark.plist");
				Exec("chflags nouchg " + str + "Library/activation_records/activation_record.plist");
				Exec("chflags nouchg /var/mobile/Library/Preferences/com.apple.purplebuddy.plist");
				Exec("chflags nouchg /var/wireless/Library/Preferences/com.apple.commcenter.device_specific_nobackup.plist");
				Exec("chflags nouchg /var/root/Library/Lockdown/data_ark.plist");
				Exec("rm " + str + "Library/internal/data_ark.plist");
				Exec("rm " + str + "Library/activation_records/activation_record.plist");
				Exec("rm /var/mobile/Library/Preferences/com.apple.purplebuddy.plist");
				Exec("rm /var/wireless/Library/Preferences/com.apple.commcenter.device_specific_nobackup.plist");
				Exec("rm /var/root/Library/Lockdown/data_ark.plist");
				Exec("launchctl unload -F /System/Library/LaunchDaemons/*");
				Exec("launchctl load -w -F /System/Library/LaunchDaemons/*");
				Thread.Sleep(4000);
				iDevice_Pair();
				SetProgress(20);
				string str2 = DeleteLines(Exec("snappy -f / -l"), 1).Replace("\n", "").Replace("\r", "");
				string comando = "snappy -f / -r " + str2 + " --to orig-fs";
				Exec(comando);
				Exec("cp /System/Library/PrivateFrameworks/MobileActivation.framework/Support/Certificates/FactoryActivation.pem /System/Library/PrivateFrameworks/MobileActivation.framework/Support/Certificates/RaptorActivation.pem");
				Exec("chown 444 /System/Library/PrivateFrameworks/MobileActivation.framework/Support/Certificates/RaptorActivation.pem");
				SetProgress(35);
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/1"), "/foo.tar.lzma");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/2"), "/sbin/lzma");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/dep1"), "/uikit.tar");
				Exec("chmod 777 /sbin/lzma");
				Exec("lzma -d -v /foo.tar.lzma");
				Exec("tar -xvf /foo.tar -C /");
				Exec("rm /foo.tar.lzma");
				Exec("rm /foo.tar");
				Exec("cd / && tar -xvf uikit.tar && rm uikit.tar");
				Exec("chmod 755 /usr/libexec/substrate && /usr/libexec/substrate");
				Exec("chmod 755 /usr/libexec/substrated && /usr/libexec/substrated");
				Exec("killall backboardd");
				Thread.Sleep(4000);
				iDevice_Pair();
				if (smethod_0(Environment.CurrentDirectory + "/ref/ideviceactivation.exe") != "AD1A92967E35AA1FB65FAC73F7FC0C7E")
				{
					MessageBox.Show("Hehe! (0x3)", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
				}
				iDevice_Activate(string_2 + "deviceActivationMEI.php", B_EsHello: true);
				Thread.Sleep(1000);
				SetProgress(50);
				string text = Exec("find /private/var/containers/Data/System/ -iname 'internal'").Replace("Library/internal", "").Replace("\n", "").Replace("//", "/");
				GetActRec();
				dataark = new MemoryStream();
				scpClient_0.Download(text + "Library/internal/data_ark.plist", (Stream)dataark);
				PatchArk();
				Exec("chflags nouchg " + text + "Library/activation_records/activation_record.plist");
				Exec("chflags nouchg " + text + "Library/internal/data_ark.plist");
				Exec("chflags nouchg /var/root/Library/Lockdown/data_ark.plist");
				Exec("mkdir -p /var/wireless/Library/Preferences/");
				Exec("mkdir -p " + text + "Library/activation_records");
				Exec("mkdir -p " + text + "Library/internal");
				Exec("mkdir -p /var/root/Library/Lockdown");
				MemoryStream memoryStream = new MemoryStream(actrec.ToArray());
				scpClient_0.Upload((Stream)memoryStream, "/var/mobile/Media/Downloads/activation_record.plist");
				Exec("mv -f /var/mobile/Media/Downloads/activation_record.plist " + text + "Library/activation_records/activation_record.plist");
				MemoryStream memoryStream2 = new MemoryStream(dataarkp.ToArray());
				scpClient_0.Upload((Stream)memoryStream2, "/var/mobile/Media/Downloads/data_ark.plist");
				Exec("mv -f /var/mobile/Media/Downloads/data_ark.plist " + text + "Library/internal/data_ark.plist");
				MemoryStream memoryStream3 = new MemoryStream(data1.ToArray());
				scpClient_0.Upload((Stream)memoryStream3, "/var/mobile/Media/Downloads/data_ark.plist");
				Exec("mv -f /var/mobile/Media/Downloads/data_ark.plist /var/root/Library/Lockdown/data_ark.plist");
				GetCommcenter();
				Exec("chflags uchg " + text + "Library/activation_records/activation_record.plist");
				Exec("chflags uchg " + text + "Library/internal/data_ark.plist");
				Exec("chflags uchg /var/root/Library/Lockdown/data_ark.plist");
				SetProgress(60);
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/3"), "/Library/MobileSubstrate/DynamicLibraries/simple.dylib");
				scpClient_0.Upload(new FileInfo(Environment.CurrentDirectory + "/ref/libs/4"), "/Library/MobileSubstrate/DynamicLibraries/simple.plist");
				Exec("chmod +x /Library/MobileSubstrate/DynamicLibraries/simple.dylib");
				Exec("killall -9 SpringBoard mobileactivationd");
				Thread.Sleep(4000);
				method_13();
				SetProgress(80);
				method_14();
				SetProgress(100);
				((BaseClient)sshClient_0).Disconnect();
				sshClient_0 = null;
				((BaseClient)scpClient_0).Disconnect();
				scpClient_0 = null;
				Process[] processesByName = Process.GetProcessesByName("iproxy");
				for (int i = 0; i < processesByName.Length; i++)
				{
					((Process)Unsafe.AsPointer(ref processesByName[i])).Kill();
				}
				MessageBox.Show("Your device has been succesfully Activated! \n\nconfigure your device and reboot it..\n\nRemember, you cannot update or restore if you do that activation will be lost. If you lose it, you don't need to pay again and you only do it again with this same tool. The activation will be done without problems as long as the tool is compatible with the iOS that is signed by Apple.", "Congrats iDevice ACTIVATED Enjoy !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				SetProgress(0);
			}
			catch (ScpException val)
			{
				ScpException val2 = (ScpException)(object)val;
				File.WriteAllText("error_log", ((Exception)(object)val2).Message);
				MessageBox.Show("Failed to activate your device! send error_log to your provider and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				button1.Enabled = true;
			}
			catch (Exception ex)
			{
				File.WriteAllText("error_log", ex.Message);
				MessageBox.Show("Failed to activate your device! send error_log to your provider and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				button1.Enabled = true;
			}
		}

		public void GetCommcenter()
		{
			string text = "";
			if (iOSDevice_0.get_ProductType().Contains("iPhone"))
			{
				text = "iPhone";
			}
			if (iOSDevice_0.get_ProductType().Contains("iPad"))
			{
				text = "iPad";
			}
			method_15();
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(DecryptString("UPv6s2Ew8/WTUS3h65bElFgCk49Fj2vxsR5jT/az7220M/mc7Vf2mQTTbNFRl1+NE4SFAV3aVof+IQz8+TqdMQ=="));
			object obj = iOSDevice_0.get_SerialNumber();
			if (obj == null)
			{
				obj = "";
			}
			else if (obj == null)
			{
				obj = "";
			}
			string text2 = "SerialNumber=" + Uri.EscapeDataString((string)obj);
			string str = text2;
			object obj2 = text;
			if (obj2 == null)
			{
				obj2 = "";
			}
			else if (obj2 == null)
			{
				obj2 = "";
			}
			text2 = str + "&Type=" + Uri.EscapeDataString((string)obj2);
			byte[] bytes = Encoding.ASCII.GetBytes(text2);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.UserAgent = "Commcenter API 1.0";
			httpWebRequest.ContentLength = bytes.Length;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			string value;
			using (Stream stream2 = ((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream())
			{
				using (StreamReader streamReader = new StreamReader(stream2))
				{
					value = streamReader.ReadToEnd();
				}
			}
			comm = new MemoryStream();
			using (StreamWriter streamWriter = new StreamWriter(comm))
			{
				streamWriter.WriteLine(value);
			}
			Exec("chflags nouchg /var/wireless/Library/Preferences/com.apple.commcenter.device_specific_nobackup.plist");
			MemoryStream memoryStream = new MemoryStream(comm.ToArray());
			scpClient_0.Upload((Stream)memoryStream, "/var/wireless/Library/Preferences/com.apple.commcenter.device_specific_nobackup.plist");
			Exec("chflags uchg /var/wireless/Library/Preferences/com.apple.commcenter.device_specific_nobackup.plist");
		}

		private void method_14()
		{
			//Discarded unreachable code: IL_002b, IL_0038, IL_0044, IL_0051, IL_005d
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (string_4 != "")
						{
							_ = new string[5];
							_ = 0;
							/*Error near IL_0026: Invalid metadata token*/;
						}
						goto case 0;
					case 0:
						Exec("mv /usr/local/standalone/firmware/Baseband /usr/local/standalone/firmware/Baseband2");
						Exec("rm /Library/Preferences/SystemConfiguration/com.apple.radios.plist");
						Exec("plutil -create /Library/Preferences/SystemConfiguration/com.apple.radios.plist");
						num = Math.Abs(-2);
						continue;
					case 2:
						Exec("plutil -key AirplaneMode -true /Library/Preferences/SystemConfiguration/com.apple.radios.plist");
						Exec("chflags uchg /Library/Preferences/SystemConfiguration/com.apple.radios.plist");
						Exec("killall backboardd");
						num = Math.Abs(-1);
						continue;
					case 1:
						Thread.Sleep(4000);
						iDevice_Pair();
						return;
					}
					break;
				}
			}
		}

		public void SkipSetup()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Expected O, but got Unknown
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Expected O, but got Unknown
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Expected O, but got Unknown
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
					{
						DateTime now = DateTime.Now;
						NSDictionary val = new NSDictionary();
						val.Add("AppleIDPB10Presented", true);
						val.Add("ApplicationSwitcherOnBoardingPresented", true);
						val.Add("AssistantPresented", true);
						val.Add("AutoUpdatePresented", true);
						val.Add("ControlCenterOnBoardingPresented", true);
						val.Add("DockOnBoardingPresented", true);
						string text = "GuessedCountry";
						NSDictionary val2 = (NSDictionary)(object)new NSDictionary();
						val2.Add("at", (object)now);
						string text2 = "countries";
						NSArray val3 = new NSArray(1);
						val3.Add((object)"US");
						val2.Add(text2, (NSObject)(object)val3);
						val.Add(text, (NSObject)(object)val2);
						val.Add("HSA2UpgradeMiniBuddy3Ran", true);
						val.Add("Language", (object)"es-US");
						val.Add("Locale", (object)"en_US");
						val.Add("Mesa2Presented", true);
						val.Add("PBDiagnostics4Presented", true);
						val.Add("Passcode4Presented", true);
						val.Add("PaymentMiniBuddy4Ran", true);
						val.Add("PrivacyContentVersion", 2L);
						val.Add("PrivacyPresented", true);
						val.Add("RestoreChoice", true);
						val.Add("ScreenTimePresented", true);
						val.Add("SetupDone", true);
						val.Add("SetupFinishedAllSteps", true);
						val.Add("SetupLastExit", (object)now);
						val.Add("SetupState", (object)"SetupUsingAssistant");
						val.Add("SetupVersion", 11L);
						val.Add("SiriOnBoardingPresented", true);
						val.Add("UserChoseLanguage", true);
						val.Add("UserInterfaceStyleModePresented", true);
						val.Add("WebDatabaseDirectory", (object)"/var/mobile/Library/Caches");
						val.Add("WebKitAcceleratedDrawingEnabled", false);
						val.Add("WebKitLocalStorageDatabasePathPreferenceKey", (object)"/var/mobile/Library/Caches");
						val.Add("WebKitOfflineWebApplicationCacheEnabled", true);
						val.Add("WebKitShrinksStandaloneImagesToFit", true);
						NSDictionary val4 = (NSDictionary)(object)new NSDictionary();
						NSArray val5 = (NSArray)(object)new NSArray(1);
						val4.Add("features", (NSObject)(object)val5);
						val.Add("chronicle", (NSObject)(object)val4);
						string text3 = "lastPrepareLaunchSentinel";
						NSArray val6 = new NSArray(2);
						val6.Add((object)now);
						val6.Add((object)0);
						val.Add(text3, (NSObject)(object)val6);
						val.Add("setupMigratorVersion", 10L);
						purple = new MemoryStream();
						PropertyListParser.SaveAsXml((NSObject)(object)val, (Stream)purple);
						num = Math.Abs(0);
						continue;
					}
					case 2:
						Exec("chmod 600 /var/mobile/Library/Preferences/com.apple.purplebuddy.plist");
						Exec("uicache --all");
						num = Math.Abs(-1);
						continue;
					case 0:
					{
						MemoryStream memoryStream = new MemoryStream(purple.ToArray());
						scpClient_0.Upload((Stream)memoryStream, "/var/mobile/Library/Preferences/com.apple.purplebuddy.plist");
						num = Math.Abs(-2);
						continue;
					}
					case 1:
						Exec("chflags uchg /var/mobile/Library/Preferences/com.apple.purplebuddy.plist");
						return;
					}
					break;
				}
			}
		}

		public string GetValue(NSDictionary PLIST, string NombreObjeto, int LineasArriba = 4)
		{
			NSObject val = default(NSObject);
			PLIST.TryGetValue(NombreObjeto, ref val);
			return DeleteLines(val.ToXmlPropertyList().ToString(), LineasArriba).Replace("\n", "").Replace("\r", "").Replace("</data>", "")
				.Replace("</plist>", "")
				.Replace("</string>", "")
				.Replace("<string>", "")
				.Trim();
		}

		public void PatchArk()
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected O, but got Unknown
			NSDictionary val = (NSDictionary)(object)(NSDictionary)PropertyListParser.Parse(dataark.ToArray());
			try
			{
				val.Remove("-uuidString");
			}
			catch
			{
			}
			string value = GetValue(val, "-BuildVersion", 3);
			try
			{
				val.Remove("-ActivationState");
				val.Remove("-LastActivated");
				val.Add("-ActivationState", (object)"Activated");
				val.Add("-LastActivated", (object)value);
			}
			catch
			{
			}
			dataarkp = new MemoryStream();
			PropertyListParser.SaveAsXml((NSObject)(object)val, (Stream)dataarkp);
			data1 = new MemoryStream();
			PropertyListParser.SaveAsXml((NSObject)(object)val, (Stream)data1);
		}

		public void iDevice_CheckWIFI()
		{
			string a2 = default(string);
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 1:
						return;
					case 3:
					{
						string text = Exec("find /private/preboot/ -type d -name \"Baseband*\"");
						string_4 = text.Replace("\n", "").Replace("\r", "").Replace("//", "/")
							.Replace("Baseband2", "Baseband");
						num = Math.Abs(0);
						continue;
					}
					case 2:
						if (a2 != "")
						{
							bool_4 = true;
							num = Math.Abs(-1);
							continue;
						}
						return;
					case 0:
						if (string_4 != "")
						{
							string a = Exec("ls " + string_4);
							a2 = Exec("ls " + string_4 + "2");
							if (a != "")
							{
								num = Math.Abs(-2);
								continue;
							}
						}
						else
						{
							string a3 = Exec("ls /usr/local/standalone/firmware/Baseband");
							string a4 = Exec("ls /usr/local/standalone/firmware/Baseband2");
							if (a3 != "" && a4 != "")
							{
								bool_4 = true;
							}
						}
						return;
					}
					break;
				}
			}
		}

		public byte[] Base64ToBytes(string base64EncodedData)
		{
			return Convert.FromBase64String(base64EncodedData);
		}

		public byte[] GetLib(string libName)
		{
			while (true)
			{
				int num = Math.Abs(-3);
				while (true)
				{
					switch (num)
					{
					case 3:
						if (libName == "general")
						{
							num = Math.Abs(0);
							continue;
						}
						goto case 2;
					case 2:
						if (libName == "general12")
						{
							num = Math.Abs(-1);
							continue;
						}
						if (libName == "raptor")
						{
							return Base64ToBytes("LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tCk1JSURaekNDQWsrZ0F3SUJBZ0lCQWpBTkJna3Foa2lHOXcwQkFRVUZBREI1TVFzd0NRWURWUVFHRXdKVlV6RVQKTUJFR0ExVUVDZ3dLUVhCd2JHVWdTVzVqTGpFbU1DUUdBMVVFQ3d3ZFFYQndiR1VnUTJWeWRHbG1hV05oZEdsdgpiaUJCZFhSb2IzSnBkSGt4TFRBckJnTlZCQU1NSkVGd2NHeGxJR2xRYUc5dVpTQkRaWEowYVdacFkyRjBhVzl1CklFRjFkR2h2Y21sMGVUQWVGdzB5TURBeU1UY3dOalV4TkRKYUZ3MHlOekF5TVRZd05qVXhOREphTUZzeEN6QUoKQmdOVkJBWVRBbFZUTVJNd0VRWURWUVFLREFwQmNIQnNaU0JKYm1NdU1SVXdFd1lEVlFRTERBeEJjSEJzWlNCcApVR2h2Ym1VeElEQWVCZ05WQkFNTUYwRndjR3hsSUdsUWFHOXVaU0JCWTNScGRtRjBhVzl1TUlHZk1BMEdDU3FHClNJYjNEUUVCQVFVQUE0R05BRENCaVFLQmdRREdZMFpaVWNSeUpPaVB2NWU5R3YwRnFZdzBDN0pzckhBMzFsVW4KUThFNzVacEptYUkvbU5NeHNWVEZNYWxqRVN2VU5EMENMY2Q3b1hVSzdiVGpMQlp2UFZRdzFPeC9JaGZiSnI4aQpGVnBIZXkrQ0t0MHZsSWxzQ0VnUUM5M1M1OXV3MlRTZmFJZ0VvaCt1amxxZkVxcHQ1R2Y5anVIRmVGdlpobFJDClFWVjJzd0lEQVFBQm80R2JNSUdZTUE0R0ExVWREd0VCL3dRRUF3SUhnREFNQmdOVkhSTUJBZjhFQWpBQU1CMEcKQTFVZERnUVdCQlR6VW15eks4NlZScVd2OEI4dCtxOFdON0pNV0RBZkJnTlZIU01FR0RBV2dCUWJQYXhKUkJGTQo5RmNpN0xNQll1dUdkUUhFd1RBNEJnTlZIUjhFTVRBdk1DMmdLNkFwaGlkb2RIUndPaTh2ZDNkM0xtRndjR3hsCkxtTnZiUzloY0hCc1pXTmhMMmx3YUc5dVpTNWpjbXd3RFFZSktvWklodmNOQVFFRkJRQURnZ0VCQUxlRGh6MXMKUmcvZkR3cHQySlQ1Z1dDNVNNelVPUFY1U0FPbGI4NHFTOVJUNjF5UFVYRkk2Vlk3UGFLK2NtNWx2OWJ0K1RQTgpCck1NWWdNaStSV0hkaDFVUFM0eHdHck1TazFjOU0ydWwvNFJFUEVwOUphcC8vMXk4eEtFMTdRVXpXMEVSOEs4CkM5cHRVVVk1TDE4bDUyT3FBRWM0ajZ2VzhIN08zcnJpRUNybUJ1cFhiL1J6d1VQUHJKZUFmaXFSUy81emFudksKTE5wK2ErNnpRUWVNU3MzMmZEL2xVbGswaG82TWNEdGpTR0N1a0szRHlBN1dlV3dCTUZmbDJUNkZYbUdxR0N2WAo0TGZWWFVUa01ieEVSZWVvRmpKZWVJdHY2QmpQdUwybWt0QW53TW1TS0RFTEViRm9vMHhac0xYOXRwQmFLc0JRCmJUK2VFSEJ3dUxkZWlXdz0KLS0tLS1FTkQgQ0VSVElGSUNBVEUtLS0tLQo=");
						}
						return new byte[0];
					case 0:
						return Base64ToBytes("77u/PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+aXRlbXM8L2tleT4KCTxhcnJheT4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNHcm91cENlbGw8L3N0cmluZz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlua0NlbGw8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPmlSZW1vdmFsIElORk88L3N0cmluZz4KCQkJPGtleT5kZXRhaWw8L2tleT4KCQkJPHN0cmluZz5QU0dBYm91dENvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5kYXRhU291cmNlQ2xhc3M8L2tleT4KCQkJPHN0cmluZz5QU0dBYm91dERhdGFTb3VyY2U8L3N0cmluZz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5BSVJEUk9QX0xJTks8L3N0cmluZz4KCQkJPGtleT5kZXRhaWw8L2tleT4KCQkJPHN0cmluZz5QU0dBaXJEcm9wQ29udHJvbGxlcjwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+QUlSRFJPUDwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+Q09OVElOVUlUWV9TUEVDPC9zdHJpbmc+CgkJCTxrZXk+ZGV0YWlsPC9rZXk+CgkJCTxzdHJpbmc+UFNHQ29udGludWl0eUNvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPkNPTlRJTlVJVFk8L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PkNvbnRpbnVpdHlDYXBhYmlsaXR5PC9rZXk+CgkJCQkJPHRydWUvPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+Q0FSUExBWTwvc3RyaW5nPgoJCQk8a2V5PmJ1bmRsZTwva2V5PgoJCQk8c3RyaW5nPkNhcktpdFNldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5DQVJQTEFZPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5EZXZpY2VTdXBwb3J0c0NhckludGVncmF0aW9uPC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJCTxrZXk+aXNDb250cm9sbGVyPC9rZXk+CgkJCTx0cnVlLz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5KcSt4YXVySmdGelN3eE9mVHF0Qkd3PC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5IT01FX0JVVFRPTjwvc3RyaW5nPgoJCQk8a2V5PmxvYWRBY3Rpb248L2tleT4KCQkJPHN0cmluZz5sb2FkSG9tZUJ1dHRvblNldHRpbmdzOjwvc3RyaW5nPgoJCQk8a2V5PnJlcXVpcmVkQ2FwYWJpbGl0aWVzPC9rZXk+CgkJCTxhcnJheT4KCQkJCTxzdHJpbmc+SnEreGF1ckpnRnpTd3hPZlRxdEJHdzwvc3RyaW5nPgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNHcm91cENlbGw8L3N0cmluZz4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPk11bHRpdGFza2luZ19HZXN0dXJlX0dyb3VwPC9zdHJpbmc+CgkJCTxrZXk+Zm9vdGVyQ2VsbENsYXNzPC9rZXk+CgkJCTxzdHJpbmc+TXVsdGl0YXNraW5nR2VzdHVyZUV4cGxhbmF0aW9uVmlldzwvc3RyaW5nPgoJCQk8a2V5PnJlcXVpcmVkQ2FwYWJpbGl0aWVzPC9rZXk+CgkJCTxhcnJheT4KCQkJCTxzdHJpbmc+bXVsdGl0YXNraW5nLWdlc3R1cmVzPC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+TXVsdGl0YXNraW5nX0dlc3R1cmVfU3dpdGNoPC9zdHJpbmc+CgkJCTxrZXk+ZGVmYXVsdHM8L2tleT4KCQkJPHN0cmluZz5jb20uYXBwbGUuc3ByaW5nYm9hcmQ8L3N0cmluZz4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNTd2l0Y2hDZWxsPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5tdWx0aXRhc2tpbmctZ2VzdHVyZXM8L3N0cmluZz4KCQkJPC9hcnJheT4KCQkJPGtleT5rZXk8L2tleT4KCQkJPHN0cmluZz5TQlVzZVN5c3RlbUdlc3R1cmVzPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5HRVNUVVJFUzwvc3RyaW5nPgoJCQk8a2V5PmRlZmF1bHQ8L2tleT4KCQkJPHRydWUvPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNHcm91cENlbGw8L3N0cmluZz4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPlJvdGF0aW9uX1N3aXRjaF9BY3Rpb25fR3JvdXA8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPlJvdGF0aW9uX1N3aXRjaF9BY3Rpb25fR3JvdXBfTGFiZWw8L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8c3RyaW5nPnJpbmdlci1zd2l0Y2g8L3N0cmluZz4KCQkJCTxzdHJpbmc+aXBhZDwvc3RyaW5nPgoJCQk8L2FycmF5PgoJCQk8a2V5PmlzUmFkaW9Hcm91cDwva2V5PgoJCQk8dHJ1ZS8+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpc3RJdGVtQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+TG9ja19Sb3RhdGlvbl9CdXR0b248L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPkxvY2tfUm90YXRpb248L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8c3RyaW5nPnJpbmdlci1zd2l0Y2g8L3N0cmluZz4KCQkJCTxzdHJpbmc+aXBhZDwvc3RyaW5nPgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaXN0SXRlbUNlbGw8L3N0cmluZz4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPk11dGVfQnV0dG9uPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5NdXRlPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5yaW5nZXItc3dpdGNoPC9zdHJpbmc+CgkJCQk8c3RyaW5nPmlwYWQ8L3N0cmluZz4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5TVE9SQUdFX01HTVQ8L3N0cmluZz4KCQkJPGtleT5idW5kbGU8L2tleT4KCQkJPHN0cmluZz5TdG9yYWdlU2V0dGluZ3M8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPlNUT1JBR0VfTUdNVDwvc3RyaW5nPgoJCQk8a2V5PmlzQ29udHJvbGxlcjwva2V5PgoJCQk8dHJ1ZS8+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtMaXN0Q2VsbDwvc3RyaW5nPgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+QVVUT19DT05URU5UX0RPV05MT0FEPC9zdHJpbmc+CgkJCTxrZXk+ZGV0YWlsPC9rZXk+CgkJCTxzdHJpbmc+UFNHQXV0b21hdGljQ29udGVudERvd25sb2FkQ29udHJvbGxlcjwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+QVVUT19DT05URU5UX0RPV05MT0FEPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0dyb3VwQ2VsbDwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5kZXRhaWw8L2tleT4KCQkJPHN0cmluZz5QU0dEYXRlVGltZUNvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+REFURV9BTkRfVElNRTwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5idW5kbGU8L2tleT4KCQkJPHN0cmluZz5LZXlib2FyZFNldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+ZGV0YWlsPC9rZXk+CgkJCTxzdHJpbmc+S2V5Ym9hcmRDb250cm9sbGVyPC9zdHJpbmc+CgkJCTxrZXk+b3ZlcnJpZGVQcmluY2lwYWxDbGFzczwva2V5PgoJCQk8dHJ1ZS8+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5LZXlib2FyZDwvc3RyaW5nPgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+aXNDb250cm9sbGVyPC9rZXk+CgkJCTx0cnVlLz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPktleWJvYXJkPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+YnVuZGxlPC9rZXk+CgkJCTxzdHJpbmc+SW50ZXJuYXRpb25hbFNldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5JTlRFUk5BVElPTkFMPC9zdHJpbmc+CgkJCTxrZXk+aXNDb250cm9sbGVyPC9rZXk+CgkJCTx0cnVlLz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlua0NlbGw8L3N0cmluZz4KCQkJPGtleT5idW5kbGU8L2tleT4KCQkJPHN0cmluZz5EaWN0aW9uYXJ5U2V0dGluZ3M8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPkRJQ1RJT05BUlk8L3N0cmluZz4KCQkJPGtleT5pc0NvbnRyb2xsZXI8L2tleT4KCQkJPHRydWUvPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPlRWK1NZTkMrVlBOK1BST0ZJTEVTX0dST1VQPC9zdHJpbmc+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmRldGFpbDwva2V5PgoJCQk8c3RyaW5nPlBTR1RWT3V0Q29udHJvbGxlcjwvc3RyaW5nPgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5UVl9PVVQ8L3N0cmluZz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5mY2MtbG9nb3MtdmlhLXNvZnR3YXJlPC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5MRUdBTF9BTkRfUkVHVUxBVE9SWTwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+TEVHQUxfQU5EX1JFR1VMQVRPUllfVElUTEU8L3N0cmluZz4KCQkJPGtleT5sb2FkQWN0aW9uPC9rZXk+CgkJCTxzdHJpbmc+bG9hZExlZ2FsQW5kUmVndWxhdG9yeVdpdGhTcGVjaWZpZXI6PC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5mY2MtbG9nb3MtdmlhLXNvZnR3YXJlPC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0dyb3VwQ2VsbDwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNCdXR0b25DZWxsPC9zdHJpbmc+CgkJCTxrZXk+Y3VzdG9tQ29udHJvbGxlckNsYXNzPC9rZXk+CgkJCTxzdHJpbmc+UFNHR2VuZXJhbENvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5idXR0b25BY3Rpb248L2tleT4KCQkJPHN0cmluZz5zaHV0RG93bjo8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPlNIVVRET1dOX0xBQkVMPC9zdHJpbmc+CgkJPC9kaWN0PgoJPC9hcnJheT4KCTxrZXk+dGl0bGU8L2tleT4KCTxzdHJpbmc+R2VuZXJhbDwvc3RyaW5nPgo8L2RpY3Q+CjwvcGxpc3Q+Cg==");
					case 1:
						return Base64ToBytes("77u/PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+aXRlbXM8L2tleT4KCTxhcnJheT4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNHcm91cENlbGw8L3N0cmluZz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlua0NlbGw8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPmlSZW1vdmFsIElORk88L3N0cmluZz4KCQkJPGtleT5kZXRhaWw8L2tleT4KCQkJPHN0cmluZz5QU1VJQWJvdXRDb250cm9sbGVyPC9zdHJpbmc+CgkJCTxrZXk+ZGF0YVNvdXJjZUNsYXNzPC9rZXk+CgkJCTxzdHJpbmc+QWJvdXREYXRhU291cmNlPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0dyb3VwQ2VsbDwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+QUlSRFJPUF9MSU5LPC9zdHJpbmc+CgkJCTxrZXk+ZGV0YWlsPC9rZXk+CgkJCTxzdHJpbmc+UFNVSUFpckRyb3BDb250cm9sbGVyPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5BSVJEUk9QPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5DT05USU5VSVRZX1NQRUM8L3N0cmluZz4KCQkJPGtleT5kZXRhaWw8L2tleT4KCQkJPHN0cmluZz5QU1VJQ29udGludWl0eUNvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPkNPTlRJTlVJVFk8L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8ZGljdD4KCQkJCQk8a2V5PkNvbnRpbnVpdHlDYXBhYmlsaXR5PC9rZXk+CgkJCQkJPHRydWUvPgoJCQkJPC9kaWN0PgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+Q0FSUExBWTwvc3RyaW5nPgoJCQk8a2V5PmJ1bmRsZTwva2V5PgoJCQk8c3RyaW5nPkNhcktpdFNldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5DQVJQTEFZPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5EZXZpY2VTdXBwb3J0c0NhckludGVncmF0aW9uPC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJCTxrZXk+aXNDb250cm9sbGVyPC9rZXk+CgkJCTx0cnVlLz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlua0NlbGw8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPk1VTFRJVEFTS0lORzwvc3RyaW5nPgoJCQk8a2V5PmRldGFpbDwva2V5PgoJCQk8c3RyaW5nPlBTVUlQaVBDb250cm9sbGVyPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5NZWR1c2FQSVBDYXBhYmlsaXR5PC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0dyb3VwQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PnJlcXVpcmVkQ2FwYWJpbGl0aWVzPC9rZXk+CgkJCTxhcnJheT4KCQkJCTxzdHJpbmc+SnEreGF1ckpnRnpTd3hPZlRxdEJHdzwvc3RyaW5nPgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+SE9NRV9CVVRUT048L3N0cmluZz4KCQkJPGtleT5sb2FkQWN0aW9uPC9rZXk+CgkJCTxzdHJpbmc+bG9hZEhvbWVCdXR0b25TZXR0aW5nczo8L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8c3RyaW5nPkpxK3hhdXJKZ0Z6U3d4T2ZUcXRCR3c8L3N0cmluZz4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5BQ0NFU1NJQklMSVRZX0dST1VQPC9zdHJpbmc+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5hY2Nlc3NpYmlsaXR5PC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+YnVuZGxlPC9rZXk+CgkJCTxzdHJpbmc+QWNjZXNzaWJpbGl0eVNldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5BQ0NFU1NJQklMSVRZPC9zdHJpbmc+CgkJCTxrZXk+c2VhcmNoUGxpc3Q8L2tleT4KCQkJPHN0cmluZz5BY2Nlc3NpYmlsaXR5PC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5hY2Nlc3NpYmlsaXR5PC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJCTxrZXk+aXNDb250cm9sbGVyPC9rZXk+CgkJCTx0cnVlLz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5NdWx0aXRhc2tpbmdfR2VzdHVyZV9Hcm91cDwvc3RyaW5nPgoJCQk8a2V5PmZvb3RlckNlbGxDbGFzczwva2V5PgoJCQk8c3RyaW5nPk11bHRpdGFza2luZ0dlc3R1cmVFeHBsYW5hdGlvblZpZXc8L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8c3RyaW5nPm11bHRpdGFza2luZy1nZXN0dXJlczwvc3RyaW5nPgoJCQk8L2FycmF5PgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPk11bHRpdGFza2luZ19HZXN0dXJlX1N3aXRjaDwvc3RyaW5nPgoJCQk8a2V5PmRlZmF1bHRzPC9rZXk+CgkJCTxzdHJpbmc+Y29tLmFwcGxlLnNwcmluZ2JvYXJkPC9zdHJpbmc+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTU3dpdGNoQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PnJlcXVpcmVkQ2FwYWJpbGl0aWVzPC9rZXk+CgkJCTxhcnJheT4KCQkJCTxzdHJpbmc+bXVsdGl0YXNraW5nLWdlc3R1cmVzPC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJCTxrZXk+a2V5PC9rZXk+CgkJCTxzdHJpbmc+U0JVc2VTeXN0ZW1HZXN0dXJlczwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+R0VTVFVSRVM8L3N0cmluZz4KCQkJPGtleT5kZWZhdWx0PC9rZXk+CgkJCTx0cnVlLz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5Sb3RhdGlvbl9Td2l0Y2hfQWN0aW9uX0dyb3VwPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5Sb3RhdGlvbl9Td2l0Y2hfQWN0aW9uX0dyb3VwX0xhYmVsPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5yaW5nZXItc3dpdGNoPC9zdHJpbmc+CgkJCQk8c3RyaW5nPmlwYWQ8L3N0cmluZz4KCQkJPC9hcnJheT4KCQkJPGtleT5pc1JhZGlvR3JvdXA8L2tleT4KCQkJPHRydWUvPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaXN0SXRlbUNlbGw8L3N0cmluZz4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPkxvY2tfUm90YXRpb25fQnV0dG9uPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5Mb2NrX1JvdGF0aW9uPC9zdHJpbmc+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPHN0cmluZz5yaW5nZXItc3dpdGNoPC9zdHJpbmc+CgkJCQk8c3RyaW5nPmlwYWQ8L3N0cmluZz4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlzdEl0ZW1DZWxsPC9zdHJpbmc+CgkJCTxrZXk+aWQ8L2tleT4KCQkJPHN0cmluZz5NdXRlX0J1dHRvbjwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+TXV0ZTwvc3RyaW5nPgoJCQk8a2V5PnJlcXVpcmVkQ2FwYWJpbGl0aWVzPC9rZXk+CgkJCTxhcnJheT4KCQkJCTxzdHJpbmc+cmluZ2VyLXN3aXRjaDwvc3RyaW5nPgoJCQkJPHN0cmluZz5pcGFkPC9zdHJpbmc+CgkJCTwvYXJyYXk+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0dyb3VwQ2VsbDwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmlkPC9rZXk+CgkJCTxzdHJpbmc+U1RPUkFHRV9NR01UPC9zdHJpbmc+CgkJCTxrZXk+YnVuZGxlPC9rZXk+CgkJCTxzdHJpbmc+U3RvcmFnZVNldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5TVE9SQUdFX01HTVQ8L3N0cmluZz4KCQkJPGtleT5pc0NvbnRyb2xsZXI8L2tleT4KCQkJPHRydWUvPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rTGlzdENlbGw8L3N0cmluZz4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPkFVVE9fQ09OVEVOVF9ET1dOTE9BRDwvc3RyaW5nPgoJCQk8a2V5PmRldGFpbDwva2V5PgoJCQk8c3RyaW5nPlBTVUlBdXRvbWF0aWNDb250ZW50RG93bmxvYWRDb250cm9sbGVyPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5BVVRPX0NPTlRFTlRfRE9XTkxPQUQ8L3N0cmluZz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmRldGFpbDwva2V5PgoJCQk8c3RyaW5nPlBTVUlEYXRlVGltZUNvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+REFURV9BTkRfVElNRTwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5idW5kbGU8L2tleT4KCQkJPHN0cmluZz5LZXlib2FyZFNldHRpbmdzPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0xpbmtDZWxsPC9zdHJpbmc+CgkJCTxrZXk+YnVuZGxlPC9rZXk+CgkJCTxzdHJpbmc+SW50ZXJuYXRpb25hbFNldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5JTlRFUk5BVElPTkFMPC9zdHJpbmc+CgkJCTxrZXk+aXNDb250cm9sbGVyPC9rZXk+CgkJCTx0cnVlLz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlua0NlbGw8L3N0cmluZz4KCQkJPGtleT5idW5kbGU8L2tleT4KCQkJPHN0cmluZz5EaWN0aW9uYXJ5U2V0dGluZ3M8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPkRJQ1RJT05BUlk8L3N0cmluZz4KCQkJPGtleT5pc0NvbnRyb2xsZXI8L2tleT4KCQkJPHRydWUvPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5pZDwva2V5PgoJCQk8c3RyaW5nPlRWK1NZTkMrVlBOK1BST0ZJTEVTX0dST1VQPC9zdHJpbmc+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmRldGFpbDwva2V5PgoJCQk8c3RyaW5nPlBTVUlUVk91dENvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCQk8a2V5PmxhYmVsPC9rZXk+CgkJCTxzdHJpbmc+VFZfT1VUPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PnJlcXVpcmVkQ2FwYWJpbGl0aWVzPC9rZXk+CgkJCTxhcnJheT4KCQkJCTxzdHJpbmc+d2lmaTwvc3RyaW5nPgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5Jc1NpbXVsYXRvcjwva2V5PgoJCQkJCTxmYWxzZS8+CgkJCQk8L2RpY3Q+CgkJCTwvYXJyYXk+CgkJCTxrZXk+YnVuZGxlPC9rZXk+CgkJCTxzdHJpbmc+QWlyVHJhZmZpY1NldHRpbmdzPC9zdHJpbmc+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlua0NlbGw8L3N0cmluZz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+cmVxdWlyZWRDYXBhYmlsaXRpZXM8L2tleT4KCQkJPGFycmF5PgoJCQkJPGRpY3Q+CgkJCQkJPGtleT5Jc1NpbXVsYXRvcjwva2V5PgoJCQkJCTxmYWxzZS8+CgkJCQk8L2RpY3Q+CgkJCTwvYXJyYXk+CgkJCTxrZXk+YnVuZGxlPC9rZXk+CgkJCTxzdHJpbmc+VlBOUHJlZmVyZW5jZXM8L3N0cmluZz4KCQkJPGtleT5pc0NvbnRyb2xsZXI8L2tleT4KCQkJPGZhbHNlLz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+bGFiZWw8L2tleT4KCQkJPHN0cmluZz5QUk9GSUxFUzwvc3RyaW5nPgoJCQk8a2V5PmJ1bmRsZTwva2V5PgoJCQk8c3RyaW5nPk1hbmFnZWRDb25maWd1cmF0aW9uVUk8L3N0cmluZz4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNMaW5rQ2VsbDwvc3RyaW5nPgoJCTwvZGljdD4KCQk8ZGljdD4KCQkJPGtleT5jZWxsPC9rZXk+CgkJCTxzdHJpbmc+UFNHcm91cENlbGw8L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8c3RyaW5nPmZjYy1sb2dvcy12aWEtc29mdHdhcmU8L3N0cmluZz4KCQkJPC9hcnJheT4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTTGlua0NlbGw8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPlJFR1VMQVRPUlk8L3N0cmluZz4KCQkJPGtleT5kZXRhaWw8L2tleT4KCQkJPHN0cmluZz5QU0RldGFpbENvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5yZXF1aXJlZENhcGFiaWxpdGllczwva2V5PgoJCQk8YXJyYXk+CgkJCQk8c3RyaW5nPmZjYy1sb2dvcy12aWEtc29mdHdhcmU8L3N0cmluZz4KCQkJPC9hcnJheT4KCQkJPGtleT5wYW5lPC9rZXk+CgkJCTxzdHJpbmc+UFNVSUVuaGFuY2VkUmVndWxhdG9yeVBhbmU8L3N0cmluZz4KCQk8L2RpY3Q+CgkJPGRpY3Q+CgkJCTxrZXk+Y2VsbDwva2V5PgoJCQk8c3RyaW5nPlBTR3JvdXBDZWxsPC9zdHJpbmc+CgkJPC9kaWN0PgoJCTxkaWN0PgoJCQk8a2V5PmNlbGw8L2tleT4KCQkJPHN0cmluZz5QU0J1dHRvbkNlbGw8L3N0cmluZz4KCQkJPGtleT5jdXN0b21Db250cm9sbGVyQ2xhc3M8L2tleT4KCQkJPHN0cmluZz5QU1VJR2VuZXJhbENvbnRyb2xsZXI8L3N0cmluZz4KCQkJPGtleT5idXR0b25BY3Rpb248L2tleT4KCQkJPHN0cmluZz5zaHV0RG93bjo8L3N0cmluZz4KCQkJPGtleT5sYWJlbDwva2V5PgoJCQk8c3RyaW5nPlNIVVRET1dOX0xBQkVMPC9zdHJpbmc+CgkJPC9kaWN0PgoJPC9hcnJheT4KCTxrZXk+dGl0bGU8L2tleT4KCTxzdHJpbmc+R2VuZXJhbDwvc3RyaW5nPgo8L2RpY3Q+CjwvcGxpc3Q+Cg==");
					}
					break;
				}
			}
		}
		public static bool IsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		public void ExecuteAsAdmin(string fileName)
		{
			Process process = new Process();
			process.StartInfo.FileName = fileName;
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.Verb = "runas";
			process.Start();
		}

		public string DecryptString(string cipherText)
		{
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes("bW90aHNsbw=="));
			byte[] iV = new byte[16];
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iV;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = aes.CreateDecryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			string empty = string.Empty;
			try
			{
				byte[] array = Convert.FromBase64String(cipherText);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				byte[] array2 = memoryStream.ToArray();
				return Encoding.ASCII.GetString(array2, 0, array2.Length);
			}
			finally
			{
				memoryStream.Close();
				cryptoStream.Close();
			}
		}

		private static string smethod_0(string filename)
		{
			using (MD5 mD = MD5.Create())
			{
				using (FileStream inputStream = File.OpenRead(filename))
				{
					return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToUpperInvariant();
				}
			}
		}
	}
}
