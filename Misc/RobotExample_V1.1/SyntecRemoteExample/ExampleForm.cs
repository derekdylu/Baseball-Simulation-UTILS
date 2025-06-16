using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Diagnostics;
using System.Threading;

using Syntec.Remote;
using Syntec.OpenCNC;

namespace SyntecRemoteClient
{
	public partial class ExampleForm : Form
	{
		List<SyntecRemoteCNC> m_CNC;
		System.Windows.Forms.Timer m_tmr300ms;
		bool m_prevAlarm = false;
		enum EJogDirection{
			EJD_None = 0,
			EJD_Forward = 1,
			EJD_Backward = 2,
		}

		public ExampleForm()
		{
			InitializeComponent();
			RemoveUnusedProcess();

			m_CNC = new List<SyntecRemoteCNC>();

			// Add your CNCs' host-ip here
			SyntecRemoteCNC cnc = new SyntecRemoteCNC( "192.168.0.91" );
			m_CNC.Add( cnc );

			// Timer event handler
			m_tmr300ms = new System.Windows.Forms.Timer();
			m_tmr300ms.Interval = 300;
			m_tmr300ms.Tick += new EventHandler( m_tmr300ms_Tick );
			m_tmr300ms.Enabled = true;

			// Show connection message
			foreach( SyntecRemoteCNC tmp in m_CNC ) {
				lbConnectedIP.Items.Add( tmp.Host );
			}
		}

		private void m_tmr300ms_Tick( object sender, EventArgs e )
		{
			int cncIndex = 0;
			short result = 0;
			short DecPoint = 0;
			string[] AxisName = null, Unit = null;
			float[] Joint = null, TCP = null, Rel = null, Dist = null;
			bool isAlarm = false;
			string[] msg = null;
			DateTime[] time = null;

			lbJointCoord.Items.Clear();
			lbTCP.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				// Find the corresponding cnc
				cncIndex = lbConnectedIP.SelectedIndices[ i ];

				// Show joint coordinate and tool center point (TCP) position
				lbJointCoord.Items.Add( " --- " + m_CNC[ cncIndex ].Host + " --- " );
				lbTCP.Items.Add( " --- " + m_CNC[ cncIndex ].Host + " --- " );
				result = m_CNC[ cncIndex ].READ_position( out AxisName, out DecPoint, out Unit, out Joint, out TCP, out Rel, out Dist );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbJointCoord.Items.Add( "Error: " + result.ToString() );
					lbTCP.Items.Add( "Error: " + result.ToString() );
					continue;
				}
				for( int j = 0; j < AxisName.Length; j++ ) {
					lbJointCoord.Items.Add( AxisName[ j ] + " : " + Joint[ j ].ToString() );
					lbTCP.Items.Add( TCP[ j ].ToString() );
				}

