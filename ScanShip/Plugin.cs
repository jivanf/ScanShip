﻿using BepInEx;
using LethalAPI.LibTerminal;
using LethalAPI.LibTerminal.Models;
using ScanShip.Commands;
using UnityEngine;

namespace ScanShip
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(LethalAPI.LibTerminal.PluginInfo.PLUGIN_GUID)]
    public class Plugin : BaseUnityPlugin
    {
        private TerminalModRegistry commandRegistry;

        private void Awake()
        {
            this.gameObject.hideFlags = HideFlags.HideAndDontSave;
            
            this.commandRegistry = TerminalRegistry.CreateTerminalRegistry();
            this.commandRegistry.RegisterFrom<ScanCommand>();
        }

        private void OnDestroy()
        {
            this.commandRegistry.Deregister();
        }
    }
}
