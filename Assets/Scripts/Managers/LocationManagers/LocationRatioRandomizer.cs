using System;
using Enums;
using Models.GameObjectModel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers.LocationManagers
{
    public class LocationRatioRandomizer : LocationSubManager
    {
        [SerializeField]
        private int _tileChangeChance = 45;

        private Tile _currentTile;

        internal void RandomiseLocationRatios()
        {
            IterateThroughLocationGridAndExecute(RandomiseCurrentTileRatio);
            IterateThroughLocationGridAndExecute(SmoothNeighborTilesRatio);
            IterateThroughLocationGridAndExecute(ChangeTileSprite);
        }
        
        private void IterateThroughLocationGridAndExecute(Action<int, int> function)
        {
            for (var x = 0; x < _currentLocation.grid.GetLength(0); x++)
                for (var y = 0; y < _currentLocation.grid.GetLength(1); y++)
                    function.Invoke(x, y);
        }
        
        private void ChangeTileSprite(int x, int y)
        {
            var tile = _currentLocation.grid[x, y];
            var tileGameObject = tile.gameObject;
            
            var fileFolder = GetCurrentBiomeFileFolder();
            var path = "Sprites/World/" + fileFolder + "/" + ChooseSpriteNumber(tile);
            var tileSprite = Resources.Load<Sprite>(path);
            
            var tileRenderer = tileGameObject.GetComponent<SpriteRenderer>();
            tileRenderer.sprite = tileSprite;
        }

        private int ChooseSpriteNumber(Tile tile)
        {
            var spriteNumber = 0;
            if (tile.locationRatio < 25)
                spriteNumber = 1;
            else if (tile.locationRatio >= 25 && tile.locationRatio < 75)
                spriteNumber = 2;
            else if (tile.locationRatio >= 75)
                spriteNumber = 3;
            return spriteNumber;
        }

        private void SmoothNeighborTilesRatio(int x, int y)
        {
            _currentTile = _currentLocation.grid[x, y];

            for (var i = y - 1; i < y + 1; i++)
                for (var j = x - 1; j < x + 1; j++)
                    SmoothCurrentTile(j, i);
        }

        private void SmoothCurrentTile(int j, int i)
        {
            Tile neighbourTile;
            try { neighbourTile = _currentLocation.grid[j, i]; }
            catch (Exception) { return; }

            if (CurrentTileDoNotNeedChange(neighbourTile, _currentTile))
                return;

            if (Random.Range(0, 100) <= _tileChangeChance)
                _currentTile.locationRatio = neighbourTile.locationRatio;
        }

        private void RandomiseCurrentTileRatio(int x, int y)
        {
            var tile = _currentLocation.grid[x, y];
            if (Random.Range(0, 15) == 1) tile.locationRatio = 0;
            if (Random.Range(0, 40) == 1) tile.locationRatio = 100;
        }
        
        private string GetCurrentBiomeFileFolder()
        {
            Biome biome = _currentLocation.biome;
            string lowercase = biome.ToString().ToLower();
            string fileFolder = biome.ToString().Substring(0, 1) +
                                lowercase.Substring(1, lowercase.Length - 1);
            return fileFolder;
        }

        private bool CurrentTileDoNotNeedChange(Tile neighbourTile, Tile currentTile)
        {
            return NeighbourTileIsBrighter(neighbourTile, currentTile) && NeighbourTileIsNormal(neighbourTile, currentTile);
        }

        private bool NeighbourTileIsNormal(Tile neighbourTile, Tile currentTile)
        {
            return neighbourTile.locationRatio != 100 || NeighbourTileIsDarker(neighbourTile, currentTile);
        }

        private bool NeighbourTileIsDarker(Tile neighbourTile, Tile currentTile)
        {
            return neighbourTile.locationRatio <= currentTile.locationRatio;
        }

        private bool NeighbourTileIsBrighter(Tile neighbourTile, Tile currentTile)
        {
            return neighbourTile.locationRatio >= currentTile.locationRatio;
        }
    }
}