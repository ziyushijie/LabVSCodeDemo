﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabComm
{
	/// <summary>
	/// 通信状态
	/// </summary>
	public enum COMM_STATE : byte
	{
		STATE_IDLE				= 0,			//---空闲状态
		STATE_POLLREAD			= 1,			//---轮训读取状态
		STATE_WRITE				= 2,			//---写入状态
		STATE_EVENTREAD			= 3,			//---事件读取状态
		STATE_ERROR				= 4,			//---错误状态
	};

	/// <summary>
	/// 串口参数
	/// </summary>
	public class CCommSerialParam
	{
		#region 变量定义

		public string mName = "COM1";

		/// <summary>
		/// 通讯波特率
		/// </summary>
		public string mBaudRate = "115200";

		/// <summary>
		/// 校验位
		/// </summary>
		public string mParity = "NONE";

		/// <summary>
		/// 数据位
		/// </summary>
		public string  mDataBits = "8";

		/// <summary>
		/// 停止位
		/// </summary>
		public string mStopBits = "1";

		/// <summary>
		/// 设备的ID
		/// </summary>
		public int mAddrID = -1;
		
		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CCommSerialParam()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="stopBits"></param>
		/// <param name="dataBits"></param>
		/// <param name="parity"></param>
		public CCommSerialParam(string name,string baudRate,string stopBits,string dataBits,string parity)
		{
			this.mName=name;
			this.mBaudRate=baudRate;
			this.mStopBits=stopBits;
			this.mDataBits=dataBits;
			this.mParity=parity;
		}

		#endregion

		#region 公有函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="stopBits"></param>
		/// <param name="dataBits"></param>
		/// <param name="parity"></param>
		public void AnalyseParam(string name,string baudRate,string stopBits,string dataBits,string parity)
		{
			this.mName=name;
			this.mBaudRate=baudRate;
			this.mStopBits=stopBits;
			this.mDataBits=dataBits;
			this.mParity=parity;
		}

		#endregion

		#region 私有函数

		#endregion
	}

	/// <summary>
	/// USB参数
	/// </summary>
	public class CCommUSBParam
	{
		#region 变量定义

		public int mVID = -1;

		public int mPID = -1;

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		public CCommUSBParam()
		{

		}

		#endregion

		#region 公有函数

		#endregion

		#region 私有函数

		#endregion
	}

	/// <summary>
	/// 通讯接口的参数
	/// </summary>
	interface ICommParam
	{
		#region 公有参数

		/// <summary>
		/// 通断端口名称
		/// </summary>
		string Name
		{
			get;
			set;
		}

		/// <summary>
		/// 通讯接口的序号
		/// </summary>
		int Index
		{
			get;
			set;
		}


		/// <summary>
		/// 通讯端口的信息
		/// </summary>
		string Info
		{
			get;
		}

		/// <summary>
		/// 超时时间
		/// </summary>
		int Timeout
		{
			get;
			set;
		}

		/// <summary>
		/// 是不是多地址通讯，false---不是，true---是
		/// </summary>
		bool IsMultiAddr
		{
			get;
		}

		/// <summary>
		/// 是不是复合命令，比如主命令加子命令,仅仅针对接收有效
		/// </summary>
		bool IsMultiCMD
		{
			get;
			set;
		}

		/// <summary>
		/// 通讯端口是够打开，false---关闭，true---打开
		/// </summary>
		bool IsOpen
		{
			get;
		}

		/// <summary>
		/// 通讯过程中消息信息
		/// </summary>
		string Message
		{
			get;
		}

		/// <summary>
		/// 通讯状态
		/// </summary>
		COMM_STATE COMMSTATE
		{
			get;
		}

		/// <summary>
		/// 使用的时间
		/// </summary>
		TimeSpan UsedTime
		{
			get;
		}


        /// <summary>
        /// 设备连接状态
        /// </summary>
        bool IsConnected
        {
            get;
        }

		#endregion

		#region 串口参数

		CCommSerialParam mSerialParam
		{
			get;
			set;
		}

		#endregion

		#region USB参数

		CCommUSBParam mUSBParam
		{
			get;
			set;
		}

		#endregion

		int Init(CCommSerialParam serialParam, RichTextBox msg = null);
		int Init(CCommUSBParam usbParam, RichTextBox msg = null);

	}
}
