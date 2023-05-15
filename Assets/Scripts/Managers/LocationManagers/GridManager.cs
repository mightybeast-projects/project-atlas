using Models.GameObjectModel;
using UnityEngine;

namespace Managers.LocationManagers
{
    public class GridManager: LocationSubManager
    {
        [SerializeField]
        internal GameObject _tilePrefab;

        private const int _tileSize = 32;

        internal void InstantiateGrid()
        {
            for (var x = 0; x < _currentLocation.grid.GetLength(0); x++)
                for (var y = 0; y < _currentLocation.grid.GetLength(1); y++)
                    CreateNewTile(x, y);
        }

        private void CreateNewTile(int x, int y)
        {
            var tileGameObject = Instantiate(_tilePrefab, _contentPane);
            var tile = new Tile(tileGameObject);
            
            var position = new Vector3(_tileSize * x, _tileSize * y, 0);
            position += GameManager.worldOffset;
            tileGameObject.transform.position = position;
            tileGameObject.name = "Tile (" + x + ", " + y + ")";

            _currentLocation.grid[x, y] = tile;
        }
    }
}
