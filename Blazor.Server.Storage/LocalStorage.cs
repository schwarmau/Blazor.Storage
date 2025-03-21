﻿using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Server.Storage
{
	public class LocalStorage : IStorage
	{
		private readonly IJSRuntime _jsRuntime;
		private const string LOCAL_STORAGE_NAME = "localStorage";

		public LocalStorage(IJSRuntime jsRuntime)
		{
			_jsRuntime = jsRuntime;
		}

		public Task Clear()
		{
			return _jsRuntime.InvokeAsync<object>("blazorStorage.callStorageMethod", LOCAL_STORAGE_NAME, Constants.CLEAR);
		}

		public Task<TItem> GetItem<TItem>(string keyName)
		{
			if (string.IsNullOrWhiteSpace(keyName))
			{
				throw new ArgumentNullException(nameof(keyName));
			}

			return _jsRuntime.InvokeAsync<TItem>("blazorStorage.callStorageMethod", LOCAL_STORAGE_NAME, Constants.GET_ITEM, new object[1] { keyName });
		}

		public Task<int> GetLength()
		{
			return _jsRuntime.InvokeAsync<int>("blazorStorage.getStorageProperty", LOCAL_STORAGE_NAME, Constants.LENGTH);
		}

		public Task<string> Key(int index)
		{
			return _jsRuntime.InvokeAsync<string>("blazorStorage.callStorageMethod", LOCAL_STORAGE_NAME, Constants.KEY, new object[1] { index });
		}

		public Task RemoveItem(string keyName)
		{
			if (string.IsNullOrWhiteSpace(keyName))
			{
				throw new ArgumentNullException(nameof(keyName));
			}

			return _jsRuntime.InvokeAsync<object>("blazorStorage.callStorageMethod", LOCAL_STORAGE_NAME, Constants.REMOVE_ITEM, new object[1] { keyName });
		}

		public Task SetItem<TItem>(string keyName, TItem keyValue)
		{
			if (string.IsNullOrWhiteSpace(keyName))
			{
				throw new ArgumentNullException(nameof(keyName));
			}

			return _jsRuntime.InvokeAsync<object>("blazorStorage.callStorageMethod", LOCAL_STORAGE_NAME, Constants.SET_ITEM, new object[2] { keyName, keyValue });
		}
	}
}