				// Show current alarm
				result = m_CNC[ cncIndex ].READ_alm_current( out isAlarm, out msg, out time );
				if ( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Clear();
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in reading alarms: " + result.ToString() );
					continue;
				}
				if( isAlarm == false ) {
					if( m_prevAlarm == true ) {
						lbInformation.Items.Clear();
						m_prevAlarm = false;
					}
					continue;
				}
				lbInformation.Items.Clear();
				lbInformation.Items.Add( " --- " + m_CNC[ cncIndex ].Host + " Alarm ---" );
				if( msg == null ) {
					continue;
				}
				for( int j = 0; j < msg.Length; j++ ) {
					lbInformation.Items.Add( "    Time: " + time[ j ].ToString( "yyyyMMdd HHmmss" ) );
					lbInformation.Items.Add( "    Alarm: " + msg[ j ] );
				}
				m_prevAlarm = true;
			}
		}

		~ExampleForm()
		{
			deinit();
			RemoveUnusedProcess();
		}

		private void RemoveUnusedProcess()
		{
			Process[] process = Process.GetProcessesByName( "SyntecRemoteServer" );
			foreach( Process p in process ) {
				p.Kill();
			}
		}

		private void deinit()
		{
			foreach( SyntecRemoteCNC cnc in m_CNC ) {
				cnc.Close();
			}
		}

		private void btnConnect_Click( object sender, EventArgs e )
		{
			string NewIP = tbInputIP.Text;
			if( NewIP == "" ) {
				return;
			}
			SyntecRemoteCNC cnc = new SyntecRemoteCNC( NewIP );
			m_CNC.Add( cnc );
			lbConnectedIP.Items.Add( cnc.Host );
			tbInputIP.Clear();
		}

		private void btnInformation_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			short result = 0;
			short Axes = 0, MaxAxes = 0;
			string CncType = "", Series = "", Nc_Ver = "";
			string[] AxisName = null;

			lbInformation.Items.Clear();
			lbInformation.Items.Add( "Information:" );
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				lbInformation.Items.Add( " --- " + m_CNC[ cncIndex ].Host + " --- " );
				result = m_CNC[ cncIndex ].READ_information( out Axes, out CncType, out MaxAxes, out Series, out Nc_Ver, out AxisName );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( "Axes: " + Axes.ToString() );
					lbInformation.Items.Add( "CNC Type: " + CncType.ToString() );
					lbInformation.Items.Add( "Max Axes: " + MaxAxes.ToString() );
					lbInformation.Items.Add( "Series: " + Series.ToString() );
					lbInformation.Items.Add( "NC Version: " + Nc_Ver.ToString() );
				}
				else {
					lbInformation.Items.Add( "Error in reading information: " + result.ToString() );
				}
			}
		}

		private void btnStatus_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			short result = 0;
			int CurSeq = 0;
			string MainProg = "", CurProg = "", Mode = "", Status = "", Alarm = "", EMG = "";

			lbInformation.Items.Clear();
			lbInformation.Items.Add( "Status:" );
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				lbInformation.Items.Add( " --- " + m_CNC[ cncIndex ].Host + " --- " );
				result = m_CNC[ cncIndex ].READ_status( out MainProg, out CurProg, out CurSeq, out Mode, out Status, out Alarm, out EMG );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( "Main Program: " + MainProg.ToString() );
					lbInformation.Items.Add( "Current Program: " + CurProg.ToString() );
					lbInformation.Items.Add( "Current Sequence: " + CurSeq.ToString() );
					lbInformation.Items.Add( "Mode: " + Mode.ToString() );
					lbInformation.Items.Add( "Status: " + Status.ToString() );
				}
				else {
					lbInformation.Items.Add( "Error in reading status: " + result.ToString() );
				}
			}
		}

		private void btnNCFileList_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			short result = 0;
			string[][] files = null;

			lbInformation.Items.Clear();
			lbInformation.Items.Add( "NC File List:" );
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				lbInformation.Items.Add( " === " + m_CNC[ cncIndex ].Host + " === " );
				result = m_CNC[ cncIndex ].READ_nc_mem_list( out files );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					if( files != null ) {
						for( int j = 0; j < files.Length; j++ ) {
							lbInformation.Items.Add( files[ j ][ 0 ] );
						}
					}
				}
				else {
					lbInformation.Items.Add( "Error in reading NC file list: " + result.ToString() );
				}
			}
		}

		private void btnUploadNCFile_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			short result = 0;

			lbInformation.Items.Clear();
			OpenFileDialog ofd = new OpenFileDialog();
			if( ofd.ShowDialog() == DialogResult.OK ) {
				for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
					cncIndex = lbConnectedIP.SelectedIndices[ i ];
					result = m_CNC[ cncIndex ].UPLOAD_nc_mem( ofd.FileName );
					if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
						WaitForUploadFile( m_CNC[ cncIndex ] );
					}
					else {
						MessageBox.Show( m_CNC[ cncIndex ].Host + " Error in uploading NC file: " + result.ToString() );
					}
				}
			}
			else {
				MessageBox.Show( "Error in choosing NC file." );
			}

			// Show NC file list
			btnNCFileList_Click( sender, e );
		}

		private void WaitForUploadFile( SyntecRemoteCNC cnc )
		{
			while( cnc.isFileUploadDone == false ) {
				Thread.Sleep( 500 );
			}
			if( cnc.FileUploadErrorCode == ( short )Syntec.Remote.SyntecRemoteCNC.ErrorCode.NormalTermination ) {
				MessageBox.Show( cnc.Host + " Upload file success" );
			}
			else {
				MessageBox.Show( cnc.Host + " Upload file failed" );
			}
		}

		private void btnDownloadNCFile_Click( object sender, EventArgs e )
		{
			SyntecRemoteCNC cnc = null;
			bool bSuccess = false;
			short result = 0;

			// Select a file
			bSuccess = SelectFile( ref cnc );
			if( bSuccess == false ) {
				return;
			}

			// Download file
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if( fbd.ShowDialog() == DialogResult.OK ) {
				result = cnc.DOWNLOAD_nc_mem( lbInformation.Items[ lbInformation.SelectedIndex ].ToString(), fbd.SelectedPath );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					WaitForDownloadFile( cnc );
				}
				else {
					MessageBox.Show( cnc.Host + " Error in downloading NC file: " + result.ToString() );
				}
			}

			// Unselect the item
			lbInformation.ClearSelected();
		}

		private void WaitForDownloadFile( SyntecRemoteCNC cnc )
		{
			while( cnc.isFileDownloadDone == false ) {
				Thread.Sleep( 500 );
			}
			if( cnc.FileDownloadErrorCode == ( short )Syntec.Remote.SyntecRemoteCNC.ErrorCode.NormalTermination ) {
				MessageBox.Show( cnc.Host + " Download file success" );
			}
			else {
				MessageBox.Show( cnc.Host + " Download file failed" );
			}
		}

		private void btnDeleteNCFile_Click( object sender, EventArgs e )
		{
			SyntecRemoteCNC cnc = null;
			bool bSuccess = false;
			short result = 0;

			// Select a file
			bSuccess = SelectFile( ref cnc );
			if( bSuccess == false ) {
				return;
			}

			// Delete file
			result = cnc.DEL_nc_mem( lbInformation.Items[ lbInformation.SelectedIndex ].ToString() );
			if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
				MessageBox.Show( cnc.Host + " NC file deletion success" );
			}
			else {
				MessageBox.Show( cnc.Host + " Error in deleting NC file: " + result.ToString() );
			}

			// Show NC file list
			btnNCFileList_Click( sender, e );
		}

		private void btnSetMainNC_Click( object sender, EventArgs e )
		{
			SyntecRemoteCNC cnc = null;
			bool bSuccess = false;
			short result = 0;
			string FileName = "";

			// Select a file
			bSuccess = SelectFile( ref cnc );
			if( bSuccess == false ) {
				return;
			}

			// Set the file as main porgram
			FileName = lbInformation.Items[ lbInformation.SelectedIndex ].ToString();
			result = cnc.WRITE_nc_main( FileName );
			if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
				MessageBox.Show( cnc.Host + " Main NC file is set as " + FileName );
			}
			else {
				MessageBox.Show( cnc.Host + " Error in setting main NC file: " + result.ToString() );
			}

			// Unselect the item
			lbInformation.ClearSelected();
		}

		private bool SelectFile( ref SyntecRemoteCNC cnc )
		{
			string host = "";
			bool bFoundFile = false;

			// Get the selected item
			bFoundFile = lbInformation.SelectedIndex >= 0
				&& lbInformation.Items[ lbInformation.SelectedIndex ].ToString().IndexOf( " === " ) == -1
				&& lbInformation.Items[ lbInformation.SelectedIndex ].ToString() != "";
			if( bFoundFile == false ) {
				MessageBox.Show( "Please select a file" );
				return false;
			}

			// Find the corresponding host
			for( int i = lbInformation.SelectedIndex - 1; i >= 0; i-- ) {
				if( lbInformation.Items[ i ].ToString().IndexOf( " === " ) >= 0 )           {
					host = lbInformation.Items[ i ].ToString().Replace( " === ", "" );
					break;
				}
			}
			if( host == "" ) {
				MessageBox.Show( "Failed to find the host" );
				return false;
			}

			// Map to cnc
			foreach( SyntecRemoteCNC tmp in m_CNC ) {
				if( tmp.Host == host ) {
					cnc = tmp;
					break;
				}
			}
			if( cnc == null ) {
				MessageBox.Show( "Failed to find the corresponding CNC" );
				return false;
			}
			return true;
		}

		private void btnAuto_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			int[] Mode = new int[ 1 ];
			short result = 0;

			Mode[ 0 ] = 2;
			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				result = m_CNC[ cncIndex ].WRITE_plc_register( 13, 13, Mode );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Current mode set to Auto" );
				}
				else {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in setting Auto mode: " + result.ToString() );
				}
			}
		}

		private void btnJOG_Click(object sender, EventArgs e)
		{
			int cncIndex = 0;
			int[] Mode = new int[1];
			short result = 0;

			Mode[0] = 4;
			lbInformation.Items.Clear();
			for (int i = 0; i < lbConnectedIP.SelectedItems.Count; i++)
			{
				cncIndex = lbConnectedIP.SelectedIndices[i];
				result = m_CNC[cncIndex].WRITE_plc_register(13, 13, Mode);
				if (result == (short)SyntecRemoteCNC.ErrorCode.NormalTermination)
				{
					lbInformation.Items.Add(m_CNC[cncIndex].Host + " Current mode set to JOG");
				}
				else
				{
					lbInformation.Items.Add(m_CNC[cncIndex].Host + " Error in setting JOG mode: " + result.ToString());
				}
			}

		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			int cncIndex = 0;
			int[] Mode = new int[ 1 ];
			short result = 0;

			// Set R15207 to 1 to reset
			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				Mode[ 0 ] = 1;
				result = m_CNC[ cncIndex ].WRITE_plc_register( 15207, 15207, Mode );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Reset" );
					WaitOnePLCStep( cncIndex );
					Mode[ 0 ] = 0;
					m_CNC[ cncIndex ].WRITE_plc_register( 15207, 15207, Mode );
				}
				else {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in resetting: " + result.ToString() );
				}
			}
		}

		private void btnStart_Click( object sender, EventArgs e )
		{
			DialogResult Start;
			int cncIndex = 0;
			int[] Mode = new int[ 1 ];
			short result = 0;

			// Ask if start cycle
			Start = MessageBox.Show( "Are you sure to start cycle?", "Warning", MessageBoxButtons.YesNo );
			if( Start == DialogResult.No ) {
				return;
			}

			// Set R15205 to 1 to start cycle
			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				Mode[ 0 ] = 1;
				result = m_CNC[ cncIndex ].WRITE_plc_register( 15205, 15205, Mode );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Cycle start" );
					WaitOnePLCStep( cncIndex );
					Mode[ 0 ] = 0;
					m_CNC[ cncIndex ].WRITE_plc_register( 15205, 15205, Mode );
				}
				else {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in starting cycle: " + result.ToString() );
				}
			}
		}

		private void btnPause_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			int[] Mode = new int[ 1 ];
			short result = 0;

			// Set R15206 to 1 to reset
			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				Mode[ 0 ] = 1;
				result = m_CNC[ cncIndex ].WRITE_plc_register( 15206, 15206, Mode );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Paused" );
					WaitOnePLCStep( cncIndex );
					Mode[ 0 ] = 0;
					m_CNC[ cncIndex ].WRITE_plc_register( 15206, 15206, Mode );
				}
				else {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in pause section: " + result.ToString() );
				}
			}
		}

		private void btnRateUp_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			short result = 0;
			int[] Rate = new int[ 1 ];
			int[] CurrentMode = new int[ 1 ];
			int RateRegister = 0;
			bool AutoMode = true;

			// Add 10 to R15213/15214 to increase rate
			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];

				// Get current mode
				result = m_CNC[ cncIndex ].READ_plc_register( 13, 13, out CurrentMode );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in getting current mode: " + result.ToString() );
					return;
				}
				if( CurrentMode[ 0 ] == 2 ) {
					RateRegister = 15213;
					AutoMode = true;
				}
				else if( CurrentMode[ 0 ] == 4 ) {
					RateRegister = 15214;
					AutoMode = false;
				}
				else {
					return;
				}

				// Increase rate by 10
				result = m_CNC[ cncIndex ].READ_plc_register( RateRegister, RateRegister, out Rate );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in reading rate: " + result.ToString() );
					return;
				}
				if( Rate[ 0 ] < 100 ) {
					Rate[ 0 ] += 10;
				}
				result = m_CNC[ cncIndex ].WRITE_plc_register( RateRegister, RateRegister, Rate );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					WaitOnePLCStep( cncIndex );
					if( AutoMode == true ) {
						lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Current Auto mode rate: " + Rate[ 0 ].ToString() + "%" );
					}
					else {
						lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Current JOG mode rate: " + Rate[ 0 ].ToString() + "%" );
					}
				}
				else {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in increasing rate: " + result.ToString() );
				}
			}
		}

		private void btnRateDown_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			short result = 0;
			int[] Rate = new int[ 1 ];
			Rate[ 0 ] = 0;
			int[] CurrentMode = new int[ 1 ];
			int RateRegister = 0;
			bool AutoMode = true;

			// Subtract 10 from R15213/15214 to decrease rate
			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];

				// Get current mode
				result = m_CNC[ cncIndex ].READ_plc_register( 13, 13, out CurrentMode );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in getting current mode: " + result.ToString() );
					return;
				}
				if( CurrentMode[ 0 ] == 2 ) {
					RateRegister = 15213;
					AutoMode = true;
				}
				else if( CurrentMode[ 0 ] == 4 ) {
					RateRegister = 15214;
					AutoMode = false;
				}
				else {
					return;
				}

				// Decrease rate by 10
				result = m_CNC[ cncIndex ].READ_plc_register( RateRegister, RateRegister, out Rate );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in reading rate: " + result.ToString() );
					return;
				}
				if( Rate[ 0 ] > 10 ) {
					Rate[ 0 ] -= 10;
				}
				result = m_CNC[ cncIndex ].WRITE_plc_register( RateRegister, RateRegister, Rate );
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					WaitOnePLCStep( cncIndex );
					if( AutoMode == true ) {
						lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Current Auto mode rate: " + Rate[ 0 ].ToString() + "%" );
					}
					else {
						lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Current JOG mode rate: " + Rate[ 0 ].ToString() + "%" );
					}
				}
				else {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in decreasing rate: " + result.ToString() );
				}
			}
		}

		private void WaitOnePLCStep( int cncIndex )
		{
			short result = 0;
			int[] ParamData = new int[ 1 ];

			result = m_CNC[ cncIndex ].READ_param_data( 3204, 3204, out ParamData );
			if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
				Thread.Sleep( ParamData[ 0 ] / 1000 );
			}
			else {
				Thread.Sleep( 10 );
			}
		}

		private void btnRead_Click( object sender, EventArgs e )
		{
			int cncIndex = 0;
			string Bits = tbPLCbits.Text;
			bool Validity = false;
			int Address = 0;
			short result = 0;
			byte[] DataByte = new byte[ 1 ];
			int[] DataInt = new int[ 1 ];
			bool IsRegister = false;

			// Check validity of PLC address
			if( Bits == "" ) {
				return;
			}
			lbInformation.Items.Clear();
			tbPLCbits.Clear();
			Validity = IsReadAddressValid( ref Bits );
			if( Validity == false ) {
				return;
			}

			// Get address number
			for( int i = 1; i < Bits.Length; i++ ){
				Address = Address * 10 + ( Bits[ i ] - '0' );
			}

			// Read PLC
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];
				switch( Bits[ 0 ] ){
					case 'i':
					case 'I':
						result = m_CNC[ cncIndex ].READ_plc_ibit( Address, Address, out DataByte );
						break;
					case 'o':
					case 'O':
						result = m_CNC[ cncIndex ].READ_plc_obit( Address, Address, out DataByte );
						break;
					case 'c':
					case 'C':
						result = m_CNC[ cncIndex ].READ_plc_cbit( Address, Address, out DataByte );
						break;
					case 's':
					case 'S':
						result = m_CNC[ cncIndex ].READ_plc_sbit( Address, Address, out DataByte );
						break;
					case 'a':
					case 'A':
						result = m_CNC[ cncIndex ].READ_plc_abit( Address, Address, out DataByte );
						break;
					case 'r':
					case 'R':
						result = m_CNC[ cncIndex ].READ_plc_register( Address, Address, out DataInt );
						IsRegister = true;
						break;
				}
				if( result == ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					if( IsRegister == false ) {
						if( DataByte[ 0 ] == 255 ) {
							lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " " + Bits + " = on" );
						}
						else {
							lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " " + Bits + " = off" );
						}
					}
					else {
						lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " " + Bits + " = " + DataInt[ 0 ].ToString() );
					}
				}
				else {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in reading " + Bits + ": " + result.ToString() );
				}
			}
		}

		private bool IsReadAddressValid( ref string Bits )
		{
			char Type = Bits[ 0 ];

			if( Type != 'i' && Type != 'I' && Type != 'o' && Type != 'O' && Type != 'c' && Type != 'C' && Type != 's' && Type != 'S' && Type != 'a' && Type != 'A' && Type != 'r' && Type != 'R' ) {
				lbInformation.Items.Add( Bits + " Invalid PLC address." );
				return false;
			}
			for( int i = 1; i < Bits.Length; i++ ) {
				if( Bits[ i ] < '0' || Bits[ i ] > '9' ) {
					lbInformation.Items.Add( Bits + " Invalid PLC address." );
					return false;
				}
			}
			return true;
		}

		private void btnCoord_Click(object sender, EventArgs e)
		{
			int cncIndex = 0;
			short result = 0;
			int[] Coord = new int[ 1 ];

			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];

				// Get current coordinate
				result = m_CNC[ cncIndex ].READ_plc_register( 518, 518, out Coord );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in getting coordinate: " + result.ToString() );
					return;
				}

				// Set new coordinate
				Coord[ 0 ]++;
				if( Coord[ 0 ] > 2 ) {
					Coord[ 0 ] = 0;
				}
				result = m_CNC[ cncIndex ].WRITE_plc_register( 518, 518, Coord );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in setting coordinate: " + result.ToString() );
					return;
				}

				// Print
				switch( Coord[ 0 ] ) {
				case 0:
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Coordinate set to Joint.");
					break;

				case 1:
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Coordinate set to User.");
					break;

				case 2:
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Coordinate set to Tool.");
					break;
				}
			}
		}

		// C1/X direction JOG
		private void btnXBack_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 1 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Backward );
		}

		private void btnXBack_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		private void btnXFore_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 1 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Forward );
		}

		private void btnXFore_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		// C2/Y direction JOG
		private void btnYBack_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 2 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Backward );
		}

		private void btnYBack_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		private void btnYFore_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 2 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Forward );
		}

		private void btnYFore_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		// C3/Z direction JOG
		private void btnZBack_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 3 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Backward );
		}

		private void btnZBack_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		private void btnZFore_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 3 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Forward );
		}

		private void btnZFore_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		// C4/A direction JOG
		private void btnABack_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 4 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Backward );
		}

		private void btnABack_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		private void btnAFore_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 4 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Forward );
		}

		private void btnAFore_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		// C5/B direction JOG
		private void btnBBack_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 5 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Backward );
		}

		private void btnBBack_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		private void btnBFore_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 5 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Forward );
		}

		private void btnBFore_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		// C6/C direction JOG
		private void btnCBack_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 6 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Backward );
		}

		private void btnCBack_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		private void btnCFore_MouseDown(object sender, EventArgs e)
		{
			bool result = false;

			result = SetJOGAxis( 6 );
			if( result == false ) {
				return;
			}
			SetJOGDirection( EJogDirection.EJD_Forward );
		}

		private void btnCFore_MouseUp(object sender, EventArgs e)
		{
			SetJOGDirection( EJogDirection.EJD_None );
		}

		private bool SetJOGAxis( int AxisNum )
		{
			int[] Number = new int[ 1 ];
			Number[ 0 ] = AxisNum;
			int cncIndex = 0;
			short result = 0;

			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];

				// Set jog axis
				result = m_CNC[ cncIndex ].WRITE_plc_register( 15203, 15203, Number );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in setting JOG axis: " + result.ToString() );
					return false;
				}
			}
			return true;
		}

		private void SetJOGDirection( EJogDirection JOGDirection )
		{
			int[] Direction = new int[ 1 ];
			Direction[ 0 ] = ( int )JOGDirection;
			int cncIndex = 0;
			short result = 0;

			lbInformation.Items.Clear();
			for( int i = 0; i < lbConnectedIP.SelectedItems.Count; i++ ) {
				cncIndex = lbConnectedIP.SelectedIndices[ i ];

				// Set JOG mode
				result = m_CNC[ cncIndex ].WRITE_plc_register( 15204, 15204, Direction );
				if( result != ( short )SyntecRemoteCNC.ErrorCode.NormalTermination ) {
					lbInformation.Items.Add( m_CNC[ cncIndex ].Host + " Error in starting JOG: " + result.ToString() );
					return;
				}
			}
		}
	}
}
