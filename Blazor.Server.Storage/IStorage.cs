using System.Threading.Tasks;

namespace Blazor.Server.Storage
{
	/// <summary>
	/// Wrapper for HTML Storage object.
	/// </summary>
	public interface IStorage
	{
		#region Properties
		Task<int> GetLength();
		#endregion

		#region Methods
		Task<string> Key(int index);
		Task<TItem> GetItem<TItem>(string keyName);
		Task SetItem<TItem>(string keyName, TItem keyValue);
		Task RemoveItem(string keyName);
		Task Clear();
		#endregion
	}
}
