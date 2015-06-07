using System;
using System.Collections.Generic;
using System.Text;

namespace Foosun.Model
{
	/// <summary>
	/// FTP配置文件
	/// </summary>
	[Serializable]
	public class FtpConfig
	{
		/// <summary>
		/// FTP同步是否启用
		/// </summary>
		public byte Enabled;
		/// <summary>
		/// FTP同步的IP
		/// </summary>
		public string IP;
		/// <summary>
		/// FTP同步的端口
		/// </summary>
		public int Port;
		/// <summary>
		/// FTP用户名
		/// </summary>
		public string UserName;
		/// <summary>
		/// FTP密码
		/// </summary>
		public string Password;
		/// <summary>
		/// 是否正在同步
		/// </summary>
		public bool IsSynchronized;
		/// <summary>
		/// 正在同步的操作者
		/// </summary>
		public string Operator;
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
	}
}
