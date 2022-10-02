using CoI.Mod.Better.Shared.Config;
using CoI.Mod.Better.Shared.Utilities;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CoI.Mod.Better.Shared.Config
{
	[Serializable]
	public class ConfigBase
	{
		public ConfigBase()
		{
		}

		public void Print<T>(T obj)
		{
			BetterDebug.Info("Read config "+obj.GetType().Name+"");
			foreach (FieldInfo field in ReflectionUtility.GetAllFields(obj.GetType()))
			{
				object result = field.GetValue(this);
				if (result is ConfigBase)
				{
					((ConfigBase)result).Print(result);
				}
				else
				{
					Debug.Log(" - " + field.Name + ": " + field.GetValue(this));
				}
			}
		}
	}
}