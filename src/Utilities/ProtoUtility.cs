using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CoI.Mod.Better.Shared;
using CoI.Mod.Better.Shared.Utilities;
using Mafi;
using Mafi.Base;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;

namespace CoI.Mod.Better.Shared.Utilities
{
	public class ProtoUtility
	{
		public static List<Prototype> AllProtos<Prototype>(ProtoRegistrator registrator, bool debug = false) where Prototype : Proto
		{
			var results = registrator.PrototypesDb.All<Prototype>().ToList();
			if (debug)
			{
				DebugList(results, "AllProtos");
			}
			return results;
		}

		public static List<Prototype> AllVanillaBuildings<Prototype>(ProtoRegistrator registrator, bool debug = false) where Prototype : Proto
		{
			List<Prototype> results = new List<Prototype>();
			IEnumerable<FieldInfo> result = ReflectionUtility.GetAllFields(typeof(Ids.Buildings));

			foreach (FieldInfo field in result)
			{
				string fieldName = field.Name;
				object value = field.GetValue(null);
				if (field.IsStatic && value != null && value is StaticEntityProto.ID)
				{
					StaticEntityProto.ID fieldValueProtoID = (StaticEntityProto.ID)value;
					Option<Prototype> resultProduct = registrator.PrototypesDb.Get<Prototype>(fieldValueProtoID);

					if (resultProduct.HasValue)
					{
						results.Add(resultProduct.Value);
					}
				}
			}

			if (debug)
			{
				DebugList(results, "AllVanillaBuildings");
			}
			return results;
		}

		public static List<ToolbarCategoryProto> AllVanillaToolbars(ProtoRegistrator registrator, bool debug = false)
		{
			List<ToolbarCategoryProto> results = new List<ToolbarCategoryProto>();
			IEnumerable<FieldInfo> result = ReflectionUtility.GetAllFields(typeof(Ids.ToolbarCategories));

			foreach (FieldInfo field in result)
			{
				string fieldName = field.Name;
				object value = field.GetValue(null);
				if (field.IsStatic && value != null && value is Proto.ID)
				{
					Proto.ID fieldValueProtoID = (Proto.ID)value;
					Option<ToolbarCategoryProto> resultProduct = registrator.PrototypesDb.Get<ToolbarCategoryProto>(fieldValueProtoID);

					if (resultProduct.HasValue)
					{
						results.Add(resultProduct.Value);
					}
				}
			}


			if (debug)
			{
				DebugList(results, "AllVanillaToolbars");
			}
			return results;
		}

		private static void DebugList<Prototype>(List<Prototype> data, string prefix) where Prototype : Proto
		{
			data.ForEach(proto => BetterDebug.Info("ProtoUtility >> " + prefix + "<" + proto.GetType() + "> >> name: " + proto.Strings.Name + " | id: " + proto.Id));
		}
	}
}