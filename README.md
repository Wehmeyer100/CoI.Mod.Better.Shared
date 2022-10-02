# CoI.Mod.Better.Shared - Captain of Industry - Modder tools

Game Version(Comptability): 0.4.12C


# Set your mod data here:

	public #Your-Constructer#()
	{
		ModInfo.Name = ModName;
		ModInfo.Directory = ModName;
		ModInfo.Version = "0.2.0";
		ModInfo.TargetVersion = Constants.TargetSharedGameVersion;
		ModInfo.GithubUrl = "https://github.com/Wehmeyer100/CoI.Mod.Better/releases";
	}
    
# Example of generate a research for one Edict:

	ResearchNodeProto researchT1 = GenerateResearchEdict(registrator, MyIDs.Research.GenerellEdictsResearchT1, Name +" I", BetterMod.Config.GenerellEdicts.ResearchCostT1, new ResearchNodeUIData(masterResearch, false, Constants.UIStepSize, Constants.UIStepSize * 2));
	ResearchNodeProto researchT2 = GenerateResearchEdict(registrator, MyIDs.Research.GenerellEdictsResearchT2, Name +" II", BetterMod.Config.GenerellEdicts.ResearchCostT2, researchT1, false);
      
# Example of generate a research for buildings:    
	ResearchNodeProto research_t1 = GenerateResearchBuildings(registrator, MyIDs.Research.StorageResearchT1, Name + " I", "", 1, new ResearchNodeUIData(parent, false, 0, Constants.UIStepSize * 2), MyIDs.Buildings.StorageFluidT1, MyIDs.Buildings.StorageLooseT1, MyIDs.Buildings.StorageUnitT1);
	ResearchNodeProto research_t2 = GenerateResearchBuildings(registrator, MyIDs.Research.StorageResearchT2, Name + " II", "", 4, new ResearchNodeUIData(research_t1, false), MyIDs.Buildings.StorageFluidT2, MyIDs.Buildings.StorageLooseT2, MyIDs.Buildings.StorageUnitT2);
				
# ResearchNodeUIData
	
new ResearchNodeUIData(masterResearch: 1,                                                 false : 2, Constants.UIStepSize : 3, Constants.UIStepSize * 2 : 4)

- 1: research parent
- 2: true for only grid | false for gird and befor research
- 3: Spacing left
- 4: Spacing bottem


# Lang Manager setup

Add the following to the function >> RegisterPrototypes(ProtoRegistrator registrator)

	LangManager.Instance.Load();

# Lang Manager example

	string Name = LangManager.Instance.Get("steam_storage");
	string desc = LangManager.Instance.Get("steam_storage_desc", capacity_steam_T2.ToString());
	
# Lang Manager directories
	Captain of Industry\Mods\{your mod name}\Lang\{your languages}\{all files with sub directories}.

# Lang Manager file example(Json format)
	[
	  {
	    "Key": "farm_multiplier_t1",
	    "Value": "Farm yield multiplier I"
	  }
	]
                       
For more infos, see you soon!
