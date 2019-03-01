using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ETModel;
using UnityEditor;
using UnityEngine;

namespace ETEditor
{
	internal class OpcodeInfo
	{
		public string Name;
		public int Opcode;
	}

	public class Proto2CSEditor: EditorWindow
	{
		[MenuItem("Tools/Proto2CS")]
		public static void AllProto2CS()
		{
			ProcessHelper.Run("dotnet", "Proto2CS.dll", "../Proto/");
			AssetDatabase.Refresh();
		}
	}
}
