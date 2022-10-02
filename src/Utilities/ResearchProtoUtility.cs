using CoI.Mod.Better.Shared.Extensions;
using Mafi.Core.Entities.Static;
using Mafi.Core.Factory.Machines;
using Mafi.Core.Factory.Recipes;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Research;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CoI.Mod.Better.Shared.Utilities
{
	public static partial class ResearchProtoUtility
	{
        #region GenerateResearchEdict

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchEdict(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, ResearchNodeProto parent_research, bool parent_only_for_grid, params Proto.ID[] unlockEdictProtoIDs)
		{
			return GenerateResearchEdict(registrator, protoID, name, "", new ResearchCostsTpl(1), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockEdictProtoIDs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchEdict(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, int researchCost, ResearchNodeProto parent_research, bool parent_only_for_grid, params Proto.ID[] unlockEdictProtoIDs)
		{
			return GenerateResearchEdict(registrator, protoID, name, "", new ResearchCostsTpl(researchCost), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockEdictProtoIDs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchEdict(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, int researchCost, ResearchNodeUIData uidata, params Proto.ID[] unlockEdictProtoIDs)
		{
			return GenerateResearchEdict(registrator, protoID, name, "", new ResearchCostsTpl(researchCost), uidata, unlockEdictProtoIDs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchEdict(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, int researchCost,  ResearchNodeUIData uidata, params Proto.ID[] unlockEdictProtoIDs)
		{
			return GenerateResearchEdict(registrator, protoID, name, desc, new ResearchCostsTpl(researchCost), uidata, unlockEdictProtoIDs);
		}

		public static ResearchNodeProto GenerateResearchEdict(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, ResearchCostsTpl researchCost,  ResearchNodeUIData uidata, params Proto.ID[] unlockEdictProtoIDs)
		{
			ResearchNodeProtoBuilder.State research_state = _generateResearch(registrator, protoID, name, desc, researchCost);
			if (unlockEdictProtoIDs != null && unlockEdictProtoIDs.Length > 0)
			{
				research_state.AddEdictToUnlock(unlockEdictProtoIDs);
			}
			return _buildResearch(research_state, uidata);
		}

        #endregion

        #region GenerateResearchBuildings

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchBuildings(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name,  ResearchNodeProto parent_research, bool parent_only_for_grid, params StaticEntityProto.ID[] unlockProtoIDs)
		{
			return GenerateResearchBuildings(registrator, protoID, name, "", new ResearchCostsTpl(1), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockProtoIDs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchBuildings(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, int researchCost,  ResearchNodeProto parent_research, bool parent_only_for_grid, params StaticEntityProto.ID[] unlockProtoIDs)
		{
			return GenerateResearchBuildings(registrator, protoID, name, "", new ResearchCostsTpl(researchCost), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockProtoIDs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchBuildings(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, int researchCost,  ResearchNodeUIData uidata, params StaticEntityProto.ID[] unlockProtoIDs)
		{
			return GenerateResearchBuildings(registrator, protoID, name, desc, new ResearchCostsTpl(researchCost), uidata, unlockProtoIDs);
		}

		public static ResearchNodeProto GenerateResearchBuildings(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, ResearchCostsTpl researchCost,  ResearchNodeUIData uidata, params StaticEntityProto.ID[] unlockProtoIDs)
		{
			ResearchNodeProtoBuilder.State research_state = _generateResearch(registrator, protoID, name, desc, researchCost);
			if (unlockProtoIDs != null && unlockProtoIDs.Length > 0)
			{
				research_state.AddLayoutEntityToUnlock(unlockProtoIDs);
			}
			return _buildResearch(research_state, uidata);
		}

        #endregion

        #region GenerateResearchMachineWithAllRecipes

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchMachineWithAllRecipes(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name,  ResearchNodeProto parent_research, bool parent_only_for_grid, params MachineProto.ID[] unlockProtoIDs)
		{
			return GenerateResearchMachine(registrator, protoID, name, "", new ResearchCostsTpl(1), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockProtoIDs, null);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchMachineWithAllRecipes(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, int researchCost,  ResearchNodeProto parent_research, bool parent_only_for_grid, params MachineProto.ID[] unlockProtoIDs)
		{
			return GenerateResearchMachine(registrator, protoID, name, "", new ResearchCostsTpl(researchCost), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockProtoIDs, null);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchMachineWithAllRecipes(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, int researchCost,  ResearchNodeUIData uidata, params MachineProto.ID[] unlockProtoIDs)
		{
			return GenerateResearchMachine(registrator, protoID, name, desc, new ResearchCostsTpl(researchCost), uidata, unlockProtoIDs, null);
		}

        #endregion

        #region GenerateResearchMachine

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchMachine(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name,  ResearchNodeProto parent_research, bool parent_only_for_grid, MachineProto.ID[] unlockMachineProtoIDs, RecipeProto.ID[] unlockRecipeProtoIDs)
		{
			return GenerateResearchMachine(registrator, protoID, name, "", new ResearchCostsTpl(1), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockMachineProtoIDs, unlockRecipeProtoIDs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchMachine(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, int researchCost,  ResearchNodeProto parent_research, bool parent_only_for_grid, MachineProto.ID[] unlockMachineProtoIDs, RecipeProto.ID[] unlockRecipeProtoIDs)
		{
			return GenerateResearchMachine(registrator, protoID, name, "", new ResearchCostsTpl(researchCost), new ResearchNodeUIData(parent_research, parent_only_for_grid), unlockMachineProtoIDs, unlockRecipeProtoIDs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ResearchNodeProto GenerateResearchMachine(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, int researchCost,  ResearchNodeUIData uidata, MachineProto.ID[] unlockMachineProtoIDs, RecipeProto.ID[] unlockRecipeProtoIDs)
		{
			return GenerateResearchMachine(registrator, protoID, name, desc, new ResearchCostsTpl(researchCost), uidata, unlockMachineProtoIDs, unlockRecipeProtoIDs);
		}

		public static ResearchNodeProto GenerateResearchMachine(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, ResearchCostsTpl researchCost,  ResearchNodeUIData uidata, MachineProto.ID[] unlockMachineProtoIDs, RecipeProto.ID[] unlockRecipeProtoIDs)
		{
			ResearchNodeProtoBuilder.State research_state = _generateResearch(registrator, protoID, name, desc, researchCost);

			foreach (MachineProto.ID machineProtoID in unlockMachineProtoIDs)
			{
				research_state.AddMachineToUnlock(machineProtoID);

				if (unlockRecipeProtoIDs == null)
				{
					research_state.AddAllRecipesOfMachineToUnlock(machineProtoID);
				}
				else
				{
					foreach (RecipeProto.ID recipeId in unlockRecipeProtoIDs)
					{
						research_state.AddRecipeToUnlock(recipeId);
					}
				}
			}

			return _buildResearch(research_state, uidata);
		}

        #endregion

		private static ResearchNodeProtoBuilder.State _generateResearch(ProtoRegistrator registrator, ResearchNodeProto.ID protoID, string name, string desc, ResearchCostsTpl researchCost)
		{
			ResearchNodeProtoBuilder.State researchState = registrator.ResearchNodeProtoBuilder.Start(name, protoID);

			if (!String.IsNullOrEmpty(desc))
			{
				researchState.Description(desc);
			}
			
			researchState.SetCosts(researchCost);
			return researchState;
		}

		private static ResearchNodeProto _buildResearch(ResearchNodeProtoBuilder.State state, ResearchNodeUIData data)
		{
			return _buildResearch(state, data.parent, data.parent_only_for_grid, data.ui_stepSize_x, data.ui_stepSize_y);
		}

		private static ResearchNodeProto _buildResearch(ResearchNodeProtoBuilder.State state, ResearchNodeProto parentResearch, bool parentOnlyForGrid, int uiStepSizeX = Constants.UIStepSize, int uiStepSizeY = 0)
		{
			ResearchNodeProto research = state.BuildAndAdd();
			if (parentOnlyForGrid)
			{
				research.AddGridPos(parentResearch, uiStepSizeX, uiStepSizeY);
			}
			else
			{
				research.AddParentPlusGridPos(parentResearch, uiStepSizeX, uiStepSizeY);
			}
			BetterDebug.Info("ResearchProtoUtility >> _buildResearch >> Research (id: '" + research.Id + "', name: '" + research.Strings.Name.ToString() + "', parent: '" + parentResearch.Id.ToString() + "') has generated.");
			return research;
		}
	}
}