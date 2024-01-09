using System.Linq;
using LethalAPI.LibTerminal.Attributes;
using UnityEngine;

namespace ScanShip.Commands;

public class ScanCommand
{
    [TerminalCommand("Scan", true)]
    public string Scan(string location)
    {
        if (location != "ship")
        {
            return null;
        }

        var scrapObjectsInShip = Object
            .FindObjectsOfType<GrabbableObject>()
            .Where(scrapObject => scrapObject.itemProperties.isScrap && scrapObject.isInShipRoom)
            .ToList();

        int totalValue = scrapObjectsInShip.Sum(scrapObject => scrapObject.scrapValue);
        int count = scrapObjectsInShip.Count;

        return $"There {(count == 1 ? "is" : "are")} {count} {(count == 1 ? "object" : "objects")} inside the ship, totalling at a value of ${totalValue}.";
    }
}
